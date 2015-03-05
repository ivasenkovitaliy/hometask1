using System;
using System.Collections.Generic;
using System.Linq;
using Timer = System.Windows.Forms.Timer;

namespace HomeTask_WindowsForms
{
    public sealed class LocalAppData
    {
        private static volatile LocalAppData _instance;
        private static readonly object SyncRoot = new Object();
        public static Timer TimerForShowingTestWindow { get; set; }
        public static List<Category> Categories { get; set; }
        public static List<Word> Words { get; set; }
        public static List<Answer> Answers { get; set; }
        
        
        private LocalAppData()
        {
            TimerForShowingTestWindow = new Timer();
            TimerForShowingTestWindow.Interval = Properties.Settings.Default.TestTimerInterval;
        }

        public static LocalAppData Instance()
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
        
        public static void CountWordsInCategories()
        {
            foreach (var category in Categories)
            {
                var wordsInCategory =
                    from word in Words
                    where word.CategoryId == category.CategoryId
                    select word;
                
                category.WordsInCategory = wordsInCategory.ToList().Count;  // adding in category count of words in this category
            }
        }

        public static void UpdateCategoryInWordsWhileDeleting(Category categoryToDelete)
        {
            foreach (var word in Words)
            {
                if (word.CategoryId==categoryToDelete.CategoryId)
                {
                    word.Category = Categories[0].CategoryName;
                    word.CategoryId = Categories[0].CategoryId;
                }
            }
        }

        public static void UpdateCategoryInWords(Category categoryToUpdate)
        {
            foreach (var word in Words)
            {
                if (word.CategoryId == categoryToUpdate.CategoryId)
                {
                    word.Category = categoryToUpdate.CategoryName;
                }
            }
        }
    }
}
