cmake_minimum_required(VERSION 3.22)
project(ElementalCognitionSystem)

set(CMAKE_CXX_STANDARD 14)

add_executable(ElementalCognitionSystem main.cpp src/Unit/BaseUnit.cpp src/Unit/BaseUnit.h src/Unit/GateUnit.cpp src/Unit/GateUnit.h src/Unit/CanvasUnit.cpp src/Unit/CanvasUnit.h src/Tasks/TaskManager.cpp src/Tasks/TaskManager.h)
