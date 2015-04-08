namespace EnglishAssistant.Infrastructure
{
    public static class Settings
    {
        public static int TestTimerInterval { get; private set; }

        public static string ProgrammWindowName { get; private set; }

        public static string ConnectionString { get; private set; }

        public static string YandexTranslatorApiKey { get; private set; }

        public static int MinAllowedWordsForTest { get; private set; }

        static Settings()
        {
            TestTimerInterval = Properties.Settings.Default.TestTimerInterval;
            ProgrammWindowName = Properties.Settings.Default.ProgrammWindowName;
            ConnectionString = Properties.Settings.Default.connectionString;
            YandexTranslatorApiKey = Properties.Settings.Default.YandexTranslatorApiKey;
            MinAllowedWordsForTest = Properties.Settings.Default.MinAllowedWordsForTest;
        }
    }
}
