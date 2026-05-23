cmake_minimum_required(VERSION 3.20)

if(NOT DEFINED REPO_ROOT)
    get_filename_component(REPO_ROOT "${CMAKE_CURRENT_LIST_DIR}/.." ABSOLUTE)
endif()

if(NOT DEFINED CONFIGURATION)
    set(CONFIGURATION "Release")
endif()

if(NOT DEFINED RUNTIME)
    message(FATAL_ERROR "Set RUNTIME to coreclr or framework.")
endif()

if(NOT DEFINED PLATFORM)
    message(FATAL_ERROR "Set PLATFORM to linux-x64 or windows-x64.")
endif()

set(JNI4NET_VERSION "0.8.9.0")
set(RELEASE_ROOT "${REPO_ROOT}/target/release")

if(RUNTIME STREQUAL "coreclr")
    if(NOT DEFINED NATIVE_LIBRARY)
        message(FATAL_ERROR "Set NATIVE_LIBRARY to the built jni4net.coreclr launcher.")
    endif()
    set(PACKAGE_NAME "jni4net-${JNI4NET_VERSION}-coreclr-${PLATFORM}")
    set(RELEASE_FILES
        "${REPO_ROOT}/jni4net.n/src/bin/${CONFIGURATION}/net10.0/jni4net.n.dll"
        "${REPO_ROOT}/jni4net.n/src/bin/${CONFIGURATION}/net10.0/jni4net.n.deps.json"
        "${REPO_ROOT}/jni4net.n/src/bin/${CONFIGURATION}/net10.0/jni4net.n.runtimeconfig.json"
        "${REPO_ROOT}/jni4net.n/src/bin/${CONFIGURATION}/net10.0/System.CodeDom.dll"
        "${REPO_ROOT}/jni4net.j/target/jni4net.j-${JNI4NET_VERSION}.jar"
        "${NATIVE_LIBRARY}"
    )
elseif(RUNTIME STREQUAL "framework")
    if(NOT PLATFORM STREQUAL "windows-x64")
        message(FATAL_ERROR ".NET Framework release output is supported only on windows-x64.")
    endif()
    if(NOT DEFINED FRAMEWORK_LAUNCHER)
        message(FATAL_ERROR "Set FRAMEWORK_LAUNCHER to the exported .NET Framework JNI launcher DLL.")
    endif()
    set(PACKAGE_NAME "jni4net-${JNI4NET_VERSION}-net48-${PLATFORM}")
    set(RELEASE_FILES
        "${REPO_ROOT}/jni4net.n/src/bin/${CONFIGURATION}/net48/jni4net.n-${JNI4NET_VERSION}.dll"
        "${REPO_ROOT}/jni4net.j/target/jni4net.j-${JNI4NET_VERSION}.jar"
        "${FRAMEWORK_LAUNCHER}"
    )
else()
    message(FATAL_ERROR "Unsupported RUNTIME value: ${RUNTIME}")
endif()

set(PACKAGE_DIR "${RELEASE_ROOT}/${PACKAGE_NAME}")
set(PACKAGE_ARCHIVE "${RELEASE_ROOT}/${PACKAGE_NAME}.zip")

foreach(RELEASE_FILE IN LISTS RELEASE_FILES)
    if(NOT EXISTS "${RELEASE_FILE}")
        message(FATAL_ERROR "Required release input does not exist: ${RELEASE_FILE}")
    endif()
endforeach()

file(REMOVE_RECURSE "${PACKAGE_DIR}")
file(REMOVE "${PACKAGE_ARCHIVE}")
file(MAKE_DIRECTORY "${PACKAGE_DIR}/lib")

foreach(RELEASE_FILE IN LISTS RELEASE_FILES)
    file(COPY "${RELEASE_FILE}" DESTINATION "${PACKAGE_DIR}/lib")
endforeach()
file(COPY "${REPO_ROOT}/license/jni4net-MIT.txt" DESTINATION "${PACKAGE_DIR}/lib")
file(COPY "${REPO_ROOT}/content/ReadMe.md" DESTINATION "${PACKAGE_DIR}")

execute_process(
    COMMAND "${CMAKE_COMMAND}" -E tar "cf" "${PACKAGE_ARCHIVE}" --format=zip "${PACKAGE_NAME}"
    WORKING_DIRECTORY "${RELEASE_ROOT}"
    COMMAND_ERROR_IS_FATAL ANY
)

message(STATUS "Created jni4net release archive: ${PACKAGE_ARCHIVE}")
