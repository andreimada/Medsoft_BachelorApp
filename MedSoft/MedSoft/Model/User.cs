using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    [Serializable]
    public class User:Entity<int> {
        private string username;
        public string Username { get { return username; } set { username = value; } }

        private string password;
        public string Password { get { return password; } set { password = value; } }

        public User(string username, string password) {
            this.username = username;
            this.password = password;
        }
    }
}
