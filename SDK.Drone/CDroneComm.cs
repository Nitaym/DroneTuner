using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDK.Comm;

namespace SDK.Drone
{
    public class CDroneComm
    {
        public CSerialComm serialComm;
        public Action<System.IO.Stream> OnPacket;

        public bool Connected
        {
            get
            {
                return serialComm.Connected;
            }
        }

        public void ConnectSerial(string comport, string baudrate)
        {
            serialComm = new CSerialComm();
            serialComm.Connect(comport, baudrate);
            serialComm.OnPacket += comm_OnPacket;
        }

        public void Disconnect()
        {
            serialComm.Disconnect();
        }

        void comm_OnPacket(System.IO.Stream stream)
        {
            if (OnPacket != null)
                OnPacket(stream);
        }

        public bool Write(byte[] bytes)
        {
            return serialComm.Write(bytes);
        }
    }
}
