using System;

namespace ScriptureMemorizer
{
    public class Reference
    {
        private string _book;
        private int _chapter;
        private int _startVerse;
        private int? _endVerse;

        // Constructor for a single verse, for example: "John 3:16"
        public Reference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = verse;
            _endVerse = null;
        }

        // Constructor for a verse range, for example: "Proverbs 3:5-6"
        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = startVerse;
            _endVerse = endVerse;
        }

        public override string ToString()
        {
            if (_endVerse.HasValue && _endVerse.Value != _startVerse)
            {
                return $"{_book} {_chapter}:{_startVerse}-{_endVerse.Value}";
            }
            else
            {
                return $"{_book} {_chapter}:{_startVerse}";
            }
        }
    }
}
