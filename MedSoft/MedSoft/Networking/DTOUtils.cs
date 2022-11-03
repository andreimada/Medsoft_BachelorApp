using Model;
using Model.Dtos;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Networking {
    public class DTOUtils {
        private static IRepositoryDoctor repositoryDoctor = new RepositoryDoctorDB();
        private static IRepositoryPatient repositoryPatient = new RepositoryPatientDB(new Persistence.Validators.PatientValidator());
        public Doctor getFromDTO(DoctorDTO doctorDTO) {
            Doctor doctor = repositoryDoctor.findByUsername(doctorDTO.Username);
            return doctor;
        }

        public DoctorDTO getDTO(Doctor doctor) {
            string username = doctor.Username;
            string password = doctor.Password;
            return new DoctorDTO(username, password);
        }

        public Patient getFromDTO(PatientDTO patientDTO) {
            Patient patient = repositoryPatient.findByUsername(patientDTO.Username);
            return patient;
        }

        public PatientDTO getDTO(Patient patient) {
            string username = patient.Username;
            string password = patient.Password;
            return new PatientDTO(username, password);
        }
        public PatientFullDTO getFullDTO(Patient patient) {
            return new PatientFullDTO(patient.Username, patient.Password, patient.FirstName, patient.LastName, patient.Cnp, patient.Address, patient.Phone);
        }
        public Patient getFromDTO(PatientFullDTO patient) {
            return new Patient(patient.Username, patient.Password, patient.FirstName, patient.LastName, patient.Cnp, patient.Address, patient.Phone);
        }
        public DoctorFullDTO getFullDTO(Doctor doctor) {
            return new DoctorFullDTO(doctor.Username, doctor.Password, doctor.Firstname, doctor.Lastname, doctor.Speciality);
        } 
        public Doctor getFromDTO(DoctorFullDTO doctor) {
            return new Doctor(doctor.Username, doctor.Password, doctor.Firstname, doctor.Lastname, doctor.Speciality);
        }
        public AppointmentDTO getDTO(Appointment appointment) {
            return new AppointmentDTO(appointment.Patient, appointment.Doctor, appointment.Date, appointment.Time);
        }
        public Appointment getFromDTO(AppointmentDTO appointment) {
            return new Appointment(appointment.Patient, appointment.Doctor, appointment.Date, appointment.Time);
        }
        public MessageDTO getDTO(Message message) {
            return new MessageDTO(message.FromUsername, message.ToUsername, message.Text);
        }
        public Message getFromDTO(MessageDTO message) {
            return new Message(message.FromUsername, message.ToUsername, message.Text);
        }
        public MedicalLetterDTO getDTO(MedicalLetter medicalLetter) {
            return new MedicalLetterDTO(medicalLetter.Patient, medicalLetter.Doctor, medicalLetter.Body, medicalLetter.Date);
        }
        public MedicalLetter getFromDTO(MedicalLetterDTO medicalLetter) {
            return new MedicalLetter(medicalLetter.Patient, medicalLetter.Doctor, medicalLetter.Body, medicalLetter.Date);
        }
    }
}
