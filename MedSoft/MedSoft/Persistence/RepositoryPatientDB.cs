using Model;
using Model.Exceptions;
using Persistence.Validators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence {
    public class RepositoryPatientDB : IRepositoryPatient {
        private PatientValidator validator;
        public RepositoryPatientDB(PatientValidator validator) {
            this.validator = validator;
        }

        public void delete(int id) {
            throw new NotImplementedException();
        }

        public List<Patient> findAll() {
            List<Patient> patients = new List<Patient>();
            IDbConnection connection = DbUtils.getConnection();
            using (var command = connection.CreateCommand()) {
                command.CommandText = "select idPatient, username, password, firstname, lastname, cnp, address, phone from Patients order by lastname asc";
                using (var dataReader = command.ExecuteReader()) {
                    while (dataReader.Read()) {
                        int id = dataReader.GetInt32(0);
                        string username = dataReader.GetString(1);
                        string parola = dataReader.GetString(2);
                        string firstname = dataReader.GetString(3);
                        string lastname = dataReader.GetString(4);
                        string cnp = dataReader.GetString(5);
                        string address = dataReader.GetString(6);
                        string phone = dataReader.GetString(7);
                        Patient patient = new Patient(username, parola, lastname, firstname, cnp, address, phone);
                        patient.Id = id;
                        patients.Add(patient);
                    }
                }
            }
            return patients;
        }

        public Patient findByUsername(string username) {
            IDbConnection connection = DbUtils.getConnection();
            using (var command = connection.CreateCommand()) {
                command.CommandText = "select idPatient, username, password, firstname, lastname, cnp, address, phone from Patients where username=@username";
                IDbDataParameter parameter = command.CreateParameter();
                parameter.ParameterName = "@username";
                parameter.Value = username;
                command.Parameters.Add(parameter);
                using (var dataReader = command.ExecuteReader()) {
                    if (dataReader.Read()) {
                        int id = dataReader.GetInt32(0);
                        string parola = dataReader.GetString(2);
                        string firstname = dataReader.GetString(3);
                        string lastname = dataReader.GetString(4);
                        string cnp = dataReader.GetString(5);
                        string address = dataReader.GetString(6);
                        string phone = dataReader.GetString(7);
                        Patient patient = new Patient(username,parola,lastname,firstname,cnp,address,phone);
                        patient.Id = id;
                        return patient;
                    }
                }
            }
            return null;
        }

        public Patient findOne(int id) {
            throw new NotImplementedException();
        }

        public Patient save(Patient entity) {
            var connection = DbUtils.getConnection();
            //try {
            //    validator.validate(entity);
            //}
            //catch(ValidatorException ex) {
            //    throw new RepositoryException(ex.Message);
            //}
            using(var command = connection.CreateCommand()) {
                command.CommandText = "insert into Patients (username, password, firstname, lastname, cnp, address, phone) values (@username, @password, @firstname, @lastname, @cnp, @address, @phone)";
                
                IDbDataParameter parameterUsername = command.CreateParameter();
                parameterUsername.ParameterName = "@username";
                parameterUsername.Value = entity.Username;
                command.Parameters.Add(parameterUsername);
                
                IDbDataParameter parameterPassword = command.CreateParameter();
                parameterPassword.ParameterName = "@password";
                parameterPassword.Value = entity.Password;
                command.Parameters.Add(parameterPassword);

                IDbDataParameter parameterFirstname = command.CreateParameter();
                parameterFirstname.ParameterName = "@firstname";
                parameterFirstname.Value = entity.FirstName;
                command.Parameters.Add(parameterFirstname);

                IDbDataParameter parameterLastname = command.CreateParameter();
                parameterLastname.ParameterName = "@lastname";
                parameterLastname.Value = entity.LastName;
                command.Parameters.Add(parameterLastname);

                IDbDataParameter parameterCnp = command.CreateParameter();
                parameterCnp.ParameterName = "@cnp";
                parameterCnp.Value = entity.Cnp;
                command.Parameters.Add(parameterCnp);

                IDbDataParameter parameterAddress = command.CreateParameter();
                parameterAddress.ParameterName = "@address";
                parameterAddress.Value = entity.Address;
                command.Parameters.Add(parameterAddress);

                IDbDataParameter parameterPhone = command.CreateParameter();
                parameterPhone.ParameterName = "@phone";
                parameterPhone.Value= entity.Phone;
                command.Parameters.Add(parameterPhone);

                var result = command.ExecuteNonQuery();
                if (result == 0) {
                    throw new RepositoryException("Pacient neadaugat!");
                }
                else {
                    command.CommandText = "select last_insert_rowid() as id from Patients";
                    entity.Id = int.Parse(command.ExecuteScalar().ToString());
                    return entity;
                }
            }
        }

        public void update(Patient entity) {
            throw new NotImplementedException();
        }
    }
}
