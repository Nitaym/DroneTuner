#define _CRT_SECURE_NO_WARNINGS
#include "Manager.h"
#include <functional>

using namespace Nexus;

#define MAX_LINE_LEN 255


//////////////////////////////////////////////////////////////////////////////
// Helper Functions
void CManager::PrintInfo(const char *format, ...)
{
	int l_iLen;
	va_list l_tAp;
	char l_strStr[MAX_LINE_LEN];

	if (onInfo != NULL)
	{
		// Printf into the buffer
		va_start(l_tAp, format);
		l_iLen = vsprintf(l_strStr, format, l_tAp);

		onInfo(l_strStr);
	}
}

//////////////////////////////////////////////////////////////////////////////
// Thread helpers
TReceiveCallback ExternalPacketReceived(void* param, CData *a_pData, IMetaData *a_pMetaData)
{
	((CManager*)param)->PacketReceived(a_pData, a_pMetaData);

	return TReceiveCallback_DoNothing;
}
void ExternalReadFailed(void* param, TCommErr a_eError, IMetaData* a_pMetaData)
{
	((CManager*)param)->ReadFailed(a_eError, a_pMetaData);
}


//////////////////////////////////////////////////////////////////////////////
// Manager

CManager::CManager(void) : asyncReceiver(ExternalPacketReceived, ExternalReadFailed, this)
{
	this->buffer = new byte[50 * 1024];
}


CManager::~CManager(void)
{
	SAFE_DELETE_ARRAY(this->buffer);
}

/* This callback is called for every packet. Though not really needed, it is useful */
void CManager::PacketReceived(CData *a_pData, IMetaData *a_pMetaData)
{
	a_pData->GetData(this->buffer, 0, a_pData->GetSize());
	
	onPacket(this->buffer, a_pData->GetSize());
}

/* If, for some reason, the read fails - This callback is being called */
void CManager::ReadFailed(TCommErr a_eError, IMetaData* a_pMetaData)
{
	// Check why the read failed!
	switch (a_eError)
	{
	case E_NEXUS_NOTHING_TO_READ : 
		// If reading from a file - This means the file was ended
		PrintInfo("Done!\n");
		break;
	default:
		PrintInfo("Failed");
	}

	asyncReceiver.Disconnect();
	this->uartComm.Disconnect();
}

void CManager::SetInfoCallback(TStringCallback func)
{
	onInfo = func;
}
void CManager::SetPacketCallback(TPacketCallback func)
{
	onPacket = func;
}

bool CManager::ConnectSerial(std::string comport, int baudrate)
{
	// Initialize the communication chain
	asyncReceiver.SetUnderlyingComm(&uartComm);
	asyncReceiver.SetMaxPacketSize(32768);
	//asyncReceiver.SetMetaDataObject(static_cast<IMetaData*>(static_cast<IModbusMetaData*>(&metaData)));

	PrintInfo("Initialized\n");

	uartComm.SetPortName(comport.c_str());
	uartComm.SetBaudRate(baudrate);

	if (this->uartComm.Connect() == E_NEXUS_OK)
		return (this->asyncReceiver.Connect() == E_NEXUS_OK);

	return false;
}

bool CManager::ConnectTCP(std::string ip, int port)
{
// 	// Initialize the communication chain
// 	asyncReceiver.SetUnderlyingComm(&uartComm);
// 	asyncReceiver.SetMaxPacketSize(32768);
// 	//asyncReceiver.SetMetaDataObject(static_cast<IMetaData*>(static_cast<IModbusMetaData*>(&metaData)));
// 
// 	PrintInfo("Initialized\n");
// 
// 	uartComm.SetPortName(comport.c_str());
// 	uartComm.SetBaudRate(baudrate);
// 
// 	if (this->uartComm.Connect() == E_NEXUS_OK)
// 		return (this->asyncReceiver.Connect() == E_NEXUS_OK);
// 
	return false;

}

void CManager::Disconnect()
{
	asyncReceiver.Disconnect();
	uartComm.Disconnect();
}

bool CManager::Write(byte* packet, int length)
{
 	CData data(packet, length);
 
 	return uartComm.Send(&data) == E_NEXUS_OK;
}