using System.Collections.Generic;
using Timer = System.Windows.Forms.Timer;

namespace HomeTask_WindowsForms
{
    class LocalRepository
    {
        private static LocalRepository _instance = null;
        public static Timer TimerForShowingTestWindow { get; set; }
        public static HashSet<Category> Categories { get; set; }
        public static List<Word> Words { get; set; }
        
        protected LocalRepository()
        {
        }

        public static LocalRepository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LocalRepository();
                TimerForShowingTestWindow = new Timer();
                TimerForShowingTestWindow.Interval = 180000;
            }
            return _instance;
        }
        
    }
}
