# Space-Wars-Dots
This minimalist yet engaging Unity project showcases the capabilities of Unity's Data-Oriented Technology Stack (DOTS) through a simple space shooter game. Experience the efficiency and performance gains of DOTS
Simple shooting game created using Unity's Entity Component System (ECS).

## Gameplay

Shoot down the targets with clicking space.

## Features

- Entity Component System (ECS) architecture for improved performance.
- Basic shooting mechanics.
- Obstacles and targets with different behaviors.
- Unity Jobs System and Burst Compiler for optimized performance in critical sections.


## Screenshots
<img width="242" alt="fps_screenshot" src="https://github.com/bee51/Space-Wars-Dots/assets/76045666/4a9790b9-be4a-42ac-b2a1-992ea5db027a">

## Multi-Threaded Object Movement with Unity Jobs System

In this project, we utilize Unity's Jobs System to manage the movement of multiple objects concurrently, improving performance by leveraging multi-threading. This allows us to handle the movement of objects in parallel threads, leading to enhanced efficiency and better resource utilization.

The Unity Jobs System enables us to write code that can run concurrently on multiple CPU cores, optimizing performance by efficiently distributing workload. It operates well in scenarios where there's a need for parallel processing, such as updating multiple game objects simultaneously.


<img width="554" alt="gameplay_screenshot2" src="https://github.com/bee51/Space-Wars-Dots/assets/76045666/ff26c96e-e8f7-4b67-82a6-366c3d9ec5f6">


## Getting Started

Follow these steps to set up and run the project:

1. Clone the repository: `git clone https://github.com/bee51/Space-Wars-Dots.git`
2. Open the project in Unity.


## Unity Jobs System and Burst Compiler

This project utilizes Unity's Data-Oriented Technology Stack (DOTS) features, specifically the Unity Jobs System and Burst Compiler.

The Unity Jobs System allows for efficient multi-threading by allowing you to write code that can be executed concurrently on multiple CPU cores.

The Burst Compiler optimizes C# code to generate highly efficient machine code, further enhancing the performance of your game.

In this project, you can find examples of using the Jobs System and Burst Compiler for:

- Parallel processing of game logic.
- Improving performance-critical sections like physics calculations or AI behavior.
- Using of multiple threads for multiple spawning object. 


