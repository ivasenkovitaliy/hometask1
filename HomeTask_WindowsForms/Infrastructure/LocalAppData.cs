using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EnglishAssistant.Entities;

namespace EnglishAssistant.Infrastructure
{
    public interface ILocalAppData
    {
        Timer TimerForShowingTestWindow { get; set; }
        List<Category> Categories { get; set; }
        List<Word> Words { get; set; }
        List<Answer> Answers { get; set; }
    }

    public sealed class LocalAppData : ILocalAppData
    {
        private static volatile LocalAppData _instance;
        private static readonly object SyncRoot = new Object();
        public Timer TimerForShowingTestWindow { get; set; }
        public List<Category> Categories { get; set; }
        public List<Word> Words { get; set; }
        public List<Answer> Answers { get; set; }


        private LocalAppData()
        {
            TimerForShowingTestWindow = new Timer { Interval = Properties.Settings.Default.TestTimerInterval };
        }

        public static LocalAppData Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new LocalAppData();
                    }
                }

                return _instance;
            }

        }

        public void CountWordsInCategories()
        {
            foreach (var category in Instance.Categories)
            {
                var wordsInCategory =
                    from word in Instance.Words
                    where word.CategoryId == category.CategoryId
                    select word;

                category.WordsInCategory = wordsInCategory.ToList().Count;  // adding in category count of words in this category
            }
        }

        public void UpdateCategoryInWordsWhileDeleting(Category categoryToDelete)
        {
            foreach (var word in Instance.Words)
            {
                if (word.CategoryId == categoryToDelete.CategoryId)
                {
                    word.Category = Instance.Categories[0].CategoryName;
                    word.CategoryId = Instance.Categories[0].CategoryId;
                }
            }
        }

        public void UpdateCategoryInWords(Category categoryToUpdate)
        {
            foreach (var word in Instance.Words)
            {
                if (word.CategoryId == categoryToUpdate.CategoryId)
                {
                    word.Category = categoryToUpdate.CategoryName;
                }
            }
        }
    }
}
