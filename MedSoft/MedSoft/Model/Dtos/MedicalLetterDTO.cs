using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos {
    [Serializable]
    public class MedicalLetterDTO {
        private string patient;
        private string doctor;
        private string body;
        private string date;
        public string Patient { get { return patient; } set { patient = value; } }
        public string Doctor { get { return doctor; } set { doctor = value; } }
        public string Body { get { return body; } set { body = value; } }
        public string Date { get { return date; } set { date = value; } }

        public MedicalLetterDTO(string patient, string doctor, string body, string date) {
            this.patient = patient;
            this.doctor = doctor;
            this.body = body;
            this.date = date;
        }
    }
}
