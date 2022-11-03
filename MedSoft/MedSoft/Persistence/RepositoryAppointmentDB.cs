using Model;
using Model.Dtos;
using Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence {
    public class RepositoryAppointmentDB : IRepositoryAppointment {
        public void delete(int id) {
            throw new NotImplementedException();
        }

        public List<Appointment> findAll() {
            throw new NotImplementedException();
        }

        public AppointmentDTO[] findByDoctor(string usernameDoctor) {
            throw new NotImplementedException();
        }

        public List<AppointmentDTO> findByDoctorAndDate(string usernameDoctor, string date) {
            IDbConnection connection = DbUtils.getConnection();
            List<AppointmentDTO> appointments = new List<AppointmentDTO>();
            using(var command = connection.CreateCommand()) {
                command.CommandText = "select * from Appointments where usernameDoctor = @usernameDoctor and date = @date order by time asc";
                IDbDataParameter parameterDoctor = command.CreateParameter();
                parameterDoctor.ParameterName = "@usernameDoctor";
                parameterDoctor.Value = usernameDoctor;
                command.Parameters.Add(parameterDoctor);
                IDbDataParameter parameterDate = command.CreateParameter();
                parameterDate.ParameterName = "@date";
                parameterDate.Value = date;
                command.Parameters.Add(parameterDate);
                using(var dataReader = command.ExecuteReader()) {
                    while (dataReader.Read()) {
                        string usernamePatient = dataReader.GetString(2);
                        string time = dataReader.GetString(4);
                        AppointmentDTO appointment = new AppointmentDTO(usernamePatient, usernameDoctor, date, time);
                        appointments.Add(appointment);
                    }
                }
            }
            return appointments;    
        }

        public bool findByDoctorDateTime(string usernameDoctor, string date, string time) {
            IDbConnection connection = DbUtils.getConnection();
            List<AppointmentDTO> appointments = new List<AppointmentDTO>();
            using (var command = connection.CreateCommand()) {
                command.CommandText = "select * from Appointments where usernameDoctor = @usernameDoctor and date = @date and time = @time";
                IDbDataParameter parameterDoctor = command.CreateParameter();
                parameterDoctor.ParameterName = "@usernameDoctor";
                parameterDoctor.Value = usernameDoctor;
                command.Parameters.Add(parameterDoctor);
                IDbDataParameter parameterDate = command.CreateParameter();
                parameterDate.ParameterName = "@date";
                parameterDate.Value = date;
                command.Parameters.Add(parameterDate);
                IDbDataParameter parameterTime = command.CreateParameter();
                parameterTime.ParameterName = "@time";
                parameterTime.Value = time;
                command.Parameters.Add(parameterTime);
                using (var dataReader = command.ExecuteReader()) {
                    if (dataReader.Read()) {
                        return true;
                    }
                }
            }
            return false;
        }

        public Appointment findOne(int id) {
            throw new NotImplementedException();
        }

        public Appointment save(Appointment entity) {
            var connection = DbUtils.getConnection();
            if (findByDoctorDateTime(entity.Doctor, entity.Date, entity.Time) == false) {
                using (var command = connection.CreateCommand()) {
                    command.CommandText = "insert into Appointments (usernameDoctor, usernamePatient, date, time) values (@doctor, @patient, @date, @time)";
                    IDbDataParameter parameterDoctor = command.CreateParameter();
                    parameterDoctor.ParameterName = "@doctor";
                    parameterDoctor.Value = entity.Doctor;
                    command.Parameters.Add(parameterDoctor);
                    IDbDataParameter parameterPatient = command.CreateParameter();
                    parameterPatient.ParameterName = "@patient";
                    parameterPatient.Value = entity.Patient;
                    command.Parameters.Add(parameterPatient);
                    IDbDataParameter parameterDate = command.CreateParameter();
                    parameterDate.ParameterName = "@date";
                    parameterDate.Value = entity.Date;
                    command.Parameters.Add(parameterDate);
                    IDbDataParameter parameterTime = command.CreateParameter();
                    parameterTime.ParameterName = "@time";
                    parameterTime.Value = entity.Time;
                    command.Parameters.Add(parameterTime);

                    var result = command.ExecuteNonQuery();
                    if (result == 0) {
                        throw new RepositoryException("Nu a fost facuta programarea!");
                    }
                    else {
                        command.CommandText = "select last_insert_rowid() as id from Appointments";
                        entity.Id = int.Parse(command.ExecuteScalar().ToString());
                        return entity;
                    }
                }
            }
            else {
                throw new RepositoryException("Exista o programare cu aceste detalii efectuate");
            }
        }

        public void update(Appointment entity) {
            throw new NotImplementedException();
        }
    }
}
