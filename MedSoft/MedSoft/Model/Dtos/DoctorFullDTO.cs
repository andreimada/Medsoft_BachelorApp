using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos {
    [Serializable]
    public class DoctorFullDTO {
        private string username;
        public string Username { get { return username; } set { username = value; } }

        private string password;
        public string Password { get { return password; } set { password = value; } }
        private string firstname;
        public string Firstname { get { return firstname; } set { firstname = value; } }
        private string lastname;
        public string Lastname { get { return lastname; } set { lastname = value; } }
        private string speciality;
        public string Speciality { get { return speciality; } set { speciality = value; } }

        public DoctorFullDTO(string username, string password, string firstname, string lastname, string speciality) {
            this.username = username;
            this.password = password;
            this.firstname = firstname;
            this.lastname = lastname;
            this.speciality = speciality;
        }

        public override string ToString() {
            return "dr. " + this.lastname + " " + this.firstname;
        }
    }
}
