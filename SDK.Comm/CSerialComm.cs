using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace SDK.Comm
{
	public class CSerialComm : CUnmanagedComm
	{
		#region Imports
		[DllImport("CommDll.dll", CharSet = CharSet.Auto)]
		public static extern void Free();
		[DllImport("CommDll.dll", EntryPoint = "ConnectSerial", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool CommConnect(string Comport, int baudrate);
		[DllImport("CommDll.dll", EntryPoint = "Disconnect", CharSet = CharSet.Auto)]
		public static extern void CommDisconnect();

		[DllImport("CommDll.dll", EntryPoint = "Write", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool CommWrite(byte[] bytes, int legnth);


		[DllImport("CommDll.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		private static extern void SetPacketCallback(UnsafePacketDelegate callback);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void StringDelegate(string alertMessage);
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		unsafe private delegate void UnsafePacketDelegate(byte* packet, int length);


		#endregion

		private UnsafePacketDelegate OnDllPacketDelegate;

        public string Comport = "COM1";
        public string Baudrate = "9600";


		public CSerialComm()
		{
			unsafe
			{
				OnDllPacketDelegate = new UnsafePacketDelegate(OnPacketReceived);
			}

			SetPacketCallback(OnDllPacketDelegate);
		}
		~CSerialComm()
		{
			Free();
		}

		private unsafe void OnPacketReceived(byte* packet, int length)
		{
			UnmanagedMemoryStream stream = new UnmanagedMemoryStream(packet, length);

			CallOnPacket(stream);
		}

		public bool Connect(string comport = "", string baudrate = "")
		{
			if (connected)
				return true;

            if (comport == "")
                comport = Comport;
            if (baudrate == "")
                baudrate = Baudrate;

			connected = 
				CommConnect(
					@"\\.\" + comport, 
					int.Parse(baudrate));
			return connected;
		}
		public void Disconnect()
		{
			CommDisconnect();
			connected = false;
		}

        public override bool Write(byte[] bytes)
        {
            bool res = CommWrite(bytes, bytes.Length);

            return res;
        }
    }
}
