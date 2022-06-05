cmake_minimum_required(VERSION 3.22)
project(ElementalCognitionSystem)

set(CMAKE_CXX_STANDARD 14)

include_directories("/usr/local/include/eigen3")

add_executable(ElementalCognitionSystem main.cpp src/Unit/BaseUnit.cpp src/Unit/BaseUnit.h src/Unit/GateUnit.cpp src/Unit/GateUnit.h src/Unit/CanvasUnit.cpp src/Unit/CanvasUnit.h src/Tasks/TaskManager.cpp src/Tasks/TaskManager.h)
#add_executable(ElementalCognitionSystem runEigen.cpp main.cpp src/Unit/BaseUnit.cpp src/Unit/BaseUnit.h src/Unit/GateUnit.cpp src/Unit/GateUnit.h src/Unit/CanvasUnit.cpp src/Unit/CanvasUnit.h src/Tasks/TaskManager.cpp src/Tasks/TaskManager.h)
#add_executable(ElementalCognitionSystem runEigen.cpp)

add_executable(runEigen runEigen.cpp)