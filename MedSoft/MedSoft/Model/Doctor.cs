using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    public class Doctor : User {
        private string firstname;
        public string Firstname { get { return firstname; } set { firstname = value; } }
        private string lastname;
        public string Lastname { get { return lastname; } set { lastname = value; } }
        private string speciality;
        public string Speciality { get { return speciality; } set { speciality = value; } }

        public Doctor(string username, string password, string firstname, string lastname, string speciality) : base(username, password) {
            this.firstname = firstname;
            this.lastname = lastname;
            this.speciality = speciality;
        }

        public override string ToString() {
            return "dr. " + this.lastname + " " + this.firstname;
        }
    }
}
