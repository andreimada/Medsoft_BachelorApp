using Model;
using Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service {
    public interface IService {
        Doctor loginDoctor(string username, string password, IObserver observer);
        Patient loginPatient(string username, string password, IObserver observer);
        Patient addPatient(string username, string password, string firstname, string lastname, string cnp, string address, string phone, IObserver observer);
        void logout(Doctor user, IObserver observer);
        void logout(Patient user, IObserver observer);
        String[] getSpecialities();
        DoctorFullDTO[] getDoctorsBySpeciality(string speciality);
        AppointmentDTO[] getAppointmentsByDateAndDoctor(string date, string doctor);
        Appointment makeAppointment(string patient, string doctor, string date, string time, IObserver observer);
        MedicalLetter createMedicalLetter(string patient, string doctor, string body, string date, IObserver observer);
        MedicalLetterDTO[] getAllMedicalLetters();
        PatientFullDTO[] getAllPatients();
        string getBodyByPacientDoctorDate(string pacient, string doctor, string date);
        Patient findPatientByUsername(string patient);
        Message sendMessage(string from, string to, string text);
        DoctorFullDTO[] getAllDoctors();
        MessageDTO[] getMessagesByDoctorPatient(string username1, string username2);
    }
}
