README for Text-Based Adventure Game in C#
Overview
This is a simple console-based text adventure game written in C#. The player navigates through various locations, interacts with items, and manages an inventory using typed commands. The game demonstrates core programming concepts, including object-oriented design, user input processing, and state management.

Features
Multiple Locations: Move between interconnected locations such as Meadow Camp, Forest, Desert, Mountain, River, and Town Gate.
Item Interaction: Pick up, drop, and examine items found in locations.
Inventory System: View and manage items collected during the adventure.
User Commands: Intuitive commands like:
look around
look at [item]
pick up [item]
drop [item]
inventory
Clear and Extensible Design: Utilizes classes for Game, Location, Item, and Inventory, demonstrating good object-oriented programming practices.
How to Play
The game runs entirely in the console.
Type commands to interact with the environment and control your character.
Use help to display the list of available commands.
Navigate using directions (north, south, east, west) typed directly.
Type exit to quit the game.
Example Commands
look around
pick up sword
inventory
look at sword
drop sword
north
exit
Code Structure
Program.cs: Entry point that starts the game.
Game: Contains the game loop, command parsing, and game state management.
Location: Represents places the player can visit, with connected locations and items.
Item: Represents objects that can be found and stored in inventory.
Inventory: Manages the player's collected items.
How to Run
Use any C# console environment or online compiler such as dotnetfiddle.net.
Paste the complete code into the editor and run it.
Follow on-screen prompts to interact with the game.
