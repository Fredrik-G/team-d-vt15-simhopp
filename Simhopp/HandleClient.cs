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
        private Queue<ClientObjectData> messageQueue;

        public HandleClient(ref Queue<ClientObjectData> messageQueue)
        {
            this.messageQueue = messageQueue;
        }
        /// <summary>
        /// Starts a connection to the Client
        /// </summary>
        /// <param name="inClientSocket"></param>
        public void StartClient(TcpClient inClientSocket)
        {
            this.clientSocket = inClientSocket;
            var clientThread = new Thread(HandleMessages);
            this.clientConnectedToServer = true;
            clientThread.Start();
        }

        /// <summary>
        /// The client->server thread is running this function
        /// </summary>
        public void HandleMessages()
        {
            var bytesFrom = new byte[10800];
            var message = new ClientObjectData();
            //Byte[] sendBytes = null;

            while(clientConnectedToServer)
            {
                try
                {
                    var dataFromClient = string.Empty;
                    var networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                    dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                    using (TextReader reader = new StringReader(dataFromClient))
                    {
                        var xmlS = new XmlSerializer(typeof(ClientObjectData));
                        message = (ClientObjectData)xmlS.Deserialize(reader);
                    }
                    //Console.WriteLine(" >> From client: " + message.Ssn + " " + message.Point);
                    messageQueue.Enqueue(message);
                }
                catch(Exception ex)
                {
                    //Client Disconnecting/Closing Client/Fatal error
                    //Console.WriteLine(" >> Client Disconnected");
                    clientConnectedToServer = false;
                    Thread.CurrentThread.Abort();
                }
            }
        }
    }
}
