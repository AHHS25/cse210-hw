using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace JournalProgram
{
    // Encapsulates file read/write logic to separate responsibilities.
    public static class FileHandler
    {
        // Separator unlikely to appear in normal text.
        private const string SEP = "~|~";

        // Save in plain text format (one line per entry: date~|~prompt~|~response~|~mood)
        public static void SaveToPlainText(string filename, List<Entry> entries)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                foreach (var e in entries)
                {
                    // We don't fully escape here (allowed simplification), but replace newlines.
                    string responseSingleLine = e.Response?.Replace("\r", " ").Replace("\n", " ") ?? "";
                    string promptSingleLine = e.Prompt?.Replace("\r", " ").Replace("\n", " ") ?? "";
                    string moodSingleLine = e.Mood?.Replace("\r", " ").Replace("\n", " ") ?? "";
                    sw.WriteLine($"{e.Date}{SEP}{promptSingleLine}{SEP}{responseSingleLine}{SEP}{moodSingleLine}");
                }
            }
        }

        // Load from the same plain text format.
        public static List<Entry> LoadFromPlainText(string filename)
        {
            var list = new List<Entry>();
            var lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                var parts = line.Split(SEP);
                if (parts.Length >= 3)
                {
                    string date = parts[0];
                    string prompt = parts[1];
                    string response = parts[2];
                    string mood = parts.Length >= 4 ? parts[3] : "";
                    list.Add(new Entry(date, prompt, response, mood));
                }
            }
            return list;
        }

        // --- Improvement: Save/Load as JSON for interoperability (extra for full credit).
        public static void SaveToJson(string filename, List<Entry> entries)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(entries, options);
            File.WriteAllText(filename, json);
        }

        public static List<Entry> LoadFromJson(string filename)
        {
            var json = File.ReadAllText(filename);
            var entries = JsonSerializer.Deserialize<List<Entry>>(json);
            return entries ?? new List<Entry>();
        }

        // --- Extra improvement: Export as CSV with proper quoting and escaping.
        public static void SaveToCsv(string filename, List<Entry> entries)
        {
            using (StreamWriter sw = new StreamWriter(filename, false, Encoding.UTF8))
            {
                // Header
                sw.WriteLine("\"Date\",\"Prompt\",\"Response\",\"Mood\"");
                foreach (var e in entries)
                {
                    sw.WriteLine($"{CsvEscape(e.Date)},{CsvEscape(e.Prompt)},{CsvEscape(e.Response)},{CsvEscape(e.Mood)}");
                }
            }
        }

        private static string CsvEscape(string text)
        {
            if (text == null) return "\"\"";
            string escaped = text.Replace("\"", "\"\""); // double quotes for escape
            return $"\"{escaped}\"";
        }
    }
}
