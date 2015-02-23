using System;
using System.Data;
using System.Data.SqlServerCe;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

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
            


            if (tryCreateNewApp)
            {
                var directoryName = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                var dbFileName = System.IO.Path.Combine(directoryName, "programm_data.sdf");
                
                if (!File.Exists(dbFileName))
                {
                    var connectionStr = @"Data Source = " + dbFileName;

                    SqlCeEngine engine = new SqlCeEngine(connectionStr);
                    engine.CreateDatabase();

                    using (var connection = new SqlCeConnection(connectionStr))
                    {
                        connection.Open();

                        using (var query = connection.CreateCommand())
                        {
                            query.CommandText = @"CREATE TABLE Word (Id INT IDENTITY(1,1) PRIMARY KEY, Original NVARCHAR(40) NOT NULL, Translate NVARCHAR(130) NOT NULL, Category INT NOT NULL);";
                            query.ExecuteNonQuery();
                        }
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO Word (Original, Translate, Category) VALUES (@Original, @Translate, @Category)";
                            
                            command.Parameters.Add("Original", SqlDbType.NVarChar, 40).Value = "snow";
                            command.Parameters.Add("Translate", SqlDbType.NVarChar, 40).Value = "снег";
                            command.Parameters.Add("Category", SqlDbType.Int).Value = 1;

                            command.ExecuteNonQuery();
                        }
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO Word (Original, Translate, Category) VALUES (@Original, @Translate, @Category)";

                            command.Parameters.Add("Original", SqlDbType.NVarChar, 40).Value = "river";
                            command.Parameters.Add("Translate", SqlDbType.NVarChar, 40).Value = "река";
                            command.Parameters.Add("Category", SqlDbType.Int).Value = 1;

                            command.ExecuteNonQuery();
                        }
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO Word (Original, Translate, Category) VALUES (@Original, @Translate, @Category)";

                            command.Parameters.Add("Original", SqlDbType.NVarChar, 40).Value = "job";
                            command.Parameters.Add("Translate", SqlDbType.NVarChar, 40).Value = "работа";
                            command.Parameters.Add("Category", SqlDbType.Int).Value = 1;

                            command.ExecuteNonQuery();
                        }
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO Word (Original, Translate, Category) VALUES (@Original, @Translate, @Category)";

                            command.Parameters.Add("Original", SqlDbType.NVarChar, 40).Value = "class";
                            command.Parameters.Add("Translate", SqlDbType.NVarChar, 40).Value = "класс";
                            command.Parameters.Add("Category", SqlDbType.Int).Value = 1;

                            command.ExecuteNonQuery();
                        }
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO Word (Original, Translate, Category) VALUES (@Original, @Translate, @Category)";

                            command.Parameters.Add("Original", SqlDbType.NVarChar, 40).Value = "set";
                            command.Parameters.Add("Translate", SqlDbType.NVarChar, 40).Value = "набор";
                            command.Parameters.Add("Category", SqlDbType.Int).Value = 1;

                            command.ExecuteNonQuery();
                        }
                    }

                    using (var connection = new SqlCeConnection(connectionStr))
                    {
                        connection.Open();

                        using (var query = connection.CreateCommand())
                        {
                            query.CommandText = @"CREATE TABLE Category (CategoryId INT IDENTITY(1,1) PRIMARY KEY, CategoryName NVARCHAR(40) NOT NULL, IsUsed BIT NOT NULL);";
                            query.ExecuteNonQuery();
                        }
                        using (var command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO Category (CategoryName, IsUsed) VALUES (@CategoryName, @IsUsed)";

                            command.Parameters.Add("CategoryName", SqlDbType.NVarChar, 40).Value = "no category";
                            command.Parameters.Add("IsUsed", SqlDbType.Bit).Value = true;

                            command.ExecuteNonQuery();
                        }
                    }
                    
                    using (var connection = new SqlCeConnection(connectionStr))
                    {
                        connection.Open();

                        using (var query = connection.CreateCommand())
                        {
                            query.CommandText = @"CREATE TABLE Answer (Id INT IDENTITY(1,1) PRIMARY KEY, AnswerDate DATETIME NOT NULL, Word NVARCHAR(40) NOT NULL, AnswerValue INT NOT NULL);";
                            query.ExecuteNonQuery();
                        }
                    }

                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm(MAppName));
                //return;
            }
            else
            {   
                ShowWindow(tempHandle, 5);
                SetForegroundWindow(tempHandle);
            }
            
            
        }




            
            
      
            
        
    }
}
