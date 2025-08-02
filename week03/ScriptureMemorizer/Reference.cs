using System;

namespace ScriptureMemorizer
{
    /// <summary>
    /// Represents a scripture reference (e.g., "John 3:16" or "Proverbs 3:5-6")
    /// </summary>
    public class Reference
    {
        private string _book;
        private int _chapter;
        private int _verse;
        private int _endVerse;

        /// <summary>
        /// Constructor for a single verse reference
        /// </summary>
        /// <param name="book">Book name</param>
        /// <param name="chapter">Chapter number</param>
        /// <param name="verse">Verse number</param>
        public Reference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _verse = verse;
            _endVerse = verse; // Single verse, so end verse is the same
        }

        /// <summary>
        /// Constructor for a verse range reference
        /// </summary>
        /// <param name="book">Book name</param>
        /// <param name="chapter">Chapter number</param>
        /// <param name="startVerse">Starting verse number</param>
        /// <param name="endVerse">Ending verse number</param>
        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            _book = book;
            _chapter = chapter;
            _verse = startVerse;
            _endVerse = endVerse;
        }

        /// <summary>
        /// Gets the formatted display text of the reference
        /// </summary>
        /// <returns>Formatted reference string</returns>
        public string GetDisplayText()
        {
            if (_verse == _endVerse)
            {
                return $"{_book} {_chapter}:{_verse}";
            }
            else
            {
                return $"{_book} {_chapter}:{_verse}-{_endVerse}";
            }
        }
    }
}
