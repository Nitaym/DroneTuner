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
	public class CServerComm : CUnmanagedComm
	{
		#region Imports
		[DllImport("ServerComm.dll", CharSet = CharSet.Auto)]
		public static extern void Free();
		[DllImport("ServerComm.dll", EntryPoint = "OpenServer", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool CommOpenServer(int port);
		[DllImport("ServerComm.dll", EntryPoint = "Disconnect", CharSet = CharSet.Auto)]
		public static extern void CommDisconnect();

		[DllImport("ServerComm.dll", EntryPoint = "Write", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool CommWrite(byte[] bytes, int legnth);


		[DllImport("ServerComm.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		private static extern void SetPacketCallback(UnsafePacketDelegate callback);

		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		public delegate void StringDelegate(string alertMessage);
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		unsafe private delegate void UnsafePacketDelegate(byte* packet, int length);


		#endregion

		private UnsafePacketDelegate OnDllPacketDelegate;


		public CServerComm()
		{
			// 			OnDllInfoDelegate = new StringDelegate(OnInfo);
			// 			OnDllAlertDelegate = new StringDelegate(OnAlert);
			unsafe
			{
				OnDllPacketDelegate = new UnsafePacketDelegate(OnPacketReceived);
			}

			// 			SetAlertCallback(OnDllAlertDelegate);
			// 			SetInfoCallback(OnDllInfoDelegate);
			SetPacketCallback(OnDllPacketDelegate);
		}
		~CServerComm()
		{
			Free();
		}

		private unsafe void OnPacketReceived(byte* packet, int length)
		{
			UnmanagedMemoryStream stream = new UnmanagedMemoryStream(packet, length);

			CallOnPacket(stream);
		}

		public bool Connect(int port)
		{
			if (connected)
				return true;

			connected =
				CommOpenServer(port);
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
