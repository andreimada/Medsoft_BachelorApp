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
    public class ClientWorker : IObserver {
        private IService server;
        private TcpClient conncetion;

        private NetworkStream stream;
        private IFormatter formatter;
        private volatile bool connected;

        private DTOUtils dtoutils = new DTOUtils();

        public ClientWorker(IService server, TcpClient conncetion) {
            this.server = server;
            this.conncetion = conncetion;
            try {
                stream = conncetion.GetStream();
                formatter = new BinaryFormatter();
                connected = true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.StackTrace);
            }
        }

        public virtual void addNewPatient(Patient patient) {
            PatientDTO patientDTO = dtoutils.getDTO(patient);
            Console.WriteLine("New patient added - worker - " + patient.ToString());
            try {
                sendResponse(new UpdatePatientResponse(patientDTO));
            }
            catch(Exception e) {
                Console.WriteLine(e.StackTrace);
            }
        }

        public virtual void run() {
            while (connected) {
                try {
                    object request = formatter.Deserialize(stream);
                    object response = handleRequest((Request)request);
                    if (response != null) {
                        sendResponse((Response)response);
                    }
                }
                catch(Exception e) {
                    Console.WriteLine(e.StackTrace);
                }
                try {
                    Thread.Sleep(1000);
                }
                catch(Exception e) {
                    Console.WriteLine(e.StackTrace);
                }
            }
        }

        private Response handleRequest(Request request) {
            Response defaultResponse = new ErrorResponse("S-a intamplat o extorsiune a degajamentului de ejectie");
            if(request is LoginDoctorRequest) {
                Console.WriteLine("DoctorLogin request.......");
                LoginDoctorRequest loginDoctorRequest = (LoginDoctorRequest)request;
                DoctorDTO doctorDTO = loginDoctorRequest.User;
                Doctor doctor = dtoutils.getFromDTO(doctorDTO);
                try {
                    Doctor doctor1 = null;
                    lock (server) {
                        doctor1 = server.loginDoctor(doctor.Username, doctor.Password, this);
                    }
                    DoctorDTO doctorDTO1 = dtoutils.getDTO(doctor1);
                    return new LoginDoctorResponse(doctorDTO1);
                }
                catch (MedsoftException e) {
                    connected = false;
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is LoginPatientRequest) {
                Console.WriteLine("PatientLogin request............");
                LoginPatientRequest loginPatientRequest = (LoginPatientRequest)request;
                PatientDTO patientDTO = loginPatientRequest.Patient;
                Patient patient = dtoutils.getFromDTO(patientDTO);
                try {
                    Patient patient1 = null;
                    lock (server) {
                        patient1 = server.loginPatient(patient.Username, patient.Password, this);
                    }
                    PatientDTO patientDTO1 = dtoutils.getDTO(patient1);
                    return new LoginPatientResponse(patientDTO1);
                }
                catch (MedsoftException ex) {
                    connected = false;
                    return new ErrorResponse(ex.Message);
                }
            }

            if (request is LogoutDoctorRequest) {
                Console.WriteLine("Doctor Logout request.......");
                LogoutDoctorRequest logoutDoctorRequest = (LogoutDoctorRequest)request;
                DoctorDTO doctorDTO = logoutDoctorRequest.User2;
                Doctor doctor = dtoutils.getFromDTO(doctorDTO);
                try {
                    lock (server) {
                        server.logout(doctor, this);
                    }
                    connected = false;
                    return new OkResponse();
                }
                catch (MedsoftException e) {
                    return new ErrorResponse(e.Message);
                }
            }

            if(request is LogoutPatientRequest) {
                Console.WriteLine("PatientLogout request..............");
                LogoutPatientRequest logoutPatientRequest = (LogoutPatientRequest)request;
                PatientDTO patientDTO = logoutPatientRequest.Patient;
                Patient patient = dtoutils.getFromDTO(patientDTO);
                try {
                    lock (server) {
                        server.logout(patient, this);
                    }
                    connected = false;
                    return new OkResponse();
                }
                catch(MedsoftException ex) {
                    return new ErrorResponse(ex.Message);
                }
            }

            if (request is AddPatientRequest) {
                Console.WriteLine("Add Patient Request ...............");
                AddPatientRequest addPatientRequest = (AddPatientRequest)request;
                PatientFullDTO patientDTO = addPatientRequest.Patient;
                Patient patient = dtoutils.getFromDTO(patientDTO);
                try {
                    Patient patient1 = null ;
                    lock (server) {
                        patient1 = server.addPatient(patient.Username, patient.Password, patient.FirstName, patient.LastName, patient.Cnp, patient.Address, patient.Phone, this);
                    }
                    return new AddPatientResponse(dtoutils.getFullDTO(patient1));
                }
                catch (Exception ex) {
                    return new ErrorResponse(ex.Message);
                }
            }

            if (request is GetSpecialitiesRequest) {
                Console.WriteLine("GetSpeciality request........");
                GetSpecialitiesRequest specialitiesRequest = (GetSpecialitiesRequest)request;
                try {
                    String[] specialities;
                    lock (server) {
                        specialities = server.getSpecialities();
                    }
                    return new GetSpecialitiesResponse(specialities);
                }
                catch (MedsoftException ex) {
                    return new ErrorResponse(ex.Message);
                }
            }

            if(request is GetDoctorsBySpecialityRequest) {
                GetDoctorsBySpecialityRequest request1 = (GetDoctorsBySpecialityRequest)request;
                string speciality = request1.Speciality;
                Console.WriteLine("Get [" + speciality +"] doctors request..................");
                try {
                    DoctorFullDTO[] doctors;
                    lock (server) {
                        doctors = server.getDoctorsBySpeciality(speciality);
                    }
                    return new GetDoctorsBySpecialityResponse(doctors);
                }
                catch (MedsoftException ex) {
                    return new ErrorResponse(ex.Message);
                }
            }

            if(request is GetAppointmentsByDateAndDoctorRequest) {
                GetAppointmentsByDateAndDoctorRequest request1 = (GetAppointmentsByDateAndDoctorRequest)request;
                string date = request1.Date;
                string doctor = request1.Doctor;
                Console.WriteLine("Getting appointments of doctor [" + doctor + "] ,from [" + date + "] ................");
                try {
                    AppointmentDTO[] appointments;
                    lock (server) {
                        appointments = server.getAppointmentsByDateAndDoctor(date, doctor);
                    }
                    return new GetAppointmentsByDateAndDoctorResponse(appointments);
                }
                catch(MedsoftException ex) {
                    return new ErrorResponse(ex.Message);
                }
            }

            if(request is MakeAppointmentRequest) {
                Console.WriteLine("Making appointment request...........");
                MakeAppointmentRequest request1 = (MakeAppointmentRequest)request;
                AppointmentDTO appointmentDTO = request1.Appointment;
                Appointment appointment = dtoutils.getFromDTO(appointmentDTO);
                try {
                    Appointment appointment1 = null;
                    lock (server) {
                        appointment1 = server.makeAppointment(appointment.Patient, appointment.Doctor, appointment.Date, appointment.Time, this);
                    }
                    return new MakeAppointmentResponse(dtoutils.getDTO(appointment1));
                }
                catch(Exception ex) {
                    return new ErrorResponse(ex.Message);
                }
            }

            if (request is MakeMedicalLetterRequest) {
                Console.WriteLine("Making medical letter request.............");
                MakeMedicalLetterRequest request1 = (MakeMedicalLetterRequest)request;
                MedicalLetterDTO medicalLetterDTO = request1.MedicalLetter;
                MedicalLetter medicalLetter = dtoutils.getFromDTO(medicalLetterDTO);
                try {
                    MedicalLetter medicalLetter1 = null;
                    lock (server) {
                        medicalLetter1 = server.createMedicalLetter(medicalLetter.Patient, medicalLetter.Doctor, medicalLetter.Body, medicalLetter.Date, this);
                    }
                    return new MakeMedicalLetterResponse(dtoutils.getDTO(medicalLetter1));
                }
                catch (Exception ex) {
                    return new ErrorResponse(ex.Message);
                }
            }

            if (request is GetAllPatientsRequest) {
                Console.WriteLine("Getting all patients request...............");
                try {
                    PatientFullDTO[] patients;
                    lock (server) {
                        patients = server.getAllPatients();
                    }
                    return new GetAllPatientsResponse(patients);
                }
                catch (Exception ex) {
                    return new ErrorResponse(ex.Message);
                }
            }

            if (request is GetAllMedicalLettersRequest) {
                Console.WriteLine("Getting all medical letters request.............");
                try {
                    MedicalLetterDTO[] medicalLetters;
                    lock (server) {
                        medicalLetters = server.getAllMedicalLetters();
                    }
                    return new GetAllMedicalLettersResponse(medicalLetters);
                }
                catch (Exception ex) {
                    return new ErrorResponse(ex.Message);
                }
            }

            if (request is GetBodyOfMedicalLetterByPacientDoctorDateRequest) {
                Console.WriteLine("Getting body of Medical Letter............");
                GetBodyOfMedicalLetterByPacientDoctorDateRequest request1 = (GetBodyOfMedicalLetterByPacientDoctorDateRequest)request;
                try {
                    string body;
                    lock (server) {
                        body = server.getBodyByPacientDoctorDate(request1.Pacient, request1.Doctor, request1.Date);
                    }
                    return new GetBodyOfMedicalLetterByPatientDoctorDateResponse(body);
                }
                catch (Exception ex) {
                    return new ErrorResponse(ex.Message);
                }
            }

            if(request is GetPatientByUsernameRequest) {
                Console.WriteLine("Getting patient with specific username..................");
                GetPatientByUsernameRequest request1 = (GetPatientByUsernameRequest)request;
                try {
                    Patient patient;
                    lock (server) {
                        patient = server.findPatientByUsername(request1.Username);
                    }
                    PatientFullDTO patientDTO = dtoutils.getFullDTO(patient);
                    return new GetPatientByUsernameResponse(patientDTO);
                }
                catch(Exception ex) {
                    return new ErrorResponse(ex.Message);
                }
            }

            if(request is SendMessageRequest) {
                Console.WriteLine("Sending message ...............");
                SendMessageRequest sendMessageRequest = (SendMessageRequest)request;
                try {
                    Message message;
                    lock (server) {
                        message = server.sendMessage(sendMessageRequest.Message.FromUsername, sendMessageRequest.Message.ToUsername, sendMessageRequest.Message.Text);
                    }
                    MessageDTO messageDTO = dtoutils.getDTO(message);
                    return new SendMessageResponse(messageDTO);
                }
                catch(Exception ex) {
                    return new ErrorResponse(ex.Message);
                }
            }

            if(request is GetAllDoctorsRequest) {
                Console.WriteLine("Getting all doctors ..............");
                GetAllDoctorsRequest getAllDoctorsRequest = (GetAllDoctorsRequest)request;
                try {
                    DoctorFullDTO[] doctors;
                    lock (server) {
                        doctors = server.getAllDoctors();
                    }
                    return new GetAllDoctorsResponse(doctors);
                }
                catch(Exception ex) {
                    return new ErrorResponse(ex.Message);
                }
            }

            if (request is GetMessagesByPatientDoctorRequest) {
                Console.WriteLine("Getting messages................");
                GetMessagesByPatientDoctorRequest getMessagesByPatientDoctorRequest = (GetMessagesByPatientDoctorRequest)request;
                try {
                    MessageDTO[] messages;
                    lock (server) {
                        messages = server.getMessagesByDoctorPatient(getMessagesByPatientDoctorRequest.Patient, getMessagesByPatientDoctorRequest.Doctor);
                    }
                    return new GetMessagesByPatientDoctorResponse(messages);
                }
                catch(Exception ex) {
                    return new ErrorResponse(ex.Message);
                }
            }



            return defaultResponse;
        }

        private void sendResponse(Response response) {
            Console.WriteLine("Sending response " + response);
            lock (stream) {
                formatter.Serialize(stream, response);
                stream.Flush();
            }
        }
    }
}
