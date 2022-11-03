using Model;
using Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence {
    public interface IRepositoryAppointment : IRepository<int,Appointment>{
        bool findByDoctorDateTime(string usernameDoctor, string date, string time);
        AppointmentDTO[] findByDoctor(string usernameDoctor);
        List<AppointmentDTO> findByDoctorAndDate(string usernameDoctor, string date);
    }
}
