using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos {
    [Serializable]
    public class SpecialityDTO {
        private string speciality;
        public string Speciality { get { return speciality; } set { speciality = value; } }

        public SpecialityDTO(string speciality) {
            this.speciality = speciality;
        }
    }
}
