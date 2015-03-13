using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using ClientGUI.Model;

namespace ClientGUI
{
    /// <summary>
    /// Class that is able to connect to a server and communicate with it.
    /// </summary>
    public class Client : IClient, IDisposable
    {
        #region Data

        private TcpClient clientSocket;
        private Queue<ServerObjectData> messageQueue = new Queue<ServerObjectData>();

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for a client
        /// </summary>
        public Client()
        {
            clientSocket = new TcpClient();
            log.Info("New client started.");
        }

        #endregion

        /// <summary>
        /// A function that tries to connect to a server via its IP and port.
        /// Sends judge ssn and password to authenticate.
        /// </summary>
        /// <param name="serverIpAddress"></param>
        /// <param name="ssn"></param>
        /// <param name="password"></param>
        /// <returns>Returns true if connected and false if not connected.</returns>
        public bool ConnectToServer(string serverIpAddress, string ssn, string password)
        {          
            if (clientSocket.Client.Connected)
            {
                return false;
            }

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

                log.Info("Client accepted authentication for judge ssn " + ssn + " to server ip " + serverIpAddress);

                return true;
            }

            Disconnect();

            log.Info("Client refused authentication for judge ssn " + ssn + " to server ip " + serverIpAddress);

            return false;
        }

        /// <summary>
        /// Checks if judge authentication was correct or incorrect.
        /// </summary>
        /// <returns></returns>
        private bool IsConnected()
        {
            var hasServerAnswered = false;
            var bytesFrom = new byte[10800];
            while (!hasServerAnswered)
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
                    log.Warn(e);
                    throw new Exception(e.Message);
                    //TODO: Add exceptions.                  
                }
            }
            return false;
        }

        /// <summary>
        /// Serializes the data into XML-code and sends it to the server
        /// </summary>
        public void SendDataToServer(string ssn, double point)
        {
            if (!clientSocket.Client.Connected)
            {
                return;
            }

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

            log.Debug("Judge ssn " + ssn + " sent message to server with point = " + point);
        }

        /// <summary>
        /// Handles the messages from the server.
        /// </summary>
        private void HandleMessages()
        {
            var bytesFrom = new byte[10800];
            var message = new ServerObjectData();
            while (clientSocket.Client.Connected)
            {
                try
                {
                    string dataFromServer = string.Empty;
                    var networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, clientSocket.ReceiveBufferSize);
                    dataFromServer = Encoding.ASCII.GetString(bytesFrom);
                    dataFromServer = dataFromServer.Substring(0, dataFromServer.IndexOf("$"));
                    using (TextReader reader = new StringReader(dataFromServer))
                    {
                        var xmlS = new XmlSerializer(typeof(ServerObjectData));
                        message = (ServerObjectData)xmlS.Deserialize(reader);
                    }
                    messageQueue.Enqueue(message);
                }
                catch (Exception ex)
                {
                    log.Warn(ex);
                    Disconnect();
                    Thread.CurrentThread.Abort();
                    //TODO: Should be better exception for different exceptions
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
                log.Info("Client disconnected");
            }
        }

        /// <summary>
        /// returns the first Object in the messagequeue
        /// </summary>
        /// <returns>ServerObjectData</returns>
        public ServerObjectData GetFirstServerObjectData()
        {
            return messageQueue.Count != 0 ? messageQueue.Dequeue() : null;
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
