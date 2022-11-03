using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence {
    public interface IRepositoryMedicalLetter : IRepository<int, MedicalLetter>{
        string getBodyByPatientDoctorDate(string patient, string doctor, string date);
    }
}
