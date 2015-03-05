using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simhopp.View;

namespace SimhoppGUI
{
    public partial class LiveFeed : Form
    {
        #region Data

        private DelegateGetFirstClientObjectData eventGetFirstClientObjectData;
        private DelegateHandleMessage eventHandleMessage;
        private DelegateSendDataToClient eventSendDataToClient;

        #endregion

        #region Constructor

        public LiveFeed(DelegateGetFirstClientObjectData eventGetFirstClientObjectData,
            DelegateHandleMessage eventHandleMessage,
            DelegateSendDataToClient eventSendDataToClient)
        {
            InitializeComponent();

            this.eventGetFirstClientObjectData = eventGetFirstClientObjectData;
            this.eventHandleMessage = eventHandleMessage;
            this.eventSendDataToClient = eventSendDataToClient;
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            eventSendDataToClient();
            var asd = eventGetFirstClientObjectData();
        }

    }
}
