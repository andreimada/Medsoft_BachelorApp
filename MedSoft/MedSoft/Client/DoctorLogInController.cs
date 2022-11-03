using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDoctor {
    public class DoctorLogInController {
        private IService service;
        public IService Service { get { return service; } }
        public DoctorLogInController(IService service) {
            this.service = service;
        }
        public User logIn(string username, string password, IObserver observer) {
            return service.loginDoctor(username, password, observer);
        }
    }
}
