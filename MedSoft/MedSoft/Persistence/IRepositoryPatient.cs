using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence {
    public interface IRepositoryPatient: IRepository<int, Patient> {
        Patient findByUsername(string username);
    }
}
