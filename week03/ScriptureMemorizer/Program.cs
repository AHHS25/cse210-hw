using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptureMemorizer
{
    class Program
    {
        /*
         * Extra creativity beyond the core requirements:
         * 1) The program uses a small library of scriptures and chooses one at random.
         * 2) The user can type a positive number to change how many words are hidden each round.
         * 3) When hiding words, the program only selects words that are not already hidden.
         */

        static void Main(string[] args)
        {
            // Create a small library of scriptures
            List<Scripture> scriptures = new List<Scripture>
            {
                new Scripture(
                    new Reference("Proverbs", 3, 5, 6),
                    "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
                    "In all thy ways acknowledge him, and he shall direct thy paths."
                ),
                new Scripture(
                    new Reference("John", 3, 16),
                    "For God so loved the world, that he gave his only begotten Son, " +
                    "that whosoever believeth in him should not perish, but have everlasting life."
                ),
                new Scripture(
                    new Reference("Alma", 37, 37),
                    "Counsel with the Lord in all thy doings, and he will direct thee for good; " +
                    "yea, when thou liest down at night lie down unto the Lord, " +
                    "that he may watch over you in your sleep; and when thou risest in the morning " +
                    "let thy heart be full of thanks unto God; and if ye do these things, " +
                    "ye shall be lifted up at the last day."
                )
            };

            Random random = new Random();
            // Pick one scripture at random from the list
            Scripture scripture = scriptures[random.Next(scriptures.Count)];

            int wordsToHideEachRound = 3; // Default number of words to hide each time

            // Main loop: continue until the scripture is completely hidden
            while (!scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine("=== Scripture Memorizer ===\n");
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();

                Console.WriteLine("Press Enter to hide more words,");
                Console.WriteLine("type a positive number to change how many words are hidden each round,");
                Console.WriteLine("or type 'quit' to end the program.");
                Console.Write("\nYour choice: ");

                string input = Console.ReadLine().Trim().ToLower();

                if (input == "quit")
                {
                    // End the program if the user types "quit"
                    return;
                }

                // Allow the user to change how many words are hidden each time
                if (int.TryParse(input, out int newAmount) && newAmount > 0)
                {
                    wordsToHideEachRound = newAmount;
                }

                // Hide a few random words that are not already hidden
                scripture.HideRandomWords(wordsToHideEachRound);
            }

            // When all words are hidden, show the final state and end
            Console.Clear();
            Console.WriteLine("=== Scripture Memorizer ===\n");
            Console.WriteLine("All words are now hidden. Final scripture:\n");
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to close the program.");
            Console.ReadLine();
        }
    }
}
