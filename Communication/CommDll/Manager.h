#pragma once

#include "Comm/Protocols/CAsyncReceiver.h"
#include "Comm/Physical/CUart.h"


typedef void (__stdcall *TStringCallback)(char* aString);
typedef void (__stdcall *TPacketCallback)(byte* packet, int length);


//////////////////////////////////////////////////////////////////////////
// The main class
class CManager
{
private:
	byte* buffer;

	Nexus::CAsyncReceiver asyncReceiver;
	Nexus::CUart uartComm;

	TStringCallback onInfo;
	TPacketCallback onPacket;

	/* Helper functions */
	void Print(TStringCallback callback, const char *format, ...);
	void PrintInfo(const char *format, ...);

public:
	CManager(void);
	~CManager(void);

	bool ConnectSerial(std::string comport, int baudrate);
	bool ConnectTCP(std::string ip, int port);
	void Disconnect();

	bool Write(byte* packet, int length);

	void PacketReceived(Nexus::CData *a_pData, Nexus::IMetaData *a_pMetaData);
	void ReadFailed(Nexus::TCommErr a_eError, Nexus::IMetaData* a_pMetaData);

	void SetInfoCallback(TStringCallback func);
	void SetPacketCallback(TPacketCallback func);
};