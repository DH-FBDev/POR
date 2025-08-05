using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create and start the game
        Game game = new Game();
        game.Start();
    }
}

class Game
{
    private Location currentLocation;
    private Inventory inventory;

    public Game()
    {
        // Initialize the game locations with name and description
        Location meadowCamp = new Location("Meadow Camp", "You are at a peaceful meadow camp surrounded by tall trees and wildflowers. A gentle breeze rustles the leaves. There are paths leading north, south, west and east.");
        Location forest = new Location("Forest", "You are in a dense forest. The trees are tall, and the sunlight barely reaches the ground. You can hear birds chirping. The only path you can see leads back to the meadow.");
        Location desert = new Location("Desert", "You are in a vast desert. The sun is blazing, and the sand stretches endlessly in all directions. Better turn back north towards the meadow.");
        Location mountain = new Location("Mountain", "You are on a rocky mountain path. The air is thin, and you can see the valley below. It's a nice view but there is only the way back west from here.");
        Location river = new Location("River", "You are by a flowing river. The water is clear, and you can see fish swimming beneath the surface. You can go back east or further west from here.");
        Location townGate = new Location("Town Gate", "You are in front of the town gate. The wall looks thick and sturdy and the gate is solid wood and metal. It doesn't smell that good here. The gate is locked and you can only go back east from here.");

        // Add item to pick up
        meadowCamp.AddItem(new Item("Sword", "A sharp sword with a length of 90 cm. It has a sturdy guard, a decorative pommel, and comes with a sheath for protection."));

        // Set connections between locations, defining directions player can move
        meadowCamp.AddConnection("north", forest);
        meadowCamp.AddConnection("south", desert);
        meadowCamp.AddConnection("east", mountain);
        meadowCamp.AddConnection("west", river);

        forest.AddConnection("south", meadowCamp);
        desert.AddConnection("north", meadowCamp);
        mountain.AddConnection("west", meadowCamp);
        river.AddConnection("east", meadowCamp);
        river.AddConnection("west", townGate);
        townGate.AddConnection("east", river);

        // Set starting location and create an empty inventory
        currentLocation = meadowCamp;
        inventory = new Inventory();
    }

    // Main game loop that processes player commands
    public void Start()
    {
        string input;
        Console.WriteLine("Type 'help' to show commands.");

        while (true)
        {
            Console.WriteLine($"You are at the {currentLocation.Name}.");
            Console.Write($"\n> ");
            input = Console.ReadLine().ToLower();

            // Process player commands
            if (input == "exit")
            {
                // Exit game
                Console.WriteLine("Thanks for playing!");
                break;
            }
            else if (input == "help")
            {
                // Show available commands
                ShowHelp();
            }
            else if (input == "look around")
            {
                // Show current location description and visible items
                Console.WriteLine(currentLocation.Description);
                currentLocation.ShowItems();
            }
            else if (input.StartsWith("look at "))
            {
                // Look at the description of a specified item, either in location or inventory
                string itemName = input.Substring(8); // "look at " length is 8
                if (currentLocation.TryLookAt(itemName, out string itemDescription))
                {
                    Console.WriteLine(itemDescription);
                }
                else if (inventory.TryLookAt(itemName, out itemDescription))
                {
                    Console.WriteLine(itemDescription);
                }
                else
                {
                    Console.WriteLine($"There is no {itemName} here.");
                }
            }
            else if (input.StartsWith("pick up "))
            {
                // Pick up an item from the current location and add it to the inventory
                string itemName = input.Substring(8);
                if (currentLocation.TryPickUp(itemName, inventory))
                {
                    Console.WriteLine($"You picked up the {itemName}.");
                }
                else
                {
                    Console.WriteLine($"There is no {itemName} here.");
                }
            }
            else if (input.StartsWith("drop "))
            {
                // Drop an item from inventory onto the current location
                string itemName = input.Substring(5);
                if (inventory.TryDrop(itemName, currentLocation))
                {
                    Console.WriteLine($"You dropped the {itemName}.");
                }
                else
                {
                    Console.WriteLine($"You don't have a {itemName} in your inventory.");
                }
            }
            else if (input == "inventory")
            {
                // Display items currently held in inventory
                inventory.ShowItems();
            }
            else
            {
                // Try to move the player in the specified direction
                if (currentLocation.TryMove(input, out Location newLocation))
                {
                    currentLocation = newLocation;
                }
                else
                {
                    Console.WriteLine("That won't work.");
                }
            }
        }
    }

