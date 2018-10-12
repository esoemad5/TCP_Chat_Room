using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Chatroom_GUI
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            InitializeComponent();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {

        }

        private void bStartServer_Click(object sender, EventArgs e)
        {
            Thread tcpServerRunThread = new Thread(TcpServerStart); // Makes a thread for the server. Don't click that button more than once lol.
            tcpServerRunThread.Start();
        }

        private void TcpServerStart()
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 5001);
            tcpListener.Start();
            UpdateUI("Listening for TcpClients");

            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient(); // Thread will wait here until a client tries to connect.
                UpdateUI("Connected!");
                Thread tcpHandlerThread = new Thread(() => TcpHandler(client)); // Devote a thread to handle the actions of a client
                tcpHandlerThread.Start(); // Used to use client as an argument and got an exception. This works. Why????
            }
        }

        private void TcpHandler(Object client_)
        {
            TcpClient client = (TcpClient)client_;
            NetworkStream stream = client.GetStream(); // Make a stream for the server to listen to the client
            byte[] byteMessage = new byte[1024];
            stream.Read(byteMessage, 0, byteMessage.Length);
            UpdateUI("New Message: " + Encoding.ASCII.GetString(byteMessage));

            // Stay green bb
            stream.Close();
            client.Close();
        }

        private void UpdateUI(string incommingMessage)
        {
            Func<int> del = delegate ()
            {
                serverTextBox.AppendText(incommingMessage + System.Environment.NewLine); // this makes sense
                return 0;
            };
            Invoke(del); // Idk why i make a delegate for it.
        }

        /* For learning purposes only
         * When TcpHandler parameter is 'TcpClient client' this breaks. When it is 'Object client' it works.
        delegate void Test(TcpClient c);
        private void DelegateMethod()
        {
            Test test;
            test = new Test(TcpHandler);

            Thread __tcpHandlerThread = new Thread(test);
            Thread _______tcpHandlerThread = new Thread(() => ThreadStart(test));
            Thread _tcpHandlerThread = new Thread(new ParameterizedThreadStart(test));
            Thread tcpHandlerThread = new Thread(new ThreadStart(tcpHandler(client)));
        }
        */
    }
}
