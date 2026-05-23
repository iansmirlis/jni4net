cmake_minimum_required(VERSION 3.20)

if(NOT DEFINED REPO_ROOT)
    get_filename_component(REPO_ROOT "${CMAKE_CURRENT_LIST_DIR}/.." ABSOLUTE)
endif()

if(NOT DEFINED CONFIGURATION)
    set(CONFIGURATION "Release")
endif()

if(NOT DEFINED FRAMEWORK_LAUNCHER)
    message(FATAL_ERROR "Set FRAMEWORK_LAUNCHER to the exported .NET Framework JNI launcher DLL.")
endif()

set(JNI4NET_VERSION "0.8.9.0")
set(TARGET_FRAMEWORK "net48")
set(STAGE_DIR "${REPO_ROOT}/target/test-stage-framework")

set(STAGE_FILES
    "${REPO_ROOT}/jni4net.n/src/bin/${CONFIGURATION}/${TARGET_FRAMEWORK}/jni4net.n-${JNI4NET_VERSION}.dll"
    "${REPO_ROOT}/jni4net.tested.n/src/bin/${CONFIGURATION}/${TARGET_FRAMEWORK}/jni4net.tested.n-${JNI4NET_VERSION}.dll"
    "${REPO_ROOT}/jni4net.j/target/jni4net.j-${JNI4NET_VERSION}.jar"
    "${REPO_ROOT}/jni4net.tested.j/target/jni4net.tested.j-${JNI4NET_VERSION}.jar"
    "${FRAMEWORK_LAUNCHER}"
)

foreach(STAGE_FILE IN LISTS STAGE_FILES)
    if(NOT EXISTS "${STAGE_FILE}")
        message(FATAL_ERROR "Required staged Framework test input does not exist: ${STAGE_FILE}")
    endif()
endforeach()

set(TEST_CLASS_DIR "${REPO_ROOT}/jni4net.test.j/target/test-classes")
if(NOT IS_DIRECTORY "${TEST_CLASS_DIR}")
    message(FATAL_ERROR "Required staged Java test classes do not exist: ${TEST_CLASS_DIR}")
endif()

file(REMOVE_RECURSE "${STAGE_DIR}")
file(MAKE_DIRECTORY "${STAGE_DIR}" "${STAGE_DIR}/jni4net.test.j.classes")

foreach(STAGE_FILE IN LISTS STAGE_FILES)
    file(COPY "${STAGE_FILE}" DESTINATION "${STAGE_DIR}")
endforeach()
file(COPY "${TEST_CLASS_DIR}/" DESTINATION "${STAGE_DIR}/jni4net.test.j.classes")

message(STATUS "Staged .NET Framework integration inputs in ${STAGE_DIR}")
