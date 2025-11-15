using System;
using System.Text;

namespace ScriptureMemorizer
{
    public class Word
    {
        private string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public bool IsHidden
        {
            get { return _isHidden; }
        }

        public void Hide()
        {
            _isHidden = true;
        }

        public string GetDisplayText()
        {
            if (!_isHidden)
            {
                return _text;
            }

            // When the word is hidden, replace only letters with underscores.
            // Punctuation marks remain visible.
            StringBuilder builder = new StringBuilder();

            foreach (char c in _text)
            {
                if (char.IsLetter(c))
                {
                    builder.Append('_');
                }
                else
                {
                    builder.Append(c);
                }
            }

            return builder.ToString();
        }
    }
}
