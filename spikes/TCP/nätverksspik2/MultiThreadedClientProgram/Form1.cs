using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        TcpClient clientSocket = new TcpClient();
        TcpListener clientListener = new TcpListener(IPAddress.Any, 9058);
        TcpClient serverClient = default(TcpClient);
        NetworkStream serverStream;
        bool connected = false;
        bool serverNotConnected = true;

        public Form1()
        {
            clientListener.Start();
            InitializeComponent();
            msg("Client Started");

            label1.Text = "Client Socket Program - Server Connected ...";
            Thread t1 = new Thread(waitForServerConnection);
            t1.Start();
            t1.IsBackground = true;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void waitForServerConnection()
        {
            while (serverNotConnected)
            {
                try
                {
                    serverClient = clientListener.AcceptTcpClient();
                    serverNotConnected = false;
                    startClient(clientSocket);
                }
                catch(Exception e)
                {
                    msg(e.Message);
                }
            }
        }
        public void msg(string msg)
        {
            textBox1.Text = textBox1.Text + Environment.NewLine + " >> " + msg;
        }
        public void AppendTextBox(string message)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { message });
                return;
            }
            msg(message);
        }
        public void AppendTextBoxName(string name)
        {
            if(InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBoxName), new object[] { name });
                return;
            }
            msg(name);
        }
        public void AppendTextBoxTrick(string trick)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBoxTrick), new object[] { trick });
                return;
            }
            msg(trick);
        }
        public void AppendTextBoxDiff(int diff)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(AppendTextBoxDiff), new object[] { diff });
                return;
            }
            msg(diff.ToString());
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if(!connected)
                {
                    clientSocket.Connect("127.0.0.1", 9059);
                    connected = true;
                }
                    
                NetworkStream serverStream = clientSocket.GetStream();
                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] outStream = encoder.GetBytes(textBox2.Text + "$");

                serverStream.Write(outStream, 0, outStream.Length);

                serverStream.Flush();
            }
            catch(SocketException se)
            {
                msg(se.Message);
            }
        }
       
            public void startClient(TcpClient inClientSocket)
            {
                TcpClient clientSocket = inClientSocket;
                Thread threadedChat = new Thread(doChat);
                threadedChat.Start();
                threadedChat.IsBackground = true;

            }
            private void doChat()
                {
                    while (true)
                    {
                        int requestCount = 0;
                        byte[] bytesFrom = new byte[10025];
                        string dataFromServer = null;
                        requestCount = 0;
                        someClass heh = new someClass();
                        while (true)
                        {
                            try
                            {
                                requestCount++;
                                NetworkStream networkStream = clientSocket.GetStream();
                                networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                                dataFromServer = System.Text.Encoding.ASCII.GetString(bytesFrom);
                                dataFromServer = dataFromServer.Substring(0, dataFromServer.IndexOf("$"));
                                using (TextReader reader = new StringReader(dataFromServer))
                                {
                                    XmlSerializer xml = new XmlSerializer(typeof(someClass));
                                    heh = (someClass)xml.Deserialize(reader);
                                    
                                }
                                //AppendTextBox(dataFromServer);
                                AppendTextBoxName(heh.Name);
                                AppendTextBoxTrick(heh.Jump);
                                AppendTextBoxDiff(heh.Point);
                                
                                
                            
                            }
                            catch (Exception ex)
                            {
                                Thread.CurrentThread.Abort();
                            }
                        }
                    }
                }
            
        }   
    }

