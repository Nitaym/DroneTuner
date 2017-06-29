using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Drone
{
    public static class CMavlinkSerialization
    {
        static FileStream fileStream;
        static StreamWriter writer;
        static bool Initialized = false;
        static int counter = 0;

        static DateTime startTime;

        public static bool Initialize(string writeFilename)
        {
            Initialized = false;
            if (writeFilename != "")
            {
                try
                {
                    fileStream = new FileStream(writeFilename, FileMode.Append);
                    writer = new StreamWriter(fileStream);
                    startTime = DateTime.Now;
                    writer.WriteLine("// " + startTime.ToShortDateString() + " " + startTime.ToLongDateString());
                    writer.Flush();

                    Initialized = true;

                }
                catch
                {
                    return false;
                }

            }

            return Initialized;
        }

        public static void SavePacket(Stream stream)
        {
            long pos = stream.Position;
            byte[] bytes = new byte[stream.Length - pos];
            stream.Read(bytes, 0, bytes.Length);
            SavePacket(bytes);
            stream.Position = pos;
        }
        public static void SavePacket(byte[] bytes)
        {
            string hexBytes = BitConverter.ToString(bytes);
            string time = (DateTime.Now - startTime).TotalMilliseconds.ToString();
            string counterString = counter++.ToString();

            byte[] data = new UTF8Encoding(true).GetBytes(counterString + "," + time + "," + hexBytes + "\r\n");
            fileStream.Write(data, 0, data.Length);
            fileStream.Flush();
        }
    }
}
