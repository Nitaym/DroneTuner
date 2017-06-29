#include <windows.h>

#define CLIENT_DLL_EXPORTS


#ifdef CLIENT_DLL_EXPORTS
#define CLIENT_DLL_API extern "C" __declspec(dllexport)
#else
#define CLIENT_DLL_API __declspec(dllimport)
#endif


typedef void (__stdcall *TStringCallback)(char* aString);
typedef void (__stdcall *TPacketCallback)(byte* packet, int length);


CLIENT_DLL_API void Free();

CLIENT_DLL_API bool Connect(char* host, int port);
CLIENT_DLL_API void Disconnect(void);

CLIENT_DLL_API bool Write(byte* packet, int length);

CLIENT_DLL_API void SetPacketCallback(TPacketCallback func);
CLIENT_DLL_API void SetInfoCallback(TStringCallback func);
