using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGUI.Model
{
    public interface IClient
    {
        void ConnectToServer(string ip);
        void SendDataToServer(string ssn, double point);
        void Disconnect();
        ServerObjectData GetFirstServerObjectData();
    }
}
