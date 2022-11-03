using Model;
using Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence {
    public interface IRepositoryMessage : IRepository<int, Message> {
        List<MessageDTO> findByPatientAndDoctor(string usernameDoctor, string usernamePatient);
    }
}
