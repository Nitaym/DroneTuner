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
	public class CClientComm : CUnmanagedComm
	{
		#region Imports
		[DllImport("ClientDll.dll", CharSet = CharSet.Auto)]
		public static extern void Free();
		[DllImport("ClientDll.dll", EntryPoint = "Connect", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool CommConnectClient(string host, int port);
		[DllImport("ClientDll.dll", EntryPoint = "Disconnect", CharSet = CharSet.Auto)]
		public static extern void CommDisconnect();

		[DllImport("ClientDll.dll", EntryPoint = "Write", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool CommWrite(byte[] bytes, int legnth);


        [DllImport("ClientDll.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        private static extern void SetPacketCallback(UnsafePacketDelegate callback);
        [DllImport("ClientDll.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        private static extern void SetInfoCallback(StringDelegate callback);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void StringDelegate(string alertMessage);
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		unsafe private delegate void UnsafePacketDelegate(byte* packet, int length);


		#endregion

		private UnsafePacketDelegate OnDllPacketDelegate;
        private StringDelegate OnDllInfoDelegate;


		public CClientComm()
		{
			OnDllInfoDelegate = new StringDelegate(OnInfoRecevied);
			// 			OnDllAlertDelegate = new StringDelegate(OnAlert);
			unsafe
			{
				OnDllPacketDelegate = new UnsafePacketDelegate(OnPacketReceived);
			}

			// 			SetAlertCallback(OnDllAlertDelegate);
			// 			SetInfoCallback(OnDllInfoDelegate);
			SetPacketCallback(OnDllPacketDelegate);
            SetInfoCallback(OnDllInfoDelegate);
		}
		~CClientComm()
		{
			Free();
		}

		private unsafe void OnPacketReceived(byte* packet, int length)
		{
			UnmanagedMemoryStream stream = new UnmanagedMemoryStream(packet, length);

			CallOnPacket(stream);
		}
        private void OnInfoRecevied(string message)
        {
            CallOnInfo(message);
        }

		public bool Connect(string host, int port)
		{
			if (connected)
				return true;

			connected = CommConnectClient(host, port);
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
