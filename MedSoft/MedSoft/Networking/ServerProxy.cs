using Model;
using Model.Dtos;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Networking.ObjectRequestProtocol;
using static Networking.ObjectResponseProtocol;

namespace Networking {
    public class ServerProxy : IService {

        private string host;
        private int port;
        private IObserver client;
        private NetworkStream stream;
        private IFormatter formatter;
        private TcpClient connection;
        private Queue<Response> responses;
        private volatile bool finished;
        private EventWaitHandle waitHandle;

        private DTOUtils dtoutils = new DTOUtils();

        public ServerProxy(string host, int port) {
            this.host = host;
            this.port = port;
            responses = new Queue<Response> ();
        }

        

        private void initializeConnection() {
            try {
                connection = new TcpClient(host, port);
                stream = connection.GetStream();
                formatter = new BinaryFormatter();
                finished = false;
                waitHandle = new AutoResetEvent(false);
                startReader();
            }
            catch (Exception e) {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void sendRequest(Request request) {
            try {
                formatter.Serialize(stream, request);
                stream.Flush();
            }
            catch(Exception e) {
                throw new MedsoftException("Error sending object " + e);
            }
        }

        private Response readResponse() {
            Response response = null;
            try {
                waitHandle.WaitOne();
                lock (responses) {
                    response = responses.Dequeue();
                }
            }
            catch(Exception e) {
                Console.WriteLine(e.StackTrace);
            }
            return response;
        }

        private void closeConnection() {
            finished = true;
            try {
                stream.Close();
                connection.Close();
                waitHandle.Close();
                client = null;
            }
            catch(Exception e) {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void startReader() {
            Thread thread = new Thread(run);
            thread.Start();
        }

        private void handleUpdate(UpdateResponse update) {
            if (update is UpdatePatientResponse) {
                UpdatePatientResponse updatePatientResponse = (UpdatePatientResponse)update;
                Patient patient = dtoutils.getFromDTO(updatePatientResponse.Patient);
                try {
                    client.addNewPatient(patient);
                }
                catch (MedsoftException e) {
                    Console.WriteLine(e.StackTrace);
                }
            }
        }

        private void run() {
            while (!finished) {
                try {
                    object response = formatter.Deserialize(stream);
                    Console.WriteLine("Response recieved " + response);
                    if(response is UpdateResponse) {
                        handleUpdate((UpdateResponse)response);
                    }
                    else {
                        lock (responses) {
                            responses.Enqueue((Response)response);
                        }
                        waitHandle.Set();
                    }
                }
                catch(Exception e) {
                    Console.WriteLine("Reading error " + e);
                }
            }
        }

        public Doctor loginDoctor(string username, string password, IObserver observer) {
            initializeConnection();
            DoctorDTO doctor = new DoctorDTO(username, password);
            sendRequest(new LoginDoctorRequest(doctor));
            Response response = readResponse();
            if(response is LoginDoctorResponse) {
                this.client = observer;
            }
            if(response is ErrorResponse) {
                ErrorResponse err = (ErrorResponse)response;
                closeConnection();
                throw new MedsoftException(err.Message);
            }
            LoginDoctorResponse resp = (LoginDoctorResponse)response;
            Doctor doctor1 = dtoutils.getFromDTO(resp.Doctor);
            return doctor1;
        }

        public Patient loginPatient(string username, string password, IObserver observer) {
            initializeConnection();
            PatientDTO patient = new PatientDTO(username, password);
            sendRequest(new LoginPatientRequest(patient));
            Response response = readResponse();
            if(response is LoginPatientResponse) {
                this.client = observer;
            }
            if(response is ErrorResponse) {
                ErrorResponse err = (ErrorResponse)response;
                closeConnection();
                throw new MedsoftException(err.Message);
            }
            LoginPatientResponse resp = (LoginPatientResponse)response;
            Patient patient1 = dtoutils.getFromDTO(resp.Patient);
            return patient1;
        }

        public void logout(Doctor user, IObserver observer) {
            DoctorDTO doctorDTO = dtoutils.getDTO(user);
            sendRequest(new LogoutDoctorRequest(doctorDTO));
            Response response = readResponse();
            closeConnection();
            if(response is ErrorResponse) {
                ErrorResponse error = (ErrorResponse)response;
                throw new MedsoftException(error.Message);
            }
        }

        public void logout(Patient user, IObserver observer) {
            PatientDTO patientDTO = dtoutils.getDTO(user);
            sendRequest(new LogoutPatientRequest(patientDTO));
            Response response = readResponse();
            closeConnection();
            if (response is ErrorResponse) {
                ErrorResponse error = (ErrorResponse)response;
                throw new MedsoftException(error.Message);
            }
        }

        public Patient addPatient(string username, string password, string firstname, string lastname, string cnp, string address, string phone, IObserver observer) {
            PatientFullDTO patientDTO = new PatientFullDTO(username,password, firstname, lastname, cnp, address, phone);
            sendRequest(new AddPatientRequest(patientDTO));
            Response response = readResponse();
            if(response is ErrorResponse) {
                ErrorResponse err = (ErrorResponse)response;
                throw new MedsoftException(err.Message);
            }
            AddPatientResponse addPatientResponse = (AddPatientResponse)response;
            Patient patient = dtoutils.getFromDTO(addPatientResponse.Patient);
            return patient;
        }

        public string[] getSpecialities() {
            sendRequest(new GetSpecialitiesRequest());
            Response response = readResponse();
            if(response is ErrorResponse) {
                ErrorResponse err = (ErrorResponse)response;
                throw new MedsoftException(err.Message);
            }
            GetSpecialitiesResponse response1 = (GetSpecialitiesResponse)response;
            string[] specialities = response1.Specialities;
            return specialities;
        }

        public DoctorFullDTO[] getDoctorsBySpeciality(string speciality) {
            sendRequest(new GetDoctorsBySpecialityRequest(speciality));
            Response response = readResponse();
            if(response is ErrorResponse) {
                ErrorResponse error = (ErrorResponse)response;
                throw new MedsoftException(error.Message);
            }
            GetDoctorsBySpecialityResponse response1 = (GetDoctorsBySpecialityResponse)response;
            DoctorFullDTO[] doctorsFullDTO = response1.Doctors;
            return doctorsFullDTO;
        }

        public AppointmentDTO[] getAppointmentsByDateAndDoctor(string date, string doctor) {
            sendRequest(new GetAppointmentsByDateAndDoctorRequest(date, doctor));
            Response response = readResponse();
            if (response is ErrorResponse) {
                ErrorResponse error = (ErrorResponse)response;
                throw new MedsoftException(error.Message);
            }
            GetAppointmentsByDateAndDoctorResponse response1 = (GetAppointmentsByDateAndDoctorResponse)response;
            AppointmentDTO[] appointmentsDTO = response1.Appointments;
            return appointmentsDTO;
        }

        public Appointment makeAppointment(string patient, string doctor, string date, string time, IObserver observer) {
            sendRequest(new MakeAppointmentRequest(new AppointmentDTO(patient, doctor, date, time)));
            Response response = readResponse();
            if(response is ErrorResponse) {
                ErrorResponse error = (ErrorResponse)response;
                throw new MedsoftException(error.Message);
            }
            MakeAppointmentResponse response1 = (MakeAppointmentResponse)response;
            AppointmentDTO appointmentDTO = response1.Appointment;
            Appointment appointment = dtoutils.getFromDTO(appointmentDTO);
            return appointment;
        }

        public MedicalLetter createMedicalLetter(string patient, string doctor, string body, string date, IObserver observer) {
            sendRequest(new MakeMedicalLetterRequest(new MedicalLetterDTO(patient, doctor, body, date)));
            Response response = readResponse();
            if(response is ErrorResponse) {
                ErrorResponse error = (ErrorResponse)response;
                throw new MedsoftException(error.Message);
            }
            MakeMedicalLetterResponse makeMedicalLetterResponse = (MakeMedicalLetterResponse)response;
            MedicalLetterDTO medicalLetterDTO = makeMedicalLetterResponse.MedicalLetter;
            MedicalLetter medicalLetter = dtoutils.getFromDTO(medicalLetterDTO);
            return medicalLetter;
        }

        public PatientFullDTO[] getAllPatients() {
            sendRequest(new GetAllPatientsRequest());
            Response response = readResponse();
            if(response is ErrorResponse) {
                ErrorResponse error = (ErrorResponse)response;
                throw new MedsoftException(error.Message);
            }
            GetAllPatientsResponse response1 = (GetAllPatientsResponse)response;
            PatientFullDTO[] patients = response1.Patients;
            return patients;
        }

        public MedicalLetterDTO[] getAllMedicalLetters() {
            sendRequest(new GetAllMedicalLettersRequest());
            Response response = readResponse();
            if(response is ErrorResponse) {
                ErrorResponse error = (ErrorResponse)response;
                throw new MedsoftException(error.Message);
            }
            GetAllMedicalLettersResponse response1 = (GetAllMedicalLettersResponse)response;
            MedicalLetterDTO[] medicalLetters = response1.MedicalLetters;
            return medicalLetters;
        }

        public string getBodyByPacientDoctorDate(string pacient, string doctor, string date) {
            sendRequest(new GetBodyOfMedicalLetterByPacientDoctorDateRequest(pacient, doctor, date));
            Response response = readResponse();
            if (response is ErrorResponse) {
                ErrorResponse error = (ErrorResponse)response;
                throw new MedsoftException(error.Message);
            }
            GetBodyOfMedicalLetterByPatientDoctorDateResponse response1 = (GetBodyOfMedicalLetterByPatientDoctorDateResponse)response;
            return response1.Body;
        }

        public Patient findPatientByUsername(string patient) {
            sendRequest(new GetPatientByUsernameRequest(patient));
            Response response = readResponse();
            if(response is ErrorResponse) {
                ErrorResponse response1 = (ErrorResponse)response;
                throw new MedsoftException(response1.Message);
            }
            GetPatientByUsernameResponse getPatientByUsernameResponse = (GetPatientByUsernameResponse)response;
            Patient patient1 = dtoutils.getFromDTO(getPatientByUsernameResponse.Patient);
            return patient1;
        }

        public Message sendMessage(string from, string to, string text) {
            sendRequest(new SendMessageRequest(new MessageDTO(from, to, text)));
            Response response = readResponse();
            if(response is ErrorResponse) {
                ErrorResponse error = (ErrorResponse)response;
                throw new MedsoftException(error.Message);
            }
            SendMessageResponse sendMessageResponse = (SendMessageResponse)response;
            Message message = dtoutils.getFromDTO(sendMessageResponse.Message);
            return message;
        }

        public DoctorFullDTO[] getAllDoctors() {
            sendRequest(new GetAllDoctorsRequest());
            Response response = readResponse();
            if(response is ErrorResponse) {
                ErrorResponse error = (ErrorResponse)response;
                throw new MedsoftException(error.Message);
            }
            GetAllDoctorsResponse getAllDoctorsResponse = (GetAllDoctorsResponse)response;
            return getAllDoctorsResponse.Doctors;
        }

        public MessageDTO[] getMessagesByDoctorPatient(string username1, string username2) {
            sendRequest(new GetMessagesByPatientDoctorRequest(username1, username2));
            Response response = readResponse();
            if(response is ErrorResponse) {
                ErrorResponse error = (ErrorResponse)response;
                throw new MedsoftException(error.Message);
            }
            GetMessagesByPatientDoctorResponse getMessagesByDoctorPatientResponse = (GetMessagesByPatientDoctorResponse)response;
            return getMessagesByDoctorPatientResponse.Messages;
        }
    }
}
