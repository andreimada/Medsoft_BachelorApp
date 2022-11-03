using Model;
using Model.Dtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence {
    public class RepositoryDoctorDB : IRepositoryDoctor {
        public RepositoryDoctorDB() {
        }

        public void delete(int id) {
            throw new NotImplementedException();
        }

        public List<Doctor> findAll() {
            List<Doctor> doctors = new List<Doctor>();
            var connection = DbUtils.getConnection();
            using(var command = connection.CreateCommand()) {
                command.CommandText = "select * from Doctors order by lastname asc";
                using(var dataReader = command.ExecuteReader()) {
                    while (dataReader.Read()) {
                        string username = dataReader.GetString(1);
                        string password = dataReader.GetString(2);
                        string firstname = dataReader.GetString(3);
                        string lastname = dataReader.GetString(4);
                        string speciality = dataReader.GetString(5);
                        doctors.Add(new Doctor(username, password, firstname, lastname, speciality));
                    }
                }
            }
            return doctors;
        }

        public Doctor findByUsername(string username) {
            IDbConnection connection = DbUtils.getConnection();
            using(var command = connection.CreateCommand()) {
                command.CommandText = "select idDoctor, username, password, firstname, lastname, speciality from Doctors where username=@username";
                IDbDataParameter parameter = command.CreateParameter();
                parameter.ParameterName = "@username";
                parameter.Value = username;
                command.Parameters.Add(parameter);
                using(var dataReader = command.ExecuteReader()) {
                    if (dataReader.Read()) {
                        int id = dataReader.GetInt32(0);
                        string parola = dataReader.GetString(2);
                        string firstname = dataReader.GetString(3);
                        string lastname = dataReader.GetString(4);
                        string speciality = dataReader.GetString(5);
                        Doctor doctor = new Doctor(username,parola, firstname, lastname, speciality);
                        doctor.Id = id;
                        return doctor;
                    }
                }
            }
            return null;
        }

        public Doctor findOne(int id) {
            throw new NotImplementedException();
        }

        public String[] getAllSpecialities() {
            IDbConnection connection = DbUtils.getConnection();
            List<String> specialities = new List<String>();

            using (var command = connection.CreateCommand()) {
                command.CommandText = "select distinct speciality from Doctors order by speciality asc";
                using (var dataReader = command.ExecuteReader()) {
                    while (dataReader.Read()) {
                        String speciality = dataReader.GetString(0);
                        specialities.Add(speciality);
                    }
                }
            }
            int length = specialities.Count;
            String[] specialitiesArray = new string[length];
            for(int i = 0; i < length; i++) {
                specialitiesArray[i] = specialities[i].ToString();
            }
            return specialitiesArray;
        }

        public List<DoctorFullDTO> getDoctorBySpeciality(string speciality) {
            IDbConnection connection = DbUtils.getConnection();
            List<DoctorFullDTO> doctors = new List<DoctorFullDTO>();
            using (var command = connection.CreateCommand()) {
                command.CommandText = "select * from Doctors where speciality = @speciality order by lastname asc";
                IDbDataParameter parameter = command.CreateParameter();
                parameter.ParameterName = "@speciality";
                parameter.Value = speciality;
                command.Parameters.Add(parameter);
                using (var dataReader = command.ExecuteReader()) {
                    while (dataReader.Read()) {
                        int id = dataReader.GetInt32(0);
                        string username = dataReader.GetString(1);
                        string parola = dataReader.GetString(2);
                        string firstname = dataReader.GetString(3);
                        string lastname = dataReader.GetString(4);
                        DoctorFullDTO doctor = new DoctorFullDTO(username, parola, firstname, lastname, speciality);
                        doctors.Add(doctor);
                    }
                }
            }
            return doctors;
        }

        public Doctor save(Doctor entity) {
            throw new NotImplementedException();
        }

        public void update(Doctor entity) {
            throw new NotImplementedException();
        }
    }
}
