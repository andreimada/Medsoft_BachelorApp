using Model;
using Model.Dtos;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientPatient {
    public class PatientController : IObserver {
        private IService service;
        private Patient patient;
        //public event EventHandler<PatientUserEventArgs> updateEvent;
        public IService Service { get { return service; } }
        public Patient Patient { get { return patient; } }

        public PatientController(IService service) {
            this.service = service;
            this.patient = null;
        }
        public Patient login(string username, string password) {
            Patient patient = service.loginPatient(username, password, this);
            this.patient = patient;
            return patient;
        }

        public List<string> getSpecialities() {
            
            List<string> specialities = new List<string>();
            
            String[] specialitiesDTO = service.getSpecialities();
            
            foreach (string speciality in specialitiesDTO) {
                specialities.Add(speciality);
            }
            
            return specialities;
        }

        internal List<DoctorFullDTO> getAllDoctors() {
            List<DoctorFullDTO> doctors = new List<DoctorFullDTO>();
            DoctorFullDTO[] doctorFullDTOs = service.getAllDoctors();
            foreach(var doctor in doctorFullDTOs) {
                doctors.Add(doctor);
            }
            return doctors;
        }

        public void logout() {
            service.logout(patient, this);
            patient = null;
        }

        public void addNewPatient(Patient patient) {
            throw new NotImplementedException();
        }

        internal List<DoctorFullDTO> getDoctorsBySpeciality(string speciality) {
            List<DoctorFullDTO> doctors = new List<DoctorFullDTO>();
            DoctorFullDTO[] doctorsDTO = service.getDoctorsBySpeciality(speciality);
            foreach (DoctorFullDTO doctor in doctorsDTO) {
                doctors.Add(doctor);
            }
            return doctors;
        }

        internal List<AppointmentDTO> getAppointmentsByDateAndDoctor(string date, string doctor) {
            List<AppointmentDTO> appointments = new List<AppointmentDTO>();
            AppointmentDTO[] appointmentsDTO = service.getAppointmentsByDateAndDoctor(date, doctor);
            foreach (AppointmentDTO appointment in appointmentsDTO) {
                appointments.Add(appointment);
            }
            return appointments;
        }

        internal Appointment makeAppointment(string patient, string doctor, string date, string time) {
            return service.makeAppointment(patient, doctor, date, time, this);
        }

        internal Message sendMessage(string patient, string doctor, string text) {
            return service.sendMessage(patient, doctor, text);
        }

        internal List<MessageDTO> getMessagesByDoctorPatient(string username1, string username2) {
            MessageDTO[] messageDTOs = service.getMessagesByDoctorPatient(username1, username2);
            List<MessageDTO> messages = new List<MessageDTO>();
            foreach (var message in messageDTOs) {
                messages.Add(message);
            }
            return messages;
        }
    }
}