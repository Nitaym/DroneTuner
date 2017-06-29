using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SDK.Drone
{
    public class CHeartbeatThread
    {
        private static Thread hbThread;
        private static bool initialized = false;
        private static bool terminated;

        public static void Initialize()
        {
            if (!initialized)
            {
                hbThread = new Thread(new ThreadStart(ThreadFunc));
                hbThread.Start();

                initialized = true;
            }
        }
        public static void Terminate()
        {
            terminated = true;
            initialized = false;
        }

        public static void ThreadFunc()
        {
            while (!terminated)
            {
                CDroneManager.Heartbeat();
                Thread.Sleep(1000);
            }
        }
    }
}