    // Displays help text for player commands
    private void ShowHelp()
    {
        Console.WriteLine("Available commands:");
        Console.WriteLine(" - look around: Describe your current location.");
        Console.WriteLine(" - look at [item]: Get a description of an item.");
        Console.WriteLine(" - pick up [item]: Pick up an item from the ground.");
        Console.WriteLine(" - drop [item]: Drop an item from your inventory.");
        Console.WriteLine(" - inventory: Check your items.");
        Console.WriteLine(" - exit: Quit the game.");
    }
}

class Location
{
    // Location name and description properties
    public string Name { get; private set; }
    public string Description { get; private set; }

    private Dictionary<string, Location> connections;  // Direction-to-location mapping for movement
    private List<Item> items;  // List of items present in this location

    public Location(string name, string description)
    {
        Name = name;
        Description = description;
        connections = new Dictionary<string, Location>();
        items = new List<Item>();
    }

    // Adds a connection to another location in a specific direction (e.g., "north")
    public void AddConnection(string direction, Location location)
    {
        connections[direction] = location;
    }

    // Adds an item to the location
    public void AddItem(Item item)
    {
        items.Add(item);
    }

    // Displays items currently in this location
    public void ShowItems()
    {
        if (items.Count > 0)
        {
            Console.WriteLine("You see the following items:");
            foreach (var item in items)
            {
                Console.WriteLine($" - {item.Name}");
            }
        }
        else
        {
            Console.WriteLine("There are no items here.");
        }
    }

    // Attempt to pick up an item by name and add it to the player's inventory
    public bool TryPickUp(string itemName, Inventory inventory)
    {
        Item item = items.Find(i => i.Name.ToLower() == itemName);
        if (item != null)
        {
            items.Remove(item);
            inventory.AddItem(item);
            return true;
        }
        return false;
    }

    // Attempt to look at an item in this location and get its description
    public bool TryLookAt(string itemName, out string description)
    {
        Item item = items.Find(i => i.Name.ToLower() == itemName);
        if (item != null)
        {
            description = item.Description;
            return true;
        }
        description = null;
        return false;
    }

    // Attempt to move in a specified direction; if possible, returns the connected location
    public bool TryMove(string direction, out Location newLocation)
    {
        return connections.TryGetValue(direction, out newLocation);
    }
}

class Item
{
    // Properties for the item's name and description
    public string Name { get; private set; }
    public string Description { get; private set; }

    // Create a new item with a name and description
    public Item(string name, string description)
    {
        Name = name;
        Description = description;
    }
}

class Inventory
{
    // List to store items held by the player
    private List<Item> items;

    public Inventory()
    {
        items = new List<Item>();
    }

    // Add an item to the inventory
    public void AddItem(Item item)
    {
        items.Add(item);
    }

    // Try to drop an item from inventory onto a location
    public bool TryDrop(string itemName, Location location)
    {
        Item item = items.Find(i => i.Name.ToLower() == itemName);
        if (item != null)
        {
            items.Remove(item);
            location.AddItem(item);
            return true;
        }
        return false;
    }

    // Try to get an item's description from the inventory
    public bool TryLookAt(string itemName, out string description)
    {
        Item item = items.Find(i => i.Name.ToLower() == itemName);
        if (item != null)
        {
            description = item.Description;
            return true;
        }
        description = null;
        return false;
    }

    // Displays all items currently in the inventory
    public void ShowItems()
    {
        if (items.Count > 0)
        {
            Console.WriteLine("You have the following items:");
            foreach (var item in items)
            {
                Console.WriteLine($" - {item.Name}");
            }
        }
        else
        {
            Console.WriteLine("Your inventory is empty.");
        }
    }
}