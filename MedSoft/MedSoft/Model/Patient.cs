using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    public class Patient:User {

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

        public Patient(string username, string password, string lastName, string firstName, string cnp, string address, string phone) : base(username, password) {
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Cnp = cnp;
            this.Address = address;
            this.Phone = phone;
        }
        public override string ToString() {
            return this.firstName + " " + this.lastName;
        }
    }
}
