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
    public class RepositoryMessageDB : IRepositoryMessage {
        public void delete(int id) {
            throw new NotImplementedException();
        }

        public List<Message> findAll() {
            throw new NotImplementedException();
        }

        public List<MessageDTO> findByPatientAndDoctor(string usernameDoctor, string usernamePatient) {
            List<MessageDTO> messages = new List<MessageDTO>();
            var connection = DbUtils.getConnection();
            using(var command = connection.CreateCommand()) {
                command.CommandText = "select * from Messages where (fromM = @doctor and toM = @patient) or (fromM = @patient and toM = @doctor)";
                IDbDataParameter parameterDoctor = command.CreateParameter();
                parameterDoctor.ParameterName = "@doctor";
                parameterDoctor.Value = usernameDoctor;
                command.Parameters.Add(parameterDoctor);
                IDbDataParameter parameterPatient = command.CreateParameter();
                parameterPatient.ParameterName = "@patient";
                parameterPatient.Value = usernamePatient;
                command.Parameters.Add(parameterPatient);
                using(var dataReader = command.ExecuteReader()) {
                    while (dataReader.Read()) {
                        string from = dataReader.GetString(1);
                        string to = dataReader.GetString(2);
                        string text = dataReader.GetString(3);
                        messages.Add(new MessageDTO(from, to, text));
                    }
                }
            }
            return messages;
        }

        public Message findOne(int id) {
            throw new NotImplementedException();
        }

        public Message save(Message entity) {
            var connection = DbUtils.getConnection();
            using(var command = connection.CreateCommand()) {
                command.CommandText = "insert into Messages (fromM, toM, textM) values (@fromM, @toM, @textM)";

                IDbDataParameter parameterFrom = command.CreateParameter();
                parameterFrom.ParameterName = "@fromM";
                parameterFrom.Value = entity.FromUsername;
                command.Parameters.Add(parameterFrom);
                IDbDataParameter parameterTo = command.CreateParameter();
                parameterTo.ParameterName = "@toM";
                parameterTo.Value = entity.ToUsername;
                command.Parameters.Add(parameterTo);
                IDbDataParameter parameterText = command.CreateParameter();
                parameterText.ParameterName = "@textM";
                parameterText.Value = entity.Text;
                command.Parameters.Add(parameterText);
                
                var result = command.ExecuteNonQuery();
                if (result == 0) {
                    throw new RepositoryException("Nu a fost adaugat mesajul");
                }
                else {
                    command.CommandText = "select last_insert_rowid() as id from Messages";
                    entity.Id = int.Parse(command.ExecuteScalar().ToString());
                    return entity;
                }
            }
        }

        public void update(Message entity) {
            throw new NotImplementedException();
        }
    }
}
