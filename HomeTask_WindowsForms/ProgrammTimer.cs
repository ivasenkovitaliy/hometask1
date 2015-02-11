using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeTask_WindowsForms
{
    public class ProgrammTimer : System.Timers.Timer
    {
        private static ProgrammTimer _timer = null;
        //private Timer internalTimer = new Timer();
        // public int Interval { get; set; }
        
        private ProgrammTimer()
        {
            
        }
        
        public static ProgrammTimer AddTimer(int interval)
        {
            //if (_timer == null)
            _timer = new ProgrammTimer();
            return _timer;
        }
    }
}
