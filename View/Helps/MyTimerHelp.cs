using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Views.Helps
{
    public class MyTimerHelp
    {
        public static System.Timers.Timer timerInstance;
        public static void CreateNewTimer(double ms,Action<Object, ElapsedEventArgs> action)
        {
            if(timerInstance!=null)
            {
                timerInstance.Stop();
                timerInstance.Close();
            }
            timerInstance = new System.Timers.Timer(ms);
            timerInstance.Enabled = true;
            timerInstance.AutoReset = false;
            timerInstance.Elapsed += new System.Timers.ElapsedEventHandler(action);
            timerInstance.Start();
        }
        public static void CloseTimer()
        {
            timerInstance.Stop();
            timerInstance.Close();
            timerInstance = null;
        }
    }
}
