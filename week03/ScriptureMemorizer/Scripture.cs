using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private Random _random;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();
            _random = new Random();

            // Split the text into words by spaces
            string[] parts = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string part in parts)
            {
                _words.Add(new Word(part));
            }
        }

        public string GetDisplayText()
        {
            StringBuilder builder = new StringBuilder();

            // First line: reference
            builder.AppendLine(_reference.ToString());

            // Then the scripture text, with hidden/visible words
            for (int i = 0; i < _words.Count; i++)
            {
                builder.Append(_words[i].GetDisplayText());

                if (i < _words.Count - 1)
                {
                    builder.Append(' ');
                }
            }

            return builder.ToString();
        }

        public void HideRandomWords(int numberToHide)
        {
            // Create a list of indexes for words that are not yet hidden
            List<int> visibleIndexes = new List<int>();

            for (int i = 0; i < _words.Count; i++)
            {
                if (!_words[i].IsHidden)
                {
                    visibleIndexes.Add(i);
                }
            }

            if (visibleIndexes.Count == 0)
            {
                return;
            }

            // We cannot hide more words than the number of visible words
            int wordsToHide = Math.Min(numberToHide, visibleIndexes.Count);

            for (int i = 0; i < wordsToHide; i++)
            {
                int randomPosition = _random.Next(visibleIndexes.Count);
                int wordIndex = visibleIndexes[randomPosition];

                _words[wordIndex].Hide();

                // Remove this index so we do not hide the same word twice in this round
                visibleIndexes.RemoveAt(randomPosition);
            }
        }

        public bool IsCompletelyHidden()
        {
            // Return true only if every word is hidden
            return _words.All(w => w.IsHidden);
        }
    }
}
