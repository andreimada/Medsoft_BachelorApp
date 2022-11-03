using Model;
using Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence {
    public interface IRepositoryDoctor: IRepository<int, Doctor> {
        Doctor findByUsername(string username);
        String[] getAllSpecialities();

        List<DoctorFullDTO> getDoctorBySpeciality(string speciality);
    }
}
