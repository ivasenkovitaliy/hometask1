using System;
using System.Data;
using System.Data.SqlServerCe;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using HomeTask_WindowsForms.DAL;

namespace HomeTask_WindowsForms
{
    
    static class Program
    {
        // using to run single application   ---------------------------------
        
        private static Mutex _mInstance;
        private const string MAppName = "Testing Words";
        
        [DllImport("User32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("User32.dll")]
        //[return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        
        [DllImport("User32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        // -------------------------------------
        
        // using to ask unactive user time in seconds -----------------
        [StructLayout(LayoutKind.Sequential)]
        struct LASTINPUTINFO
        {
            public static readonly int SizeOf = Marshal.SizeOf(typeof(LASTINPUTINFO));

            [MarshalAs(UnmanagedType.U4)]
            public int cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public UInt32 dwTime;
        }

        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
        static public int GetLastInputTime()
        {
            int idleTime = 0;
            LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = Marshal.SizeOf(lastInputInfo);
            lastInputInfo.dwTime = 0;

            int envTicks = Environment.TickCount;
            if (GetLastInputInfo(ref lastInputInfo))
            {
                int lastInputTick = (int)lastInputInfo.dwTime;

                idleTime = envTicks - lastInputTick;
            }
            return ((idleTime > 0) ? (idleTime / 1000) : idleTime);
        }
        //-----------------------------------------------------------
        
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
             
            bool tryCreateNewApp;
            _mInstance = new Mutex(true, MAppName, out tryCreateNewApp);
            var tempHandle = FindWindow(null, MAppName);

            Properties.Settings.Default.ProgrammWindowName = MAppName;
            
            if (tryCreateNewApp)
            {
                var baseiInitializer = new DataBaseInitializer();
                baseiInitializer.CreateDb();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            else
            {   
                ShowWindow(tempHandle, 5);
                SetForegroundWindow(tempHandle);
            }
        }
    }
}
