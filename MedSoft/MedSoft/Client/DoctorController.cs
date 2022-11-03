using Model;
using Model.Dtos;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClientDoctor {
    public class DoctorController : IObserver {
        private IService service;
        private Doctor doctor;
        public event EventHandler<DoctorUserEventArgs> updateEvent;
        public IService Service { get { return service; } }
        public Doctor Doctor { get { return doctor; } }

        public DoctorController(IService service) {
            this.service = service;
            this.doctor = null;
        }
        public Doctor login(string username, string password) {
            Doctor doctor = service.loginDoctor(username, password, this);
            this.doctor = doctor;
            return doctor;
        }

        internal List<MedicalLetterDTO> getAllMedicalLetters() {
            MedicalLetterDTO[] medicalLetterDTOs = service.getAllMedicalLetters();
            List<MedicalLetterDTO> medicalLetters = new List<MedicalLetterDTO>();
            foreach(var medicalLetter in medicalLetterDTOs) {
                medicalLetters.Add(medicalLetter);
            }
            return medicalLetters;
        }

        internal List<PatientFullDTO> getAllPatients() {
            PatientFullDTO[] patientsDTO = service.getAllPatients();
            List<PatientFullDTO> patients = new List<PatientFullDTO>();
            foreach(var patient in patientsDTO) {
                patients.Add(patient);
            }
            return patients;
        }

        internal List<AppointmentDTO> getAppointmentsByDoctorDate(string doctor, string date) {
            AppointmentDTO[] appointmentDTOs = service.getAppointmentsByDateAndDoctor(date, doctor);
            List<AppointmentDTO> appointments = new List<AppointmentDTO>();
            foreach(var appointment in appointmentDTOs) {
                appointments.Add(appointment);
            }
            return appointments;
        }

        internal Patient findPatientByUsername(string patient) {
            return service.findPatientByUsername(patient);
        }

        public void logout() {
            service.logout(doctor, this);
            doctor = null;
        }

        public void addNewPatient(Patient patient) {
            DoctorUserEventArgs userEventArgs = new DoctorUserEventArgs(DoctorUserEvent.AddPatient, patient);
            Console.WriteLine("Add Patient");
            OnUserEvent(userEventArgs);
        }

        protected virtual void OnUserEvent(DoctorUserEventArgs userEventArgs) {
            if (updateEvent != null) return;
            //updateEvent(this, userEventArgs);
            Console.WriteLine("Update called");
        }

        internal Patient addPatient(string username, string password, string firstname, string lastname, string cnp, string address, string phone) {
            return service.addPatient(username, password, firstname, lastname, cnp, address, phone, this);
        }

        internal MedicalLetter createMedicalLetter(string patient, string doctor, string body, string date) {
            return service.createMedicalLetter(patient, doctor, body, date, this);
        }

        internal string getBodyByPacientDoctorDate(string pacient, string doctor, string date) {
            return service.getBodyByPacientDoctorDate(pacient, doctor, date);
        }

        internal Message sendMessage(string doctor, string patient, string text) {
            return service.sendMessage(doctor, patient, text);
        }

        internal List<MessageDTO> getMessagesByDoctorPatient(string username1, string username2) {
            MessageDTO[] messageDTOs = service.getMessagesByDoctorPatient(username1, username2);
            List<MessageDTO> messages = new List<MessageDTO>();
            foreach(var message in messageDTOs) {
                messages.Add(message);
            }
            return messages;
        }
    }
}
