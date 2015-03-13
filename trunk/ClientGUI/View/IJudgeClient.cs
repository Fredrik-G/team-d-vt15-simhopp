using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGUI.View
{
    public delegate void DelegateConnectToServer(string ip, string ssn, string password);

    public delegate void DelegateSendDataToServer(string ssn, double point);

    public delegate void DelegateDisconnect();

    public delegate ServerObjectData DelegateGetFirstServerObjectData();

    public delegate int DelegateGetSizeOfQueue();

    public interface IJudgeClient
    {
        event DelegateConnectToServer EventConnectToServer;
        event DelegateSendDataToServer EventSendDataToServer;
        event DelegateDisconnect EventDisconnect;
        event DelegateGetFirstServerObjectData EventGetFirstServerObjectData;
        event DelegateGetSizeOfQueue EventGetSizeOfQueue;
    }
}
