using Networking;
using Persistence;
using Persistence.Validators;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server {
    public class StartServer {
        static void Main(string[] args) {
            IRepositoryPatient repositoryPatient = new RepositoryPatientDB(new PatientValidator());
            IRepositoryDoctor repositoryDoctor = new RepositoryDoctorDB();
            IRepositoryAppointment repositoryAppointment = new RepositoryAppointmentDB();
            IRepositoryMessage repositoryMessage = new RepositoryMessageDB();
            IRepositoryMedicalLetter repositoryMedicalLetter = new RepositoryMedicalLetterDB();

            IService service = new SuperService(repositoryDoctor, repositoryPatient, repositoryAppointment, repositoryMedicalLetter, repositoryMessage);
            SerialServer server = new SerialServer("127.0.0.1", 55555, service);
            server.Start();
            Console.WriteLine("Server started.............");
            Console.ReadLine();
        }

        public class SerialServer : ConcurrentServer {
            private IService server;
            private ClientWorker worker;

            public SerialServer(string host, int port, IService server) : base(host, port) {
                this.server = server;
            }

            protected override Thread createWorker(TcpClient client) {
                worker = new ClientWorker(server, client);
                return new Thread(new ThreadStart(worker.run));
            }
        }
    }
}
