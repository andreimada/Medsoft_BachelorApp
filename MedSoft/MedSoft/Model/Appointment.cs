using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model {
    public class Appointment : Entity<int> {
        private string patient;
        private string doctor;
        private string date;
        private string time;

        public string Patient { get { return patient; } set { patient = value; } }
        public string Doctor { get { return doctor; } set { doctor = value; } }
        public string Date { get { return date; } set { date = value; } }
        public string Time { get { return time; } set { time = value; } }

        public Appointment(string patient, string doctor, string date, string time) {
            this.patient = patient;
            this.doctor = doctor;
            this.date = date;
            this.time = time;
        }
    }
}
