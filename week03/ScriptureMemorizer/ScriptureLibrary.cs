using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    /// <summary>
    /// Manages a library of scriptures for random selection
    /// This exceeds requirements by providing multiple scriptures
    /// </summary>
    public class ScriptureLibrary
    {
        private List<Scripture> _scriptures;
        private Random _random;

        /// <summary>
        /// Constructor that initializes the scripture library
        /// </summary>
        public ScriptureLibrary()
        {
            _random = new Random();
            _scriptures = new List<Scripture>();
            LoadScriptures();
        }

        /// <summary>
        /// Loads a collection of scriptures into the library
        /// </summary>
        private void LoadScriptures()
        {
            // Add various scriptures to the library
            _scriptures.Add(new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
            ));

            _scriptures.Add(new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
            ));

            _scriptures.Add(new Scripture(
                new Reference("1 Nephi", 3, 7),
                "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."
            ));

            _scriptures.Add(new Scripture(
                new Reference("Joshua", 1, 9),
                "Have not I commanded thee? Be strong and of a good courage; be not afraid, neither be thou dismayed: for the Lord thy God is with thee whithersoever thou goest."
            ));

            _scriptures.Add(new Scripture(
                new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me."
            ));

            _scriptures.Add(new Scripture(
                new Reference("2 Timothy", 3, 16, 17),
                "All scripture is given by inspiration of God, and is profitable for doctrine, for reproof, for correction, for instruction in righteousness: That the man of God may be perfect, thoroughly furnished unto all good works."
            ));
        }

        /// <summary>
        /// Gets a random scripture from the library
        /// </summary>
        /// <returns>A random scripture</returns>
        public Scripture GetRandomScripture()
        {
            if (_scriptures.Count == 0)
            {
                throw new InvalidOperationException("No scriptures available in the library.");
            }

            int randomIndex = _random.Next(_scriptures.Count);
            return _scriptures[randomIndex];
        }

        /// <summary>
        /// Gets the total number of scriptures in the library
        /// </summary>
        /// <returns>Number of scriptures</returns>
        public int GetScriptureCount()
        {
            return _scriptures.Count;
        }
    }
}
