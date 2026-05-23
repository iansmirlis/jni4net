cmake_minimum_required(VERSION 3.20)

project(jni4net_coreclr LANGUAGES CXX)

if(NOT CMAKE_SIZEOF_VOID_P EQUAL 8)
    message(FATAL_ERROR "jni4net CoreCLR supports x64 builds only")
endif()

find_package(JNI REQUIRED)
find_program(DOTNET_EXECUTABLE dotnet REQUIRED)

get_filename_component(DOTNET_EXECUTABLE "${DOTNET_EXECUTABLE}" REALPATH)
get_filename_component(DOTNET_ROOT "${DOTNET_EXECUTABLE}" DIRECTORY)

if(WIN32)
    set(NETHOST_RID win-x64)
    set(NETHOST_LIBRARY_NAME libnethost.lib)
else()
    set(NETHOST_RID linux-x64)
    set(NETHOST_LIBRARY_NAME libnethost.a)
endif()

file(GLOB NETHOST_NATIVE_DIRS
    LIST_DIRECTORIES true
    "${DOTNET_ROOT}/packs/Microsoft.NETCore.App.Host.${NETHOST_RID}/*/runtimes/${NETHOST_RID}/native")
list(SORT NETHOST_NATIVE_DIRS COMPARE NATURAL ORDER DESCENDING)
list(GET NETHOST_NATIVE_DIRS 0 NETHOST_NATIVE_DIR)

if(NOT EXISTS "${NETHOST_NATIVE_DIR}/${NETHOST_LIBRARY_NAME}")
    message(FATAL_ERROR "Could not locate the ${NETHOST_RID} nethost library under ${DOTNET_ROOT}")
endif()

add_library(jni4net_coreclr SHARED src/jni4net_coreclr.cpp)
set_target_properties(jni4net_coreclr PROPERTIES OUTPUT_NAME "jni4net.coreclr")
target_compile_features(jni4net_coreclr PRIVATE cxx_std_17)
target_compile_definitions(jni4net_coreclr PRIVATE NETHOST_USE_AS_STATIC)
target_include_directories(jni4net_coreclr PRIVATE "${NETHOST_NATIVE_DIR}" ${JNI_INCLUDE_DIRS})
target_link_libraries(jni4net_coreclr PRIVATE "${NETHOST_NATIVE_DIR}/${NETHOST_LIBRARY_NAME}" ${CMAKE_DL_LIBS})

if(MSVC)
    set_property(TARGET jni4net_coreclr PROPERTY MSVC_RUNTIME_LIBRARY "MultiThreaded")
    target_compile_options(jni4net_coreclr PRIVATE /W4)
else()
    target_compile_options(jni4net_coreclr PRIVATE -Wall -Wextra -Wpedantic)
endif()
