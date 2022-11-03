using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientPatient {
    public class PatientLoginController {
        private IService service;
        public IService Service { get { return service; } }

        public PatientLoginController(IService service) {
            this.service = service;
        }
        public Patient login(string username, string password, IObserver observer) {
            return service.loginPatient(username, password, observer);
        }
    }
}
