#pragma once

#include "Comm/Physical/CClientSocket.h"
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
	Nexus::CClientSocket clientComm;

	TStringCallback onInfo;
	TPacketCallback onPacket;

	/* Helper functions */
	void Print(TStringCallback callback, const char *format, ...);
	void PrintInfo(const char *format, ...);

public:
	CManager(void);
	~CManager(void);

	bool Connect(char* host, int port);
	void Disconnect();

	bool Write(byte* packet, int length);

	void PacketReceived(Nexus::CData *a_pData, Nexus::IMetaData *a_pMetaData);
	void ReadFailed(Nexus::TCommErr a_eError, Nexus::IMetaData* a_pMetaData);

	void SetPacketCallback(TPacketCallback func);
	void SetInfoCallback(TStringCallback func);
};