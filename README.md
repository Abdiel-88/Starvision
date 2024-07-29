# Starvision

## Capstone Project at Holberton School

### Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Team](#team)
- [Technologies](#technologies)
- [Setup](#setup)
- [Usage](#usage)
- [Deployable](#deployable)

### Overview
Starvision is an immersive simulation of the solar system developed using the Unity Game Engine. This project serves as a capstone for our Software Engineer program at Holberton School. The simulation provides detailed information about the planets and the sun, including rotation, speed, and distance, sourced from NASA databases.

### Features
- Realistic simulation of the solar system
- Detailed information about each planet and the sun
- Interactive user interface
- JSON file integration for dynamic data updates
- Educational content based on NASA data

### Team
- **Raphael Santos**: Backend, Database Manager
- **Abdiel**: Dev Lead
- **Ladie**: Frontend, Backend

### Technologies
- Unity Game Engine
- C#
- HTML
- CSS
- JavaScript
- JSON
- Bootstrap

### Setup
To get a local copy up and running, follow these simple steps:

#### Prerequisites
- Unity Game Engine installed
- Visual Studio or another C# IDE
- Git

#### Installation
1. Clone the repository:
    ```sh
    git clone git@github.com:Abdiel-88/Starvision.git
    ```
2. Open the project in Unity:
    ```sh
    cd starvision
    open -a Unity .
    ```
3. Set up the data:
    - Ensure your JSON data file is in place.
    - Place the JSON file in the `Assets/StreamingAssets` folder of the Unity project.
4. Configure data loading:
    - Update the data loading scripts in the Unity project to read from the JSON file.

### Usage
Run the simulation through Unity by hitting the play button. Interact with the planets to view detailed information and explore the solar system.

### Deployable
For a deployable version of this project using WEBGL please visit this repository: https://github.com/GoldenHatchet15/StarVision-full_-project

