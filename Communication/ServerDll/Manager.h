#pragma once

#include "Comm/Physical/CServerSocket.h"
#include "Comm/Protocols/CAsyncReceiver.h"
#include "Comm/Protocols/CAutoConnect.h"



typedef void (__stdcall *TStringCallback)(char* aString);
typedef void (__stdcall *TPacketCallback)(byte* packet, int length);


//////////////////////////////////////////////////////////////////////////
// The main class
class CManager
{
private:
	Nexus::CAutoConnect autoConnect;
	Nexus::CAsyncReceiver asyncReceiver;
	Nexus::CServerSocket serverComm;

	TStringCallback onInfo;
	TPacketCallback onPacket;

	/* Helper functions */
	void Print(TStringCallback callback, const char *format, ...);
	void PrintInfo(const char *format, ...);

public:
	CManager(void);
	~CManager(void);

	bool OpenServer(int port);
	void Disconnect();

	bool Write(byte* packet, int length);

	void PacketReceived(Nexus::CData *a_pData, Nexus::IMetaData *a_pMetaData);
	void ReadFailed(Nexus::TCommErr a_eError, Nexus::IMetaData* a_pMetaData);

	void SetInfoCallback(TStringCallback func);
	void SetPacketCallback(TPacketCallback func);
};