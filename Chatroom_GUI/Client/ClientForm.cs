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

namespace Client
{
    public partial class ClientForm : Form
    {
        private bool isConnected;
        public ClientForm()
        {
            InitializeComponent();
            isConnected = false;
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

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
            TcpClient client = new TcpClient(); // Make a client
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
            NetworkStream stream = client.GetStream(); // Make a stream for the client to talk to the server. Should probably return this stream so client can talk to server outside of this method?????

            string message = "Hello World!"; // Message the client wants to send. This line will be a method call or something so clients can type their own messages.
            byte[] byteMessage = Encoding.ASCII.GetBytes(message); // Convert the message to a byte[] because NetworkStreams are picky like that.
            stream.Write(byteMessage, 0, message.Length); // Send the message.
            UpdateUI("Message sent!"); // Confirmation.

            // Responsible coding.
            stream.Close();
            client.Close();
        }

        private void UpdateUI(string incommingMessage)
        {
            Func<int> del = delegate ()
            {
                clientTextBox.AppendText(incommingMessage + System.Environment.NewLine); // this makes sense
                return 0;
            };
            Invoke(del); // Idk why i make a delegate for it.
        }
    }
}
