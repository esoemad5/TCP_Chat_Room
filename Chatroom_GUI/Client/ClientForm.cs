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
        //private NetworkStream serverStream;
        private TcpClient client;
        private int lastMessageRead;

        private ChatroomDatabaseDataContext db = new ChatroomDatabaseDataContext();
        public ClientForm()
        {
            InitializeComponent();
            isConnected = false;
            name = "Un-nammed User";
            lastMessageRead = db.MessageDatas.ToArray().Last().ID;
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
                client.Connect(IPAddress.Parse("192.168.0.120"), 5001); // Connect to the server with my IP. Run ipconfig to find it
                this.isConnected = true;
            }
            catch (SocketException)
            {
                UpdateUI("No server found :(");
                return;
            }
            //serverStream = client.GetStream(); // Point the stream at the server (I'm sure theres a better way to describe this)

            //string message = "Hello World!"; // Message the client wants to send. This line will be a method call or something so clients can type their own messages.
            //SendMessageToServer(message);
            //UpdateUI("Message sent!"); // Confirmation.


            //message = "qqqqqqqqqqqqqqqqqqqqqqqq";
            //byteMessage = Encoding.ASCII.GetBytes(message);
            //serverStream.Write(byteMessage, 0, message.Length);
            ////Thread.Sleep(1000);
            //byteMessage = new byte[1024];



            // Responsible coding.
            //serverStream.Close();
            //client.Close();
        }
        
        private void SendMessageToServer(string content, string recipient)
        {
            MessageData messageData = new MessageData();
            messageData.Author = name;
            messageData.Recipient = recipient;
            messageData.Content = content;
            messageData.TimeSent = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString(); // awkward but works
            db.MessageDatas.InsertOnSubmit(messageData);
            db.SubmitChanges();
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            SendMessageToServer(clientMessageBox.Text, "All users");
        }

        private void UpdateUI(MessageData[] incommingMessages)
        {
            Action del = delegate ()
            {
                foreach(MessageData message in incommingMessages)
                {
                    clientTextBox.AppendText(System.Environment.NewLine + message.Content); // this makes sense
                    lastMessageRead = message.ID;
                }
            };
            Invoke(del);
            /* Idk why i make a delegate for it.
             * Answer: Not doing it this way throws an exception. Can't do cross-thread stuff.
             * System.InvalidOperationException:
             * 'Cross-thread operation not valid:
             * Control 'clientTextBox' accessed from a thread other than the thread it was created on.'
             */
        }
        private void UpdateUI(string message)
        {
            Action del = delegate ()
            {
                clientTextBox.AppendText(System.Environment.NewLine + message); 
            };
            Invoke(del);
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
            //serverStream.Close();
            client.Close();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

        }
    }
}
