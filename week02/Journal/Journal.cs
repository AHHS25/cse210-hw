using System;
using System.Collections.Generic;

namespace JournalProgram
{
    // Class that stores the collection of entries and operations on the journal.
    public class Journal
    {
        private List<Entry> _entries;

        // Expose entries as a read-only list to respect encapsulation.
        public IReadOnlyList<Entry> Entries => _entries.AsReadOnly();

        public Journal()
        {
            _entries = new List<Entry>();
        }

        public void AddEntry(Entry entry)
        {
            _entries.Add(entry);
        }

        public void Clear()
        {
            _entries.Clear();
        }

        // Replace all entries with a new list (used when loading from file).
        public void ReplaceAll(List<Entry> newEntries)
        {
            _entries = newEntries ?? new List<Entry>();
        }

        public string GetSummary()
        {
            return $"Total entries: {_entries.Count}";
        }
    }
}
