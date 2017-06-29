using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Comm
{
	public abstract class CUnmanagedComm : IDisposable
	{
		public delegate void PacketDelegate(Stream stream);
		public event PacketDelegate OnPacket;
        public event Action<string> OnInfo;
        public event Action<bool> OnConnectedChange;

		protected bool connected = false;
		public bool Connected
		{
			get { return connected; }
		}

        public virtual void Dispose()
        {
            OnPacket = null;
        }

        protected void CallOnPacket(Stream stream)
        {
            if (OnPacket != null)
                OnPacket(stream);
        }
        protected void CallOnInfo(string message)
        {
            if (OnInfo != null)
                OnInfo(message);
        }
              
        protected void SetConnected(bool connected)
        {
            this.connected = connected;

            if (OnConnectedChange != null)
                OnConnectedChange(connected);
        }

        public abstract bool Write(byte[] bytes);
        public bool Write(byte[] bytes, int offset, int size)
        {
            byte[] newArray = new byte[size];
            Buffer.BlockCopy(bytes, offset, newArray, 0, size);
            return Write(newArray);
        }
        public bool Write(string asciiText)
        {
            return Write(ASCIIEncoding.ASCII.GetBytes(asciiText));
        }
        public bool Write(short data)
        {
            return Write(BitConverter.GetBytes(data));
        }
        public bool Write(ushort data)
        {
            return Write(BitConverter.GetBytes(data));
        }
    }
}