using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDoctor{
    public enum DoctorUserEvent {
        AddPatient
    };
    public class DoctorUserEventArgs {
        private readonly DoctorUserEvent userEvent;
        private readonly Object data;
        public DoctorUserEventArgs(DoctorUserEvent userEvent, Object data) {
            this.userEvent = userEvent;
            this.data = data;
        }

        public DoctorUserEvent UserEventType { get { return userEvent; } }
        public object Data { get { return data; } }
    }
}
