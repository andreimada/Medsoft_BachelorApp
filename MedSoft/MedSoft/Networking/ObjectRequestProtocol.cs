using Model;
using Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking {
    internal class ObjectRequestProtocol {
        public interface Request { }

        [Serializable]
        public class LoginDoctorRequest : Request {
            private DoctorDTO user1;
            public LoginDoctorRequest(DoctorDTO user) {
                this.user1 = user;
            }
            public virtual DoctorDTO User { get { return user1; } }
        }

        [Serializable]
        public class LogoutDoctorRequest : Request {
            private DoctorDTO user2;
            public LogoutDoctorRequest(DoctorDTO user2) {
                this.user2 = user2;
            }
            public virtual DoctorDTO User2 { get { return user2; } }
        }

        [Serializable]
        public class LoginPatientRequest : Request {
            private PatientDTO patient;
            public LoginPatientRequest(PatientDTO patient) {
                this.patient = patient;
            }
            public virtual PatientDTO Patient { get { return patient; } }
        }

        [Serializable]
        public class LogoutPatientRequest : Request {
            private PatientDTO patient1;
            public LogoutPatientRequest(PatientDTO patient) {
                this.patient1 = patient;
            }
            public virtual PatientDTO Patient { get { return patient1; } }
        }

        [Serializable]
        public class AddPatientRequest : Request {
            private PatientFullDTO patient2;
            public AddPatientRequest(PatientFullDTO patient2) {
                this.patient2 = patient2;
            }
            public virtual PatientFullDTO Patient { get { return patient2; } }
        }

        [Serializable]
        public class GetSpecialitiesRequest : Request {
            public GetSpecialitiesRequest() {
            }
        }

        [Serializable]
        public class GetDoctorsBySpecialityRequest : Request {
            private string speciality;
            public GetDoctorsBySpecialityRequest(string speciality) {
                this.speciality = speciality;
            }
            public virtual string Speciality { get { return speciality; } }
        }

        [Serializable]
        public class GetAppointmentsByDateAndDoctorRequest : Request {
            private string date;
            private string doctor;
            public GetAppointmentsByDateAndDoctorRequest(string date, string doctor) {
                this.date = date;
                this.doctor = doctor;
            }
            public virtual string Date { get { return date; } }
            public virtual string Doctor { get { return doctor; } }
        }

        [Serializable]
        public class MakeAppointmentRequest : Request {
            private AppointmentDTO appointment;
            public MakeAppointmentRequest(AppointmentDTO appointment) {
                this.appointment = appointment;
            }
            public virtual AppointmentDTO Appointment { get { return appointment; } }
        }

        [Serializable]
        public class MakeMedicalLetterRequest : Request {
            private MedicalLetterDTO medicalLetter;
            public MakeMedicalLetterRequest(MedicalLetterDTO medicalLetter) {
                this.medicalLetter = medicalLetter;
            }
            public virtual MedicalLetterDTO MedicalLetter { get { return medicalLetter; } }
        }

        [Serializable]
        public class GetAllPatientsRequest : Request {
            public GetAllPatientsRequest() {
            }
        }

        [Serializable]
        public class GetAllMedicalLettersRequest : Request {
            public GetAllMedicalLettersRequest() {
            }
        }

        [Serializable]
        public class GetBodyOfMedicalLetterByPacientDoctorDateRequest : Request {
            private string pacient;
            private string doctor;
            private string date;
            public GetBodyOfMedicalLetterByPacientDoctorDateRequest(string pacient, string doctor, string date) {
                this.pacient = pacient;
                this.doctor = doctor;
                this.date = date;
            }
            public virtual string Pacient { get { return pacient; } }
            public virtual string Doctor { get { return doctor; } }
            public virtual string Date { get { return date; } }
        }

        [Serializable]
        public class GetPatientByUsernameRequest : Request {
            private string username;

            public GetPatientByUsernameRequest(string username) {
                this.username = username;
            }
            public virtual string Username { get { return username; } }
        }

        [Serializable]
        public class GetAllDoctorsRequest : Request {
            public GetAllDoctorsRequest() {
            }
        }

        [Serializable]
        public class SendMessageRequest : Request {
            private MessageDTO message;

            public SendMessageRequest(MessageDTO message) {
                this.message = message;
            }
            public virtual MessageDTO Message { get { return message; } }
        }

        [Serializable]
        public class GetMessagesByPatientDoctorRequest : Request {
            private string doctor;
            private string patient;

            public GetMessagesByPatientDoctorRequest(string doctor, string patient) {
                this.doctor = doctor;
                this.patient = patient;
            }
            public virtual string Doctor { get{ return doctor; } }
            public virtual string Patient { get { return patient; } }
        }
    }
}
