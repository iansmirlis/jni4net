cmake_minimum_required(VERSION 3.20)

if(NOT DEFINED REPO_ROOT)
    get_filename_component(REPO_ROOT "${CMAKE_CURRENT_LIST_DIR}/.." ABSOLUTE)
endif()

if(NOT DEFINED CONFIGURATION)
    set(CONFIGURATION "Release")
endif()

if(NOT DEFINED NATIVE_LIBRARY)
    message(FATAL_ERROR "Set NATIVE_LIBRARY to the built jni4net.coreclr native launcher.")
endif()

set(JNI4NET_VERSION "0.8.9.0")
set(TARGET_FRAMEWORK "net10.0")
set(STAGE_DIR "${REPO_ROOT}/target/test-stage")

set(STAGE_FILES
    "${REPO_ROOT}/jni4net.n/src/bin/${CONFIGURATION}/${TARGET_FRAMEWORK}/jni4net.n.dll"
    "${REPO_ROOT}/jni4net.n/src/bin/${CONFIGURATION}/${TARGET_FRAMEWORK}/jni4net.n.deps.json"
    "${REPO_ROOT}/jni4net.n/src/bin/${CONFIGURATION}/${TARGET_FRAMEWORK}/jni4net.n.runtimeconfig.json"
    "${REPO_ROOT}/jni4net.n/src/bin/${CONFIGURATION}/${TARGET_FRAMEWORK}/System.CodeDom.dll"
    "${REPO_ROOT}/jni4net.tested.n/src/bin/${CONFIGURATION}/${TARGET_FRAMEWORK}/jni4net.tested.n.dll"
    "${REPO_ROOT}/jni4net.tested.n/src/bin/${CONFIGURATION}/${TARGET_FRAMEWORK}/jni4net.tested.n.deps.json"
    "${REPO_ROOT}/jni4net.j/target/jni4net.j-${JNI4NET_VERSION}.jar"
    "${REPO_ROOT}/jni4net.tested.j/target/jni4net.tested.j-${JNI4NET_VERSION}.jar"
    "${NATIVE_LIBRARY}"
)

foreach(STAGE_FILE IN LISTS STAGE_FILES)
    if(NOT EXISTS "${STAGE_FILE}")
        message(FATAL_ERROR "Required staged test input does not exist: ${STAGE_FILE}")
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

message(STATUS "Staged jni4net integration inputs in ${STAGE_DIR}")
