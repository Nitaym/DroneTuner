using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SDK.Drone
{
    class CMavlinkDeserialization
    {
        static FileStream fileStream;
        static StreamReader reader;
        static bool Initialized = false;
        static Thread simulationThread;

        public static event Action<byte[]> OnPacket;

        public static bool Initialize(string filename)
        {
            Initialized = false;
            if (filename != "")
            {
                fileStream = File.OpenRead(filename);
                simulationThread = new Thread(new ThreadStart(ThreadFunc));
                simulationThread.Start();
                reader = new StreamReader(fileStream);
                Initialized = true;
            }

            return Initialized;           
        }
        public static void Terminate()
        {
            Initialized = false;
        }

        private static void ThreadFunc()
        {
            string line;
            string[] items;
            string counterString;
            string timeString;
            string dataString;
            int time;
            byte[] data;
            int lastTime = 0;

            while (Initialized)
            { 
                line = reader.ReadLine();
                if (line.StartsWith("//"))
                    continue;

                items = line.Split(',');
                counterString = items[0];
                timeString = items[1];
                dataString = items[2];
                time = (int)float.Parse(timeString);

                String[] byteStrings = dataString.Split('-');
                data = new byte[byteStrings.Length];
                for(int i=0; i < byteStrings.Length; i++) data[i] = Convert.ToByte(byteStrings[i], 16);

                if (OnPacket != null)
                    OnPacket(data);

                Thread.Sleep(time - lastTime);

                lastTime = time;
            }
        }
    }
}
