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
using ClientGUI.Model;
using ClientGUI.View;


namespace ClientGUI
{
    /// <summary>
    /// Class that is able to connect to a server and communicate with it.
    /// </summary>
    public class Client : IClient, IDisposable
    {
        private TcpClient clientSocket;
        private Queue<ServerObjectData> messageQueue = new Queue<ServerObjectData>();


        /// <summary>
        /// Constructor for a client
        /// </summary>
        public Client()
        {
            clientSocket = new TcpClient();
        }

        /// <summary>
        /// A function that tries to connect to a server via its IP and port
        /// </summary>
        public void ConnectToServer(string serverIpAddress, string ssn, string password)
        {
            if(!clientSocket.Client.Connected)
            {
                
                clientSocket = new TcpClient();
                clientSocket.Connect(serverIpAddress, 9059);
                var networkStream = clientSocket.GetStream();
                var asciiEncoder = new ASCIIEncoding();
                var outStream = asciiEncoder.GetBytes(ssn + "$" + password + "#");
                networkStream.Write(outStream, 0, outStream.Length);
                networkStream.Flush();

                if (IsConnected())
                {
                    var threadedChat = new Thread(HandleMessages);
                    threadedChat.Start();
                    threadedChat.IsBackground = true;
                }
                else
                {
                    Disconnect();
                }
                
            }
        }
        private bool IsConnected()
        {
            bool hasServerAnswered = false;
            var bytesFrom = new byte[10800];
            while(!hasServerAnswered)
            {
                try
                {
                    var data = string.Empty;
                    var networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, clientSocket.ReceiveBufferSize);
                    data = Encoding.ASCII.GetString(bytesFrom);
                    data = data.Substring(0, data.IndexOf("$"));
                    hasServerAnswered = true;
                    if (data.Equals("Accepted"))
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                
            }
            return false;
        }
        /// <summary>
        /// Serializes the data into XML-code and sends it to the server
        /// </summary>
        public void SendDataToServer(string ssn, double point)
        {
            if (clientSocket.Client.Connected)
            {
                var message = new ClientObjectData(ssn, point);
                var networkStream = clientSocket.GetStream();
                string serializedString;
                var asciiEncoder = new ASCIIEncoding();
                using (var stream = new MemoryStream())
                {
                    var xmlS = new XmlSerializer(typeof(ClientObjectData));
                    xmlS.Serialize(stream, message);
                    serializedString = Encoding.UTF8.GetString(stream.ToArray());
                }
                var outStream = asciiEncoder.GetBytes(serializedString + "$");
                networkStream.Write(outStream, 0, outStream.Length);
                networkStream.Flush();
            }
        }
        /// <summary>
        /// Handles the messages from the server.
        /// 
        /// </summary>
        private void HandleMessages()
        {
            var bytesFrom = new byte[10800];
            var message = new ServerObjectData();
            while(clientSocket.Client.Connected)
            {
                try
                {
                    string dataFromServer = string.Empty;
                    var networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, clientSocket.ReceiveBufferSize);
                    dataFromServer = Encoding.ASCII.GetString(bytesFrom);
                    dataFromServer = dataFromServer.Substring(0, dataFromServer.IndexOf("$"));
                    using(TextReader reader = new StringReader(dataFromServer))
                    {
                        var xmlS = new XmlSerializer(typeof(ServerObjectData));
                        message = (ServerObjectData)xmlS.Deserialize(reader);
                    }
                    messageQueue.Enqueue(message);
                }
                catch(Exception ex)//Should be better exception for different exceptions
                {
                    Disconnect();
                    Thread.CurrentThread.Abort();
                }
            }
        }

        /// <summary>
        /// Function that disconnects the Client from the server
        /// </summary>
        public void Disconnect()
        {
            if (clientSocket.Client.Connected)
            {
                clientSocket.GetStream().Close();
                clientSocket.Close();
            }
        }

        /// <summary>
        /// returns the first Object in the messagequeue
        /// </summary>
        /// <returns>ServerObjectData</returns>
        public ServerObjectData GetFirstServerObjectData()
        {
            if (messageQueue.Count != 0)
            {
                return messageQueue.Dequeue();
            }
            return null;
        }

        /// <summary>
        /// Returns the size of the messageQueue
        /// </summary>
        /// <returns>int</returns>
        public int GetSizeOfQueue()
        {
            return messageQueue.Count;
        }


        #region IDisposable methods

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Disconnect();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
