using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace Simhopp
{
    /// <summary>
    /// The class that is running the server and handling connections.
    /// </summary>
    public class Server
    {
        #region Data
        private TcpClient clientSocket;
        private TcpListener serverSocket;
        private Queue<ClientObjectData> messageQueue = new Queue<ClientObjectData>();
        private ServerObjectData latestMessage;
        List<HandleClient> handleClientsList = new List<HandleClient>();
        private bool isServerStarted;
        #endregion

        #region constructors
        /// <summary>
        /// Constructor for creating a new server, accessable on the port 9059
        /// </summary>
        public Server()
        {
            this.isServerStarted = false;
        }
        #endregion

        #region Member Functions

        /// <summary>
        /// starts up a new server, that clients will be able to connect to
        /// </summary>
        public void StartServer()
        {
            if (!isServerStarted)
            {
                serverSocket = new TcpListener(IPAddress.Any, 9059);
                clientSocket = default(TcpClient);
                serverSocket.Start();

                var listenerLoop = new Thread(ListenerLoop);
                listenerLoop.Start();
                listenerLoop.IsBackground = true;
                isServerStarted = true;
            }
        }

        /// <summary>
        /// Function for listening for connections and accepting them.
        /// </summary>
        private void ListenerLoop()
        {
            while (true)
            {
                clientSocket = serverSocket.AcceptTcpClient();
                var handleClient = new HandleClient(ref messageQueue);
                handleClientsList.Add(handleClient);
                handleClient.StartClient(clientSocket);
                SendDataToNewClient();
            }
        }

        /// <summary>
        /// Sets current diver information.
        /// </summary>
        /// <param name="contestName"></param>
        /// <param name="diverName"></param>
        /// <param name="trickName"></param>
        /// <param name="trickDifficulty"></param>
        public void SetDiverMessage(string contestName, string diverName, string trickName, double trickDifficulty)
        {
            latestMessage = new ServerObjectData(contestName, diverName, trickName, trickDifficulty);
        }

        /// <summary>
        /// Serializes the data into XML-code and sends it to client.
        /// </summary>
        public void SendDataToClient()
        {
            if (latestMessage == null)
            {
                return;
            }

            foreach (var client in handleClientsList)
            {
                var networkStream = client.ClientSocket.GetStream();
                string serializedString;
                var asciiEncoder = new ASCIIEncoding();
                using (var stream = new MemoryStream())
                {
                    var xmlS = new XmlSerializer(typeof(ServerObjectData));
                    xmlS.Serialize(stream, latestMessage);
                    serializedString = Encoding.UTF8.GetString(stream.ToArray());
                }
                var outStream = asciiEncoder.GetBytes(serializedString + "$");
                networkStream.Write(outStream, 0, outStream.Length);
                networkStream.Flush();
            }
        }

        /// <summary>
        /// Serializes the data into XML-code and sends it to client.
        /// </summary>
        private void SendDataToNewClient()
        {
            if (latestMessage == null)
            {
                return;
            }

            var networkStream = clientSocket.GetStream();
            string serializedString;
            var asciiEncoder = new ASCIIEncoding();
            using (var stream = new MemoryStream())
            {
                var xmlS = new XmlSerializer(typeof(ServerObjectData));
                xmlS.Serialize(stream, latestMessage);
                serializedString = Encoding.UTF8.GetString(stream.ToArray());
            }
            var outStream = asciiEncoder.GetBytes(serializedString + "$");
            networkStream.Write(outStream, 0, outStream.Length);
            networkStream.Flush();
        }
        /// <summary>
        /// A functions that return the actual IPAddress for this computer.
        /// </summary>
        /// <returns>ipForThis</returns>
        public string GetIPForServer()
        {
            var stringIp = string.Empty;
            stringIp = Dns.GetHostName();
            var ipEntry = Dns.GetHostEntry(stringIp);
            var ipForThis = ipEntry.AddressList;
            return ipForThis[1].ToString();
        }

        public ClientObjectData GetFirstClientObjectData()
        {
            return messageQueue.Count != 0 ? messageQueue.Dequeue() : null;
        }

        #endregion
    }
}
