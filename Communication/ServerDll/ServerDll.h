#include <windows.h>

#define COMM_DLL_EXPORTS


#ifdef COMM_DLL_EXPORTS
#define COMM_DLL_API extern "C" __declspec(dllexport)
#else
#define COMM_DLL_API __declspec(dllimport)
#endif


typedef void (__stdcall *TStringCallback)(char* aString);
typedef void (__stdcall *TPacketCallback)(byte* packet, int length);


COMM_DLL_API void Free();

COMM_DLL_API bool OpenServer(int port);
COMM_DLL_API void Disconnect(void);

COMM_DLL_API bool Write(byte* packet, int length);

COMM_DLL_API void SetAlertCallback(TStringCallback func);
COMM_DLL_API void SetInfoCallback(TStringCallback func);
COMM_DLL_API void SetPacketCallback(TPacketCallback func);