#include <coreclr_delegates.h>
#include <hostfxr.h>
#include <jni.h>
#include <nethost.h>

#include <cstdint>
#include <filesystem>
#include <iostream>
#include <vector>

#if defined(_WIN32)
#include <windows.h>
#define J4N_TEXT(value) L##value
#else
#include <dlfcn.h>
#define J4N_TEXT(value) value
#endif

extern "C" JNIEXPORT jint JNICALL Java_net_sf_jni4net_Bridge_initDotNet(JNIEnv* env, jclass clazz);

namespace
{
#if defined(_WIN32)
    using library_handle = HMODULE;

    library_handle load_library(const char_t* path)
    {
        return ::LoadLibraryW(path);
    }

    void* get_export(library_handle library, const char* name)
    {
        return reinterpret_cast<void*>(::GetProcAddress(library, name));
    }

    std::filesystem::path module_directory()
    {
        HMODULE module = nullptr;
        const auto address = reinterpret_cast<LPCWSTR>(
            reinterpret_cast<std::uintptr_t>(&Java_net_sf_jni4net_Bridge_initDotNet));
        if (!::GetModuleHandleExW(GET_MODULE_HANDLE_EX_FLAG_FROM_ADDRESS |
                                      GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT,
                                  address,
                                  &module))
        {
            return {};
        }

        std::vector<wchar_t> path(4096);
        const DWORD length = ::GetModuleFileNameW(module, path.data(), static_cast<DWORD>(path.size()));
        if (length == 0 || length == path.size())
        {
            return {};
        }
        return std::filesystem::path(path.data()).parent_path();
    }
#else
    using library_handle = void*;

    library_handle load_library(const char_t* path)
    {
        return ::dlopen(path, RTLD_LAZY | RTLD_LOCAL);
    }

    void* get_export(library_handle library, const char* name)
    {
        return ::dlsym(library, name);
    }

    std::filesystem::path module_directory()
    {
        Dl_info info = {};
        const auto address = reinterpret_cast<void*>(
            reinterpret_cast<std::uintptr_t>(&Java_net_sf_jni4net_Bridge_initDotNet));
        if (::dladdr(address, &info) == 0 || info.dli_fname == nullptr)
        {
            return {};
        }
        return std::filesystem::path(info.dli_fname).parent_path();
    }
#endif

    int error(const char* message, int code)
    {
        std::cerr << "jni4net.coreclr: " << message << " (code " << code << ")" << std::endl;
        return code;
    }

    int error(const char* message, const std::filesystem::path& path, int code)
    {
        std::cerr << "jni4net.coreclr: " << message << ": " << path.string()
                  << " (code " << code << ")" << std::endl;
        return code;
    }

    library_handle load_hostfxr()
    {
        std::vector<char_t> buffer(4096);
        size_t size = buffer.size();
        int rc = get_hostfxr_path(buffer.data(), &size, nullptr);
        if (rc != 0 && size > buffer.size())
        {
            buffer.resize(size);
            rc = get_hostfxr_path(buffer.data(), &size, nullptr);
        }
        if (rc != 0)
        {
            error("cannot locate hostfxr; install the .NET 10 x64 runtime", rc);
            return nullptr;
        }

        library_handle hostfxr = load_library(buffer.data());
        if (hostfxr == nullptr)
        {
            error("cannot load hostfxr", -101);
        }
        return hostfxr;
    }
}

extern "C" JNIEXPORT jint JNICALL Java_net_sf_jni4net_Bridge_initDotNet(JNIEnv* env, jclass clazz)
{
    const std::filesystem::path directory = module_directory();
    if (directory.empty())
    {
        return error("cannot determine native library directory", -100);
    }

    const std::filesystem::path runtime_config = directory / "jni4net.n.runtimeconfig.json";
    const std::filesystem::path managed_assembly = directory / "jni4net.n.dll";
    if (!std::filesystem::exists(runtime_config))
    {
        return error("missing runtime configuration", runtime_config, -102);
    }
    if (!std::filesystem::exists(managed_assembly))
    {
        return error("missing managed bridge assembly", managed_assembly, -103);
    }

    const library_handle hostfxr = load_hostfxr();
    if (hostfxr == nullptr)
    {
        return -104;
    }

    const auto initialize = reinterpret_cast<hostfxr_initialize_for_runtime_config_fn>(
        get_export(hostfxr, "hostfxr_initialize_for_runtime_config"));
    const auto get_delegate = reinterpret_cast<hostfxr_get_runtime_delegate_fn>(
        get_export(hostfxr, "hostfxr_get_runtime_delegate"));
    const auto close = reinterpret_cast<hostfxr_close_fn>(get_export(hostfxr, "hostfxr_close"));
    if (initialize == nullptr || get_delegate == nullptr || close == nullptr)
    {
        return error("hostfxr does not expose the required hosting functions", -105);
    }

    hostfxr_handle context = nullptr;
    int rc = initialize(runtime_config.native().c_str(), nullptr, &context);
    if (rc != 0 || context == nullptr)
    {
        return error("cannot initialize .NET from runtime configuration", rc == 0 ? -106 : rc);
    }

    load_assembly_and_get_function_pointer_fn load_assembly = nullptr;
    rc = get_delegate(context,
                      hdt_load_assembly_and_get_function_pointer,
                      reinterpret_cast<void**>(&load_assembly));
    if (rc != 0 || load_assembly == nullptr)
    {
        close(context);
        return error("cannot obtain managed component loader", rc == 0 ? -107 : rc);
    }

    using initialize_bridge_fn = jint(CORECLR_DELEGATE_CALLTYPE*)(JNIEnv*, jclass);
    initialize_bridge_fn initialize_bridge = nullptr;
    rc = load_assembly(managed_assembly.native().c_str(),
                       J4N_TEXT("net.sf.jni4net.CoreClrEntryPoint, jni4net.n"),
                       J4N_TEXT("Initialize"),
                       UNMANAGEDCALLERSONLY_METHOD,
                       nullptr,
                       reinterpret_cast<void**>(&initialize_bridge));
    close(context);
    if (rc != 0 || initialize_bridge == nullptr)
    {
        return error("cannot bind the managed bridge initialization method", rc == 0 ? -108 : rc);
    }

    return initialize_bridge(env, clazz);
}
