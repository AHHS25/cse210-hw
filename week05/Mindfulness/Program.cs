using System;

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;

        while (choice != 4)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select an option (1-4): ");

            string input = Console.ReadLine();

            if (!int.TryParse(input, out choice))
            {
                choice = 0;
            }

            if (choice == 1)
            {
                BreathingActivity breathing = new BreathingActivity(
                    "Breathing Activity",
                    "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
                );
                breathing.Run();
            }
            else if (choice == 2)
            {
                ReflectionActivity reflection = new ReflectionActivity(
                    "Reflection Activity",
                    "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
                );
                reflection.Run();
            }
            else if (choice == 3)
            {
                ListingActivity listing = new ListingActivity(
                    "Listing Activity",
                    "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
                );
                listing.Run();
            }
            else if (choice == 4)
            {
                Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
                Console.WriteLine("Press Enter to exit.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid option. Press Enter and try again.");
                Console.ReadLine();
            }
        }
    }
}
