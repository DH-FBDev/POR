using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    // Define named constants for magic numbers
    private const int InitialHydrationLevel = 100;
    private const int HydrationDecrementIntervalMs = 5000;
    private const int HydrationDecrementAmount = 1;
    private const int LowHydrationWarningThreshold = 50;
    private const int CriticalHydrationWarningThreshold = 15;
    private const int WaterIncrementAmount = 15;
    private const int MaxHydrationLevelForWatering = 85;

    static int hydrationLevel = InitialHydrationLevel; // Initial hydration level
    static bool running = true;
    static bool lowWarningDisplayed = false; // For 50% warning
    static bool criticalWarningDisplayed = false; // For 15% warning

    static void Main(string[] args)
    {
        // Start the hydration decrease in a separate task
        Task.Run(() => DecreaseHydration());

        Console.WriteLine("Welcome to the Plant Care Program!");
        Console.WriteLine("Type 'status' to check hydration, 'water' to water the plant, or 'exit' to quit.");

        while (running)
        {
            string input = Console.ReadLine().Trim().ToLower();

            switch (input)
            {
                case "status":
                    ShowHydrationStatus();
                    break;
                case "water":
                    WaterPlant();
                    break;
                case "exit":
                    Console.WriteLine("Ending Program.");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Unknown command. Please type 'status', 'water', or 'exit'.");
                    break;
            }
        }
    }

    static void ShowHydrationStatus()
    {
        Console.WriteLine(@"
                .--.
              .'_\/_'.
              '. /\ .'
                '||'
                 || /\
              /\ ||//\)
             (/\\||/
          ______\||/_______
        ");
        Console.WriteLine($"Hydration Level: {hydrationLevel}%");
    }

    static void WaterPlant()
    {
        if (hydrationLevel <= 0)
        {
            Console.WriteLine("The plant is already dead. You cannot water it.");
            return;
        }

        if (hydrationLevel <= MaxHydrationLevelForWatering)
        {
            hydrationLevel += WaterIncrementAmount;
            Console.WriteLine($"You watered the plant! Hydration level increased by {WaterIncrementAmount}%.");
        }
        else
        {
            Console.WriteLine("The plant is already well-hydrated!");
        }
    }

    static void DecreaseHydration()
    {
        while (running)
        {
            Thread.Sleep(HydrationDecrementIntervalMs); // Decrease hydration every 5 seconds
            if (hydrationLevel > 0)
            {
                hydrationLevel -= HydrationDecrementAmount;
            }

            if (hydrationLevel <= 0)
            {
                Console.WriteLine("The plant is dead. Ending Program.");
                running = false; // End the program
            }
            else if (hydrationLevel <= CriticalHydrationWarningThreshold && !criticalWarningDisplayed)
            {
                Console.WriteLine("Warning: Hydration level critically low!");
                criticalWarningDisplayed = true;
            }
            else if (hydrationLevel > CriticalHydrationWarningThreshold)
            {
                criticalWarningDisplayed = false;
            }

            if (hydrationLevel <= LowHydrationWarningThreshold && !lowWarningDisplayed)
            {
                Console.WriteLine("Warning: Hydration level is low!");
                lowWarningDisplayed = true;
            }
            else if (hydrationLevel > LowHydrationWarningThreshold)
            {
                lowWarningDisplayed = false;
            }
        }
    }
}