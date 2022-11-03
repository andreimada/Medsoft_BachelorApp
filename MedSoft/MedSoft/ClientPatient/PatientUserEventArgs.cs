using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientPatient {
    public enum PatientUserEvent { };
    public class PatientUserEventArgs {
        private readonly PatientUserEvent userEvent;
        private readonly Object data;

        public PatientUserEventArgs(PatientUserEvent userEvent, object data) {
            this.userEvent = userEvent;
            this.data = data;
        }

        public PatientUserEvent UserEvent { get { return userEvent; } }
        public object Data { get { return data; } }
    }
}
