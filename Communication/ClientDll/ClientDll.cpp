#include "Manager.h"
#include "ClientDll.h"


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



CLIENT_DLL_API void Free()
{
}

CLIENT_DLL_API bool Connect(char* host, int port)
{
 	return manager.Connect(host, port);
}

CLIENT_DLL_API void Disconnect(void)
{
	manager.Disconnect();
}

CLIENT_DLL_API bool Write(byte* packet, int length)
{
	return manager.Write(packet, length);
}

CLIENT_DLL_API void SetPacketCallback(TPacketCallback func)
{
	manager.SetPacketCallback(func);
}
CLIENT_DLL_API void SetInfoCallback(TStringCallback func)
{
	manager.SetInfoCallback(func);
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