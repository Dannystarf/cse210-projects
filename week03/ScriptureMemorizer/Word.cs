using System;

namespace ScriptureMemorizer
{
    /// <summary>
    /// Represents a single word in a scripture that can be hidden or shown
    /// </summary>
    public class Word
    {
        private string _text;
        private bool _isHidden;

        /// <summary>
        /// Constructor for creating a word
        /// </summary>
        /// <param name="text">The word text</param>
        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        /// <summary>
        /// Hides the word
        /// </summary>
        public void Hide()
        {
            _isHidden = true;
        }

        /// <summary>
        /// Shows the word (makes it visible again)
        /// </summary>
        public void Show()
        {
            _isHidden = false;
        }

        /// <summary>
        /// Checks if the word is hidden
        /// </summary>
        /// <returns>True if the word is hidden</returns>
        public bool IsHidden()
        {
            return _isHidden;
        }

        /// <summary>
        /// Gets the display text of the word (either the word or underscores)
        /// </summary>
        /// <returns>Display text</returns>
        public string GetDisplayText()
        {
            if (_isHidden)
            {
                // Create underscores matching the length of letters in the word
                string underscores = "";
                foreach (char c in _text)
                {
                    if (char.IsLetter(c))
                    {
                        underscores += "_";
                    }
                    else
                    {
                        underscores += c; // Keep punctuation visible
                    }
                }
                return underscores;
            }
            else
            {
                return _text;
            }
        }
    }
}
