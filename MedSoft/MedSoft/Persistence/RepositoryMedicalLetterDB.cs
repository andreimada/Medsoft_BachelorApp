using Model;
using Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence {
    public class RepositoryMedicalLetterDB : IRepositoryMedicalLetter {
        public void delete(int id) {
            throw new NotImplementedException();
        }

        public List<MedicalLetter> findAll() {
            List<MedicalLetter> medicalLetters = new List<MedicalLetter>();
            IDbConnection connection = DbUtils.getConnection();
            using (var command = connection.CreateCommand()) {
                command.CommandText = "select * from MedicalLetters order by date desc";
                using (var dataReader = command.ExecuteReader()) {
                    while (dataReader.Read()) {
                        string patient = dataReader.GetString(1);
                        string doctor = dataReader.GetString(2);
                        string body = dataReader.GetString(3);
                        string date = dataReader.GetString(4);
                        MedicalLetter medicalLetter = new MedicalLetter(patient, doctor, body, date);
                        medicalLetter.Id = dataReader.GetInt32(0);
                        medicalLetters.Add(medicalLetter);
                    }
                }
            }
            return medicalLetters;
        }

        public string getBodyByPatientDoctorDate(string patient, string doctor, string date) {
            string body="";
            IDbConnection connection = DbUtils.getConnection();
            using (var command = connection.CreateCommand()) {
                command.CommandText = "select body from MedicalLetters where patient = @patient and doctor = @doctor and date = @date";
                IDbDataParameter parameterPatient = command.CreateParameter();
                parameterPatient.ParameterName = "@patient";
                parameterPatient.Value = patient;
                command.Parameters.Add(parameterPatient);
                IDbDataParameter parameterDoctor = command.CreateParameter();
                parameterDoctor.ParameterName = "@doctor";
                parameterDoctor.Value = doctor;
                command.Parameters.Add(parameterDoctor);
                IDbDataParameter parameterDate = command.CreateParameter();
                parameterDate.ParameterName = "@date";
                parameterDate.Value = date;
                command.Parameters.Add(parameterDate);
                using (var dataReader = command.ExecuteReader()) {
                    if (dataReader.Read()) {
                        body = dataReader.GetString(0);                       
                    }
                }
            }
            return body;
        }

        public MedicalLetter findOne(int id) {
            throw new NotImplementedException();
        }

        public MedicalLetter save(MedicalLetter entity) {
            var connection = DbUtils.getConnection();
            using(var command = connection.CreateCommand()) {
                command.CommandText = "insert into MedicalLetters (patient, doctor, body, date) values (@patient, @doctor, @body, @date)";
                IDbDataParameter parameterPatient = command.CreateParameter();
                parameterPatient.ParameterName = "@patient";
                parameterPatient.Value = entity.Patient;
                command.Parameters.Add(parameterPatient);
                IDbDataParameter parameterDoctor = command.CreateParameter();
                parameterDoctor.ParameterName = "@doctor";
                parameterDoctor.Value = entity.Doctor;
                command.Parameters.Add(parameterDoctor);
                IDbDataParameter parameterBody = command.CreateParameter();
                parameterBody.ParameterName = "@body";
                parameterBody.Value = entity.Body;
                command.Parameters.Add(parameterBody);
                IDbDataParameter parameterDate = command.CreateParameter();
                parameterDate.ParameterName = "@date";
                parameterDate.Value = entity.Date;
                command.Parameters.Add(parameterDate);

                var result = command.ExecuteNonQuery();
                if(result == 0) {
                    throw new RepositoryException("Nu a fost creata scrisoarea medicala");
                }
                else {
                    command.CommandText = "select last_insert_rowid() as id from MedicalLetters";
                    entity.Id = int.Parse(command.ExecuteScalar().ToString());
                    return entity;
                }
            }
        }

        public void update(MedicalLetter entity) {
            throw new NotImplementedException();
        }
    }
}
