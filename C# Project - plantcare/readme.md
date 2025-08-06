# README for Plant Care Program in C#

## Overview
This is a simple console-based plant care program written in C#. The user manages a virtual plant's hydration level by watering it and monitoring its status. The program demonstrates core programming concepts, including multithreading, user input processing, and state management.

## Features
- **Hydration Management:** The plant's hydration level decreases over time, simulating real-life plant care.
- **User Interaction:** Users can check the hydration status, water the plant, or exit the program using typed commands.
- **Warning System:** Alerts the user when the plant's hydration level is low or critically low.
- **Intuitive Commands:** Simple commands include:
  - `status`
  - `water`
  - `exit`
- **Clear and Extensible Design:** Utilizes methods for hydration management and user interaction, demonstrating good programming practices.

## How to Play
1. The program runs entirely in the console.
2. Type commands to interact with the plant and manage its hydration.
3. Use `status` to check the current hydration level.
4. Type `water` to increase the hydration level.
5. Type `exit` to quit the program.

## Example Commands
- `status`
- `water`
- `exit`

## Code Structure
- **Program.cs:** Entry point that starts the hydration management process.
- **ShowHydrationStatus:** Displays the current hydration level and ASCII art representation of the plant.
- **WaterPlant:** Increases the hydration level when the user waters the plant.
- **DecreaseHydration:** Runs in a separate thread to decrease hydration over time and manage warning notifications.

## How to Run
1. Use any C# console environment or online compiler such as [dotnetfiddle.net](https://dotnetfiddle.net).
2. Paste the complete code into the editor and run it.
3. Follow on-screen prompts to interact with the plant care program.
