using System;
using System.Collections.Generic;

namespace Journal
{
    /// <summary>
    /// Manages journal prompts and provides random prompt selection
    /// </summary>
    public class PromptGenerator
    {
        private List<string> _prompts;
        private Random _random;

        public PromptGenerator()
        {
            _random = new Random();
            InitializePrompts();
        }

        private void InitializePrompts()
        {
            _prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?",
                "What am I most grateful for today?",
                "What challenge did I overcome today?",
                "What new thing did I learn today?",
                "How did I help someone else today?",
                "What made me smile or laugh today?",
                "What goal did I make progress on today?",
                "What would I tell my past self about today?",
                "What am I looking forward to tomorrow?",
                "How did I grow as a person today?",
                "What moment today will I remember in 10 years?"
            };
        }

        public string GetRandomPrompt()
        {
            int index = _random.Next(_prompts.Count);
            return _prompts[index];
        }

        public void AddCustomPrompt(string prompt)
        {
            if (!string.IsNullOrWhiteSpace(prompt) && !_prompts.Contains(prompt))
            {
                _prompts.Add(prompt);
            }
        }

        public List<string> GetAllPrompts()
        {
            return new List<string>(_prompts);
        }

        public int PromptCount => _prompts.Count;
    }
}
