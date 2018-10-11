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
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 0);
            tcpListener.Start();

            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient(); // Thread will wait here until a client tries to connect.
                Thread tcpHandlerThread = new Thread(() => TcpHandler(client)); // Give the client a thread.
                tcpHandlerThread.Start(client);
            }
        }

        private void TcpHandler(TcpClient client)
        {

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
