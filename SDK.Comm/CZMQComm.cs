using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using ZeroMQ;


namespace SDK.Comm
{
	public class CZMQComm : CUnmanagedComm
	{
        string host = "";
        int port = 0;

        private ZContext ZMQContext;
        private ZSocket ZMQSocket;

        private Thread readThread;
        bool terminated = false;

		public CZMQComm()
		{
            ZMQContext = new ZContext();
            ZMQSocket = new ZSocket(ZMQContext, ZSocketType.PAIR);

            readThread = new Thread(new ThreadStart(ReadThread));
            readThread.Start();
		}
        ~CZMQComm()
		{
            terminated = true;
		}

        public virtual void Dispose()
        {
            terminated = true;

            base.Dispose();
        }



		public bool Connect(string host, int port)
		{
			if (connected)
				return true;

            this.port = port;
            this.host = host;

            ZMQSocket.Connect("tcp://" + host+ ":" + port);
            connected = true;
            return connected;
		}
		public void Disconnect()
		{
            try
            {
                ZMQSocket.Disconnect("tcp://" + this.host + ":" + this.port);
            }
            catch
            {
                // Do Nothing
            }
			connected = false;
		}

		public override bool Write(byte[] bytes)
		{
            ZError error;
            ZMQSocket.Send(bytes, 0, bytes.Count(), ZSocketFlags.DontWait, out error);
            return error == ZError.None;
		}

        private void ReadThread()
        {
            try
            {
                while (!terminated)
                {
                    if (connected)
                    {
                        using (var replyFrame = ZMQSocket.ReceiveFrame())
                        {
                            var bytes = replyFrame.Read((int)replyFrame.Length);
                            CallOnPacket(new MemoryStream(bytes));
                        }
                    }
                    else
                        Thread.Sleep(500);
                }
            }
            catch (System.Exception ex)
            {
                if (ex.Message == "ETERM(156384765): Context was terminated")
                {
                }
                else
                {
//                     if (OnError != null)
//                         OnError("Read Error: " + ex.Message);
                }

                terminated = true;
            }
        }
	}
}
