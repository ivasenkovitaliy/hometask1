using System.Collections.Generic;
using Timer = System.Windows.Forms.Timer;

namespace HomeTask_WindowsForms
{
    public sealed class LocalAppData
    {
        private static LocalAppData _instance;
        public static Timer TimerForShowingTestWindow { get; set; }
        public static List<Category> Categories { get; set; }
        public static List<Word> Words { get; set; }
        public static List<Answer> Answers { get; set; }
        
        private LocalAppData()
        {
        }
        public static LocalAppData GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LocalAppData();
                
                TimerForShowingTestWindow = new Timer();
                TimerForShowingTestWindow.Interval = Properties.Settings.Default.TestTimerInterval;
            }

            return _instance;
        }
        public static Category GetCategoryWithCategoryName(string categoryName)
        {
            return Categories.Find(r => r.CategoryName.Equals(categoryName));
        }
        public static int[] GetAnswersCount(List<Answer> answers)
        {
            int rightAnswers = 0;
            int wrongAnswers = 0;
            int cancelledAnswers = 0;

            int[] arr = new int[3];
            
            foreach (var answer in answers)
            {
                if (answer.AnswerValue == 0)
                    wrongAnswers++;
                if (answer.AnswerValue == 1)
                    rightAnswers++;
                if (answer.AnswerValue == 2)
                    cancelledAnswers++;
            }

            arr = new[] { rightAnswers, wrongAnswers, cancelledAnswers };

            return arr;
        }
    }
}
