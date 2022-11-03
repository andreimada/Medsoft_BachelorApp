using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos {
    [Serializable]
    public class PatientDTO {
        private string username;
        private string password;
        public string Username { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }

        public PatientDTO(string username, string password) {
            this.username = username;
            this.password = password;
        }

        public override string ToString() {
            return "Patient{Username: "+ this.username + " | Password: " + this.password + " }";
        }
    }
}
