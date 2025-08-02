using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    /// <summary>
    /// Represents a scripture with its reference and text, managing word hiding functionality
    /// </summary>
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _words;

        /// <summary>
        /// Constructor for creating a scripture with reference and text
        /// </summary>
        /// <param name="reference">The scripture reference</param>
        /// <param name="text">The scripture text</param>
        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();

            // Split the text into words and create Word objects
            string[] wordArray = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in wordArray)
            {
                _words.Add(new Word(word));
            }
        }

        /// <summary>
        /// Hides a specified number of random words that aren't already hidden
        /// </summary>
        /// <param name="numberToHide">Number of words to hide</param>
        public void HideRandomWords(int numberToHide)
        {
            Random random = new Random();
            List<Word> visibleWords = _words.Where(word => !word.IsHidden()).ToList();

            // Don't try to hide more words than are available
            int wordsToHide = Math.Min(numberToHide, visibleWords.Count);

            for (int i = 0; i < wordsToHide; i++)
            {
                if (visibleWords.Count > 0)
                {
                    int randomIndex = random.Next(visibleWords.Count);
                    visibleWords[randomIndex].Hide();
                    visibleWords.RemoveAt(randomIndex);
                }
            }
        }

        /// <summary>
        /// Gets the display text of the scripture with reference
        /// </summary>
        /// <returns>Formatted scripture text</returns>
        public string GetDisplayText()
        {
            string wordsText = string.Join(" ", _words.Select(word => word.GetDisplayText()));
            return $"{_reference.GetDisplayText()} {wordsText}";
        }

        /// <summary>
        /// Checks if all words in the scripture are hidden
        /// </summary>
        /// <returns>True if all words are hidden</returns>
        public bool IsCompletelyHidden()
        {
            return _words.All(word => word.IsHidden());
        }

        /// <summary>
        /// Gets the count of hidden words
        /// </summary>
        /// <returns>Number of hidden words</returns>
        public int GetHiddenWordCount()
        {
            return _words.Count(word => word.IsHidden());
        }

        /// <summary>
        /// Gets the total count of words
        /// </summary>
        /// <returns>Total number of words</returns>
        public int GetTotalWordCount()
        {
            return _words.Count;
        }
    }
}
