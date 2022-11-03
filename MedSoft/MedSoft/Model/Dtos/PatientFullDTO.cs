using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos {
    [Serializable]
    public class PatientFullDTO {
        private string username;
        public string Username { get { return username; } set { username = value; } }

        private string password;
        public string Password { get { return password; } set { password = value; } }

        private string lastName;
        public string LastName { get { return lastName; } set { lastName = value; } }

        private string firstName;
        public string FirstName { get { return firstName; } set { firstName = value; } }

        private string cnp;
        public string Cnp { get { return cnp; } set { cnp = value; } }

        private string address;
        public string Address { get { return address; } set { address = value; } }

        private string phone;
        public string Phone { get { return phone; } set { phone = value; } }

        public PatientFullDTO(string uername, string password, string lastName, string firstName, string cnp, string address, string phone) {
            this.username = uername;
            this.password = password;
            this.lastName = lastName;
            this.firstName = firstName;
            this.cnp = cnp;
            this.address = address;
            this.phone = phone;
        }

        public override string ToString() {
            return this.firstName + " " + this.lastName;
        }
    }
}
