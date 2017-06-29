#include "Manager.h"
#include "CommDll.h"

#define MAX_LINE_LEN 255


CManager manager;


/* Alert Callbacks */
// void OnSizesAlert(std::string alertString)
// {
// 	PrintInfo("Packet %d generated an alert!\n", packetCount);
// 	PrintAlert(alertString.c_str());
// }
// void OnProtocolAlert(std::string alertString)
// {
// 	PrintInfo("Packet %d generated an alert!\n", packetCount);
// 	PrintAlert(alertString.c_str());
// }



COMM_DLL_API void Free()
{
}

COMM_DLL_API bool ConnectSerial(char* comport, int baudrate)
{
 	std::string comport_str(comport);
 	return manager.ConnectSerial(comport_str, baudrate);
//	return true;
}

COMM_DLL_API bool ConnectTCP(char* ip, int port)
{
	std::string ip_str(ip);
	return manager.ConnectTCP(ip_str, port);
}

COMM_DLL_API void Disconnect(void)
{
	manager.Disconnect();
}

COMM_DLL_API bool Write(byte* packet, int length)
{
	return manager.Write(packet, length);
}

COMM_DLL_API void SetInfoCallback(TStringCallback func)
{
	manager.SetInfoCallback(func);
}
COMM_DLL_API void SetPacketCallback(TPacketCallback func)
{
	manager.SetPacketCallback(func);
}


// dllmain.cpp : Defines the entry point for the DLL application.
BOOL APIENTRY DllMain( HMODULE hModule, DWORD  ul_reason_for_call, LPVOID lpReserved)
{
	switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH:
	case DLL_THREAD_ATTACH:
	case DLL_THREAD_DETACH:
	case DLL_PROCESS_DETACH:
		break;
	}
	return TRUE;
}