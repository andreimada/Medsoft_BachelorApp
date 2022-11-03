using Model;
using Model.Dtos;
using Model.Exceptions;
using Networking;
using Persistence;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server {
    public class SuperService : IService {

        private IRepositoryDoctor repositoryDoctor;
        private IRepositoryPatient repositoryPatient;
        private IRepositoryAppointment repositoryAppointment;
        private IRepositoryMedicalLetter repositoryMedicalLetter;
        private IRepositoryMessage repositoryMessage;

        private IDictionary<string, IObserver> loggedClients;
        private DTOUtils dtoutils = new DTOUtils();



        public SuperService(IRepositoryDoctor repositoryDoctor, IRepositoryPatient repositoryPatient, IRepositoryAppointment repositoryAppointment, IRepositoryMedicalLetter repositoryMedicalLetter, IRepositoryMessage repositoryMessage) {
            this.repositoryDoctor = repositoryDoctor;
            this.repositoryPatient = repositoryPatient;
            this.repositoryAppointment = repositoryAppointment;
            this.repositoryMedicalLetter = repositoryMedicalLetter;
            this.repositoryMessage = repositoryMessage;
            loggedClients = new Dictionary<string, IObserver>();
        }

        private void notifyAddNewPatient(Patient patient) {
            Console.WriteLine("Notify new added patient");
            foreach(KeyValuePair<string, IObserver> entry in loggedClients) {
                Console.WriteLine("Notifying [" + entry.Key + "] to update info");
                IObserver client = entry.Value;
                Task.Run(() => client.addNewPatient(patient));
            }
        }

        public Patient addPatient(string username, string password, string firstname, string lastname, string cnp, string address, string phone, IObserver observer) {
            try {
                Patient patient = repositoryPatient.save(new Patient(username,password, lastname, firstname, cnp, address, phone));
                notifyAddNewPatient(patient);
                return patient;
            }
            catch(RepositoryException ex) {
                throw new MedsoftException(ex.Message);
            }
        }

        public Doctor loginDoctor(string username, string password, IObserver observer) {
            Doctor doctor = repositoryDoctor.findByUsername(username);
            if (doctor != null && doctor.Password.Equals(password)) {
                Console.WriteLine(loggedClients.Count);
                //if (loggedClients.ContainsKey(doctor.Username)) {
                //    throw new MedsoftException("Doctor deja conectat!");
                //}
                loggedClients[doctor.Username] = observer;
                return doctor;
            }
            throw new MedsoftException("Date incorecte!");
        }

        public Patient loginPatient(string username, string password, IObserver observer) {
            Patient patient = repositoryPatient.findByUsername(username);
            if (patient != null && patient.Password.Equals(password)) {
                //if (loggedClients.ContainsKey(patient.Username)) {
                //    throw new MedsoftException("Pacient deja conectat!");
                //}
                loggedClients[patient.Username] = observer;
                return patient;
            }
            throw new MedsoftException("Date incorecte!");
        }

        public void logout(Doctor user, IObserver observer) {
            IObserver localClient = loggedClients[user.Username];
            if (localClient == null) {
                throw new MedsoftException("Utilizatorul nu este conectat!");
            }
            loggedClients.Remove(user.Username);
        }

        public void logout(Patient user, IObserver observer) {
            IObserver localClient = loggedClients[user.Username];
            if (localClient == null) {
                throw new MedsoftException("Utilizatorul nu este conectat!");
            }
            loggedClients.Remove(user.Username);
        }

        public String[] getSpecialities() {
            return repositoryDoctor.getAllSpecialities();
        }

        DoctorFullDTO[] IService.getDoctorsBySpeciality(string speciality) {
            return repositoryDoctor.getDoctorBySpeciality(speciality).ToArray();
        }

        public AppointmentDTO[] getAppointmentsByDateAndDoctor(string date, string doctor) {
            return repositoryAppointment.findByDoctorAndDate(doctor, date).ToArray();
        }

        public Appointment makeAppointment(string patient, string doctor, string date, string time, IObserver observer) {
            try {
                Appointment appointment = repositoryAppointment.save(new Appointment(patient, doctor, date, time));
                return appointment;
            }
            catch(RepositoryException ex) {
                throw new MedsoftException(ex.Message);
            }
        }

        public MedicalLetter createMedicalLetter(string patient, string doctor, string body, string date, IObserver observer) {
            try {
                MedicalLetter medicalLetter = repositoryMedicalLetter.save(new MedicalLetter(patient, doctor, body, date));
                return medicalLetter;
            }
            catch(RepositoryException ex) {
                throw new MedsoftException(ex.Message);
            }
        }

        public PatientFullDTO[] getAllPatients() {
            List<PatientFullDTO> patientFullDTOs = new List<PatientFullDTO>();
            List<Patient> patients = repositoryPatient.findAll();
            foreach(var patient in patients) {
                var patientDTO = dtoutils.getFullDTO(patient);
                patientFullDTOs.Add(patientDTO);
            }
            return patientFullDTOs.ToArray();
        }

        public MedicalLetterDTO[] getAllMedicalLetters() {
            List<MedicalLetterDTO> medicalLettersDTO = new List<MedicalLetterDTO>();
            List<MedicalLetter> medicalLetters = repositoryMedicalLetter.findAll();
            foreach (var medicalLetter in medicalLetters) { 
                var medicalLetterDTO = dtoutils.getDTO(medicalLetter);
                medicalLettersDTO.Add(medicalLetterDTO);
            }
            return medicalLettersDTO.ToArray();
        }

        public string getBodyByPacientDoctorDate(string pacient, string doctor, string date) {
            return repositoryMedicalLetter.getBodyByPatientDoctorDate(pacient, doctor, date);
        }

        public Patient findPatientByUsername(string patient) {
            return repositoryPatient.findByUsername(patient);
        }

        public Message sendMessage(string from, string to, string text) {
            try {
                return repositoryMessage.save(new Message(from, to, text));
            }
            catch(RepositoryException ex) {
                throw new MedsoftException(ex.Message);
            }
        }

        public DoctorFullDTO[] getAllDoctors() {
            List<Doctor> doctors = repositoryDoctor.findAll();
            List<DoctorFullDTO> doctorFullDTOs = new List<DoctorFullDTO>();
            foreach (Doctor doctor in doctors) { 
                doctorFullDTOs.Add(dtoutils.getFullDTO(doctor));
            }
            return doctorFullDTOs.ToArray();
        }

        public MessageDTO[] getMessagesByDoctorPatient(string username1, string username2) {
            List<MessageDTO> messages = repositoryMessage.findByPatientAndDoctor(username1, username2);
            return messages.ToArray();
        }
    }
}
