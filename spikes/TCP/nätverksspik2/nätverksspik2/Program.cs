using System;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.IO;
using System.Xml.Serialization;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener serverSocket = new TcpListener(IPAddress.Any, 9059);
            TcpClient clientSocket = default(TcpClient);
            int counter = 0;

            serverSocket.Start();
            Console.WriteLine(" >> " + "Server Started");

            counter = 0;
            while (true)
            {
                TcpClient clientConnection = new TcpClient();
                
                counter += 1;
                clientSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine(" >> " + "Client No:" + Convert.ToString(counter) + " started!");
                handleClinet client = new handleClinet();
                client.startClient(clientSocket, Convert.ToString(counter));
                try
                {
                    clientConnection.Connect("127.0.0.1", 9058);
                    Console.WriteLine(" >> Connection to Client");
                    sendMessage(clientSocket, "Hej Klient");
                }
                catch (SocketException se)
                {
                    Console.WriteLine(se.Message);
                }
            }

            clientSocket.Close();
            serverSocket.Stop();
            Console.WriteLine(" >> " + "exit");
            Console.ReadLine();
        }
        public static void sendMessage(TcpClient serverSocket, string message)
        {
            NetworkStream clientStream = serverSocket.GetStream();


            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] outStream = encoder.GetBytes(message + "$");

            clientStream.Write(outStream, 0, outStream.Length);

            clientStream.Flush();
        }
    }
   
    //Class to handle each client request separatly
    public class handleClinet
    {
        TcpClient clientSocket;
        string clNo;
        public void startClient(TcpClient inClientSocket, string clineNo)
        {
            this.clientSocket = inClientSocket;
            this.clNo = clineNo;
            Thread ctThread = new Thread(doChat);
            ctThread.Start();
            ctThread.IsBackground = true;
        }
        private void doChat()
        {
            int requestCount = 0;
            byte[] bytesFrom = new byte[10025];
            string dataFromClient = null;
            Byte[] sendBytes = null;
            string serverResponse = null;
            requestCount = 0;

            while (true)
            {
                someClass s = new someClass("jocke", "hopp",10);
               
                using (MemoryStream stream = new MemoryStream())
                {
                    XmlSerializer xml = new XmlSerializer(typeof(someClass));
                    xml.Serialize(stream, s);
                    string myString = Encoding.UTF8.GetString(stream.ToArray());
                    Program.sendMessage(clientSocket, myString);
                }

                try
                {
                    requestCount = requestCount + 1;
                    NetworkStream networkStream = clientSocket.GetStream();
                    networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                   
                    dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                    Console.WriteLine(" >> " + dataFromClient);

                    serverResponse = "Server to client(" + clNo + ") ";
                    sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                    networkStream.Flush();
                    Console.WriteLine(" >> " + serverResponse);
                    
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Client " + clNo + " has disconnected");
                    Thread.CurrentThread.Abort();
                }
            }
        }
    }
}