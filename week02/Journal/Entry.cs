using System;

namespace JournalProgram
{
    // Represents a single journal entry.
    public class Entry
    {
        // Demonstrates abstraction: private fields with public properties.
        private string _date;
        private string _prompt;
        private string _response;
        private string _mood; // additional field to exceed requirements

        public string Date { get => _date; set => _date = value; }
        public string Prompt { get => _prompt; set => _prompt = value; }
        public string Response { get => _response; set => _response = value; }
        public string Mood { get => _mood; set => _mood = value; }

        public Entry() { }

        public Entry(string date, string prompt, string response, string mood = "")
        {
            _date = date;
            _prompt = prompt;
            _response = response;
            _mood = mood;
        }

        public override string ToString()
        {
            return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\nMood: {Mood}\n";
        }
    }
}
