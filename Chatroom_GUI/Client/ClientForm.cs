using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using Custom_Interfaces;

namespace Client
{
    public partial class ClientForm : Form, Custom_Interfaces.IObserver
    {
        private bool isConnected;
        private string name;
        NetworkStream serverStream;
        TcpClient client;
        public ClientForm()
        {
            InitializeComponent();
            isConnected = false;
            name = "Un-nammed User";
        }
        
        private void bConnect_Click(object sender, EventArgs e)
        {
            Thread clientThread = new Thread(ConnectAsClient);
            clientThread.Start();
        }

        private void ConnectAsClient()
        {
            if (this.isConnected) // TODO: How to check when the client is disconnected so it can re-connect?
            {
                return;
            }
            client = new TcpClient(); // Make a client
            try
            {
                client.Connect(IPAddress.Parse("192.168.0.124"), 5001); // Connect to the server. The server's address is my IP address since the server is running on my machine. Port is 0 because local stuff. Should be some number >5000 for multi-computer use???
                this.isConnected = true;
            }
            catch (SocketException)
            {
                UpdateUI("No server found :(");
                return;
            }
            serverStream = client.GetStream(); // Point the stream at the server (I'm sure theres a better way to describe this)

            //string message = "Hello World!"; // Message the client wants to send. This line will be a method call or something so clients can type their own messages.
            //SendMessageToServer(message);
            //UpdateUI("Message sent!"); // Confirmation.


            //message = "qqqqqqqqqqqqqqqqqqqqqqqq";
            //byteMessage = Encoding.ASCII.GetBytes(message);
            //serverStream.Write(byteMessage, 0, message.Length);
            ////Thread.Sleep(1000);
            //byteMessage = new byte[1024];
            //serverStream.Read(byteMessage, 0, byteMessage.Length);
            //UpdateUI("New Message: " + Encoding.ASCII.GetString(byteMessage));


            // Responsible coding.
            //serverStream.Close();
            //client.Close();
        }
        
        private void SendMessageToServer(string message)
        {
            byte[] byteMessage = Encoding.ASCII.GetBytes(message); // Convert the message to a byte[] because NetworkStreams are picky like that.
            serverStream.Write(byteMessage, 0, message.Length); // Send the message.
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            SendMessageToServer(clientMessageBox.Text);
        }

        private void UpdateUI(string incommingMessage)
        {
            Func<int> del = delegate ()
            {
                clientTextBox.AppendText(System.Environment.NewLine + incommingMessage); // this makes sense
                return 0;
            };
            Invoke(del);
            /* Idk why i make a delegate for it.
             * Answer: Not doing it this way throws an exception. Can't do cross-thread stuff.
             * System.InvalidOperationException:
             * 'Cross-thread operation not valid:
             * Control 'clientTextBox' accessed from a thread other than the thread it was created on.'
             */
        }

        public void Update(string newUsersName)
        {
            UpdateUI("New user has joined the chat: " + newUsersName);
        }

        public string GetName()
        {
            return name;
        }
        
        //Might need this later
        private void OnExit()
        {
            serverStream.Close();
            client.Close();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

        }
    }
}
