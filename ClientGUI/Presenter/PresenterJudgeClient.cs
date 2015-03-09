using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using ClientGUI.View;
using ClientGUI.Model;
namespace ClientGUI.Presenter
{
    class PresenterJudgeClient
    {
        #region Properties
        public IJudgeClient View { get; set; }
        public IClient Model { get; set; }
        #endregion

        public PresenterJudgeClient(IJudgeClient view, Client client)
        {
            this.Model = client;
            this.View = view;
            this.View.EventConnectToServer += ConnectToServer;
            this.View.EventSendDataToServer += SendDataToServer;
            this.View.EventDisconnect += Disconnect;

        }
        #region Client methods

        public void ConnectToServer(string ip)
        {
            this.Model.ConnectToServer(ip);
        }

        public void SendDataToServer(string ssn, double point)
        {
            this.Model.SendDataToServer(ssn, point);
        }

        public void SendMessageToGUI(ServerObjectData message)
        {
            this.View.
        }
        public void Disconnect()
        {
            this.Model.Disconnect();
        }
        #endregion
    }
}
