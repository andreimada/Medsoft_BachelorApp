using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Networking {
    public abstract class AbstractServer {
        private TcpListener server;
        private string host;
        private int port;

        protected AbstractServer(string host, int port) {
            this.host = host;
            this.port = port;
        }
        public void Start() {
            IPAddress iPAddress = IPAddress.Parse(host);
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, port);
            server = new TcpListener(iPEndPoint);
            server.Start();
            while (true) {
                Console.WriteLine("Waiting for clients..............");
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Client connected.................");
                processRequest(client);
            }
        }
        public abstract void processRequest(TcpClient client);
    }

    public abstract class ConcurrentServer : AbstractServer {
        protected ConcurrentServer(string host, int port) : base(host, port) {
        }

        public override void processRequest(TcpClient client) {
            Thread thread = createWorker(client);
            thread.Start();
        }

        protected abstract Thread createWorker(TcpClient client);
    }
}
