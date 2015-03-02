using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Xml.Serialization;
using System.Threading;
using System.IO;
namespace Simhopp
{
    class HandleClient
    {
        TcpClient clientSocket;
        bool clientConnectedToServer;

        /// <summary>
        /// Starts a connection to the Client
        /// </summary>
        /// <param name="inClientSocket"></param>
        public void StartClient(TcpClient inClientSocket)
        {
            this.clientSocket = inClientSocket;
            Thread clientThread = new Thread(HandleMessages);
            this.clientConnectedToServer = true;
            clientThread.Start();
        }

        /// <summary>
        /// The client->server thread is running this function
        /// </summary>
        private void HandleMessages()
        {
            byte [] bytesFrom = new byte[10800];
            string dataFromClient = null;
            ClientObjectData message = new ClientObjectData();
            Byte[] sendBytes = null;

            while(clientConnectedToServer)
            {
                try
                {
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                    dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                    using (TextReader reader = new StringReader(dataFromClient))
                    {
                        XmlSerializer xmlS = new XmlSerializer(typeof(ClientObjectData));
                        message = (ClientObjectData)xmlS.Deserialize(reader);
                    }
                    Console.WriteLine(" >> From client: " + message.JudgeName + " " + message.Point);
                }
                catch(Exception ex)
                {
                    //Client Disconnecting/Closing Client/Fatal error
                    clientConnectedToServer = false;
                    Thread.CurrentThread.Abort();
                }
            }
        }
    }
}
