using System;
using System.Collections.Generic;

namespace JournalProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            var journal = new Journal();
            var promptGen = new PromptGenerator();

            Console.WriteLine("=== Journal Program ===");

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Write new entry");
                Console.WriteLine("2. Display journal");
                Console.WriteLine("3. Save journal (plain text)");
                Console.WriteLine("4. Load journal (plain text)");
                Console.WriteLine("5. Save as JSON (recommended)");
                Console.WriteLine("6. Load from JSON");
                Console.WriteLine("7. Export as CSV (for Excel)");
                Console.WriteLine("8. Add a custom prompt");
                Console.WriteLine("9. View available prompts");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                string opt = Console.ReadLine();
                Console.WriteLine();
                switch (opt)
                {
                    case "1":
                        WriteNewEntry(journal, promptGen);
                        break;
                    case "2":
                        DisplayJournal(journal);
                        break;
                    case "3":
                        SavePlainText(journal);
                        break;
                    case "4":
                        LoadPlainText(journal);
                        break;
                    case "5":
                        SaveJson(journal);
                        break;
                    case "6":
                        LoadJson(journal);
                        break;
                    case "7":
                        ExportCsv(journal);
                        break;
                    case "8":
                        AddPrompt(promptGen);
                        break;
                    case "9":
                        ShowPrompts(promptGen);
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }

            Console.WriteLine("Goodbye — remember: consistency is the key to journaling.");
        }

        // Write a new entry using a random prompt. Supports multi-line input ended with ::end
        static void WriteNewEntry(Journal journal, PromptGenerator promptGen)
        {
            string prompt = promptGen.GetRandomPrompt();
            Console.WriteLine($"Prompt: {prompt}");
            Console.WriteLine("Type your response (you can use multiple lines; finish with a line that contains only \"::end\"):");
            string line;
            string response = "";
            while ((line = Console.ReadLine()) != null)
            {
                if (line.Trim() == "::end") break;
                response += (response.Length == 0 ? "" : "\n") + line;
            }

            Console.Write("How were you feeling today? (optional): ");
            string mood = Console.ReadLine();

            string date = DateTime.Now.ToShortDateString();
            var entry = new Entry(date, prompt, response, mood);
            journal.AddEntry(entry);

            Console.WriteLine("Entry saved in memory.");
        }

        // Display all stored entries.
        static void DisplayJournal(Journal journal)
        {
            if (journal.Entries.Count == 0)
            {
                Console.WriteLine("There are no entries to display.");
                return;
            }

            Console.WriteLine("=== Display Journal ===");
            int i = 1;
            foreach (var e in journal.Entries)
            {
                Console.WriteLine($"--- Entry #{i} ---");
                Console.WriteLine(e.ToString());
                i++;
            }
            Console.WriteLine(journal.GetSummary());
        }

        // Save as plain text.
        static void SavePlainText(Journal journal)
        {
            Console.Write("Filename to save (e.g. myjournal.txt): ");
            string fname = Console.ReadLine();
            try
            {
                FileHandler.SaveToPlainText(fname, new List<Entry>(journal.Entries));
                Console.WriteLine($"Saved to {fname}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving: {ex.Message}");
            }
        }

        // Load from plain text (replaces in-memory journal).
        static void LoadPlainText(Journal journal)
        {
            Console.Write("Filename to load (e.g. myjournal.txt): ");
            string fname = Console.ReadLine();
            try
            {
                var loaded = FileHandler.LoadFromPlainText(fname);
                journal.ReplaceAll(loaded);
                Console.WriteLine($"Loaded {loaded.Count} entries from {fname}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading: {ex.Message}");
            }
        }

        // Save JSON.
        static void SaveJson(Journal journal)
        {
            Console.Write("JSON filename to save (e.g. myjournal.json): ");
            string fname = Console.ReadLine();
            try
            {
                FileHandler.SaveToJson(fname, new List<Entry>(journal.Entries));
                Console.WriteLine($"Saved JSON to {fname}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving JSON: {ex.Message}");
            }
        }

        // Load JSON (replaces in-memory journal).
        static void LoadJson(Journal journal)
        {
            Console.Write("JSON filename to load (e.g. myjournal.json): ");
            string fname = Console.ReadLine();
            try
            {
                var loaded = FileHandler.LoadFromJson(fname);
                journal.ReplaceAll(loaded);
                Console.WriteLine($"Loaded {loaded.Count} entries from {fname}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading JSON: {ex.Message}");
            }
        }

        // Export CSV.
        static void ExportCsv(Journal journal)
        {
            Console.Write("CSV filename to export (e.g. myjournal.csv): ");
            string fname = Console.ReadLine();
            try
            {
                FileHandler.SaveToCsv(fname, new List<Entry>(journal.Entries));
                Console.WriteLine($"Exported CSV to {fname}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error exporting CSV: {ex.Message}");
            }
        }

        // Add a custom prompt to the generator.
        static void AddPrompt(PromptGenerator pg)
        {
            Console.Write("Enter the new prompt: ");
            string p = Console.ReadLine();
            pg.AddPrompt(p);
            Console.WriteLine("Prompt added.");
        }

        // Show available prompts.
        static void ShowPrompts(PromptGenerator pg)
        {
            Console.WriteLine("Available prompts:");
            int i = 1;
            foreach (var p in pg.GetAllPrompts())
            {
                Console.WriteLine($"{i}. {p}");
                i++;
            }
        }
    }
}
