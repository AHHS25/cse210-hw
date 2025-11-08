using System;
using System.Collections.Generic;

namespace JournalProgram
{
    // Generates random prompts. Kept separate to demonstrate abstraction and reusability.
    public class PromptGenerator
    {
        private List<string> _prompts;
        private Random _rng;

        public PromptGenerator()
        {
            _rng = new Random();
            _prompts = new List<string>()
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "What am I grateful for today?",
                "What challenge did I face today and what did I learn?",
                "If I could repeat one moment from today, what would it be and why?",
                // extra prompts
                "What small act of kindness did I see or do today?",
                "What surprised me today?"
            };
        }

        public string GetRandomPrompt()
        {
            int i = _rng.Next(_prompts.Count);
            return _prompts[i];
        }

        public void AddPrompt(string prompt)
        {
            if (!string.IsNullOrWhiteSpace(prompt))
                _prompts.Add(prompt.Trim());
        }

        public IReadOnlyList<string> GetAllPrompts() => _prompts.AsReadOnly();
    }
}
