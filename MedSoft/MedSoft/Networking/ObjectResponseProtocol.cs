using Model;
using Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking {
    public class ObjectResponseProtocol {
        public interface Response { }

        [Serializable]
        public class OkResponse : Response { }

        [Serializable]
        public class LoginDoctorResponse : Response {
            private DoctorDTO doctor;
            public LoginDoctorResponse(DoctorDTO user1) {
                this.doctor = user1;
            }
            public virtual DoctorDTO Doctor { get { return doctor; } }
        }

        [Serializable]
        public class LoginPatientResponse : Response {
            private PatientDTO patient;

            public LoginPatientResponse(PatientDTO patient) {
                this.patient = patient;
            }
            public virtual PatientDTO Patient { get { return patient; } }
        }

        [Serializable]
        public class ErrorResponse : Response {
            private string message;

            public ErrorResponse(string message) {
                this.message = message;
            }
            public virtual string Message { get { return message; } }
        }

        [Serializable]
        public class AddPatientResponse : Response {
            private PatientFullDTO patient1;

            public AddPatientResponse(PatientFullDTO patient1) {
                this.patient1 = patient1;
            }
            public virtual PatientFullDTO Patient { get { return patient1; } }
        }

        [Serializable]
        public class GetSpecialitiesResponse : Response {
            private string[] specialities;
            public GetSpecialitiesResponse(string[] specialities) {
                this.specialities = specialities;
            }
            public virtual string[] Specialities { get { return specialities; } }
        }

        [Serializable]
        public class GetDoctorsBySpecialityResponse : Response {
            private DoctorFullDTO[] doctors;
            public GetDoctorsBySpecialityResponse(DoctorFullDTO[] doctors) {
                this.doctors = doctors;
            }
            public virtual DoctorFullDTO[] Doctors { get { return doctors; } }
        }
        [Serializable]
        public class GetAppointmentsByDateAndDoctorResponse : Response {
            private AppointmentDTO[] appointments;
            public GetAppointmentsByDateAndDoctorResponse(AppointmentDTO[] appointments) {
                this.appointments = appointments;
            }
            public virtual AppointmentDTO[] Appointments { get { return appointments; } }
        }

        [Serializable]
        public class MakeAppointmentResponse : Response {
            private AppointmentDTO appointment;
            public MakeAppointmentResponse(AppointmentDTO appointment) {
                this.appointment = appointment;
            }
            public virtual AppointmentDTO Appointment { get { return appointment; } }
        }

        [Serializable]
        public class MakeMedicalLetterResponse : Response { 
            private MedicalLetterDTO medicicalLetter;
            public MakeMedicalLetterResponse(MedicalLetterDTO medicicalLetter) {
                this.medicicalLetter = medicicalLetter;
            }
            public virtual MedicalLetterDTO MedicalLetter { get { return medicicalLetter; } }
        }

        [Serializable]
        public class GetAllPatientsResponse : Response {
            private PatientFullDTO[] patients;
            public GetAllPatientsResponse(PatientFullDTO[] patients) {
                this.patients = patients;
            }
            public virtual PatientFullDTO[] Patients { get { return patients; } }
        }

        [Serializable]
        public class GetAllMedicalLettersResponse : Response {
            private MedicalLetterDTO[] medicalLetters;
            public GetAllMedicalLettersResponse(MedicalLetterDTO[] medicalLetters) {
                this.medicalLetters = medicalLetters;
            }
            public virtual MedicalLetterDTO[] MedicalLetters { get { return medicalLetters; } }
        }

        [Serializable]
        public class GetBodyOfMedicalLetterByPatientDoctorDateResponse : Response {
            private string body;
            public GetBodyOfMedicalLetterByPatientDoctorDateResponse(string body) {
                this.body = body;
            }
            public virtual string Body { get { return body; } }
        }

        [Serializable]
        public class GetPatientByUsernameResponse : Response {
            private PatientFullDTO patient;

            public GetPatientByUsernameResponse(PatientFullDTO patient) {
                this.patient = patient;
            }
            public virtual PatientFullDTO Patient { get { return patient; } }
        }

        [Serializable]
        public class GetAllDoctorsResponse : Response {
            private DoctorFullDTO[] doctors;

            public GetAllDoctorsResponse(DoctorFullDTO[] doctors) {
                this.doctors = doctors;
            }
            public virtual DoctorFullDTO[] Doctors { get { return doctors; } }
        }

        [Serializable]
        public class SendMessageResponse : Response {
            private MessageDTO message;

            public SendMessageResponse(MessageDTO message) {
                this.message = message;
            }
            public virtual MessageDTO Message { get { return message; } }
        }

        [Serializable]
        public class GetMessagesByPatientDoctorResponse : Response {
            private MessageDTO[] messages;

            public GetMessagesByPatientDoctorResponse(MessageDTO[] messages) {
                this.messages = messages;
            }
            public virtual MessageDTO[] Messages { get { return messages; } }
        }




        public interface UpdateResponse : Response { }
        
        [Serializable]
        public class UpdatePatientResponse : UpdateResponse {
            private PatientDTO patient;
            public UpdatePatientResponse(PatientDTO patient2) {
                this.patient = patient2;
            }
            public virtual PatientDTO Patient { get { return patient; } }
        }

        [Serializable]
        public class UpdateAppointmentResponse : UpdateResponse { 
            private AppointmentDTO appointment;
            public UpdateAppointmentResponse(AppointmentDTO appointment) {
                this.appointment = appointment;
            }
            public virtual AppointmentDTO Appointment { get { return appointment; } }
        }

        [Serializable]
        public class UpdateMedicalLettersResponse : UpdateResponse { 
            private MedicalLetterDTO medicalLetter;
            public UpdateMedicalLettersResponse(MedicalLetterDTO medicalLetter) {
                this.medicalLetter = medicalLetter;
            }
            public virtual MedicalLetterDTO MedicalLetter { get { return medicalLetter; } }
        }

        [Serializable]
        public class UpdateMessageResponse : UpdateResponse {
            private MessageDTO message;
            public UpdateMessageResponse(MessageDTO message) {
                this.message = message;
            }
            public virtual MessageDTO Message { get { return message; } }
        }
        
    }
}
