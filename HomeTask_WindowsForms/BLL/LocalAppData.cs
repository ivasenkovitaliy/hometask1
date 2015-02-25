﻿using System;
using System.Collections.Generic;
using System.Linq;
using Timer = System.Windows.Forms.Timer;

namespace HomeTask_WindowsForms
{
    public sealed class LocalAppData
    {
        private static volatile LocalAppData _instance;
        private static object syncRoot = new Object();
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
                    lock (syncRoot)
                    {
                        if (_instance == null)
                            _instance = new LocalAppData();
                    }
                }

                return _instance;
        }

        public static int[] GetAnswersCount(IEnumerable<Answer> answers)
        {
            int rightAnswers = 0;
            int wrongAnswers = 0;
            int cancelledAnswers = 0;

            foreach (var answer in answers)
            {
                if (answer.AnswerValue == 0)
                    wrongAnswers++;
                if (answer.AnswerValue == 1)
                    rightAnswers++;
                if (answer.AnswerValue == 2)
                    cancelledAnswers++;
            }

            var answersArr = new[] { rightAnswers, wrongAnswers, cancelledAnswers };

            return answersArr;
        }
        
        public static void CountWordsInCategories()
        {
            foreach (var category in LocalAppData.Categories)
            {
                var wordsInCategory =
                    from word in LocalAppData.Words
                    where word.Category == category.CategoryName
                    select word;
                
                category.WordsInCategory = wordsInCategory.ToList().Count;  // adding in category count of words in this category
            }
        }
    }
}
