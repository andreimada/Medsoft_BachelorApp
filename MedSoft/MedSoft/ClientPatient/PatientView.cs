using Model;
using Model.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientPatient {
    public partial class PatientView : Form {
        private PatientController ctrl;
        private PatientLogin logIn;

        public PatientView(PatientController ctrl, PatientLogin logIn) {
            this.ctrl = ctrl;
            this.logIn = logIn;
            Console.WriteLine("Starting patient view.........");
            InitializeComponent();
            setDetailsPanel();
            setSpecialitiesComboBox();
            setAllDoctors();
        }

        private void setAllDoctors() {
            comboDoctorsMessage.Items.Clear();
            foreach(var doctor in ctrl.getAllDoctors()) {
                comboDoctorsMessage.Items.Add(doctor);
            }
        }

        private void setSpecialitiesComboBox() {
            foreach(string speciality in ctrl.getSpecialities()) {
                comboSpeciality.Items.Add(speciality);
            }
            comboSpeciality.SelectedIndex = 0;
        }

        private void setDetailsPanel() {
            textBoxName.Text = ctrl.Patient.LastName;
            textBoxFirstname.Text = ctrl.Patient.FirstName;
            textBoxCnp.Text = ctrl.Patient.Cnp;
            textBoxAddress.Text = ctrl.Patient.Address;
            textBoxPhone.Text = ctrl.Patient.Phone;
        }

        private void buttonLogout_Click(object sender, EventArgs e) {
            logIn.Show();
            this.Close();
        }

        private void buttonMakeAppointment_Click(object sender, EventArgs e) {
            Patient patient = ctrl.Patient;
            DoctorFullDTO doctorFullDTO = comboDoctor.SelectedItem as DoctorFullDTO;
            string date = datePicker.Value.ToString("yyyy-MM-dd");
            string dateDisplay = datePicker.Value.ToString("dd.MM.yyyy");
            string time = "";

            if (comboTime.SelectedIndex > -1) {
                time = comboTime.SelectedItem.ToString();
                if (doctorFullDTO != null) {
                    DialogResult dialogResult = MessageBox.Show("Confirmati programarea la " + doctorFullDTO.ToString() + ", la data: " + dateDisplay + ", ora: " + time + "?", "Confirmare programare", MessageBoxButtons.YesNo);
                    if (dialogResult.Equals(DialogResult.Yes)) {
                        ctrl.makeAppointment(patient.Username, doctorFullDTO.Username, date, time);
                        MessageBox.Show("Programare efectuata");
                    }
                }
                else {
                    MessageBox.Show("Nu a fost selectat doctorul");
                }
            }
            else {
                MessageBox.Show("Nu a fost selectata ora");
            }
        }

        private void comboSpeciality_SelectedIndexChanged(object sender, EventArgs e) {
            string speciality = comboSpeciality.Text;
            setDoctorsComboBox(speciality);
            comboTime.Items.Clear();
            comboTime.Text = "";
        }

        private void setDoctorsComboBox(string speciality) {
            comboDoctor.Items.Clear();
            comboDoctor.Text = "";
            foreach(DoctorFullDTO doctorDTO in ctrl.getDoctorsBySpeciality(speciality)) {
                comboDoctor.Items.Add(doctorDTO);
            }
            comboTime.Items.Clear();
            comboTime.Text = "";
        }

        private void datePicker_ValueChanged(object sender, EventArgs e) {
            comboTime.Items.Clear();
            comboTime.Text = "";
            string date = datePicker.Value.ToString("yyyy-MM-dd");
            DoctorFullDTO doctor = (DoctorFullDTO)comboDoctor.SelectedItem;
            if (doctor != null) {
                setHours(date, doctor.Username);
            }
        }

        private void setHours(string date, string doctor) {
            comboTime.Text = "";
            List<int> avabileHours = new List<int>();
            for (int i = 10; i <= 19; i++) {
                avabileHours.Add(i);
            }
            foreach(AppointmentDTO appointment in ctrl.getAppointmentsByDateAndDoctor(date, doctor)) {
                int time = Int32.Parse(appointment.Time);
                avabileHours.Remove(time);
            }
            foreach (var hour in avabileHours) {
                comboTime.Items.Add(hour);
            }
        }

        private void comboDoctor_SelectedIndexChanged(object sender, EventArgs e) {
            comboTime.Items.Clear();
            comboDoctor.Text = "";
            DoctorFullDTO doctor = (DoctorFullDTO)comboDoctor.SelectedItem;
            setHours(datePicker.Value.ToString("yyyy-MM-dd"), doctor.Username);
        }

        private void comboDoctorsMessage_SelectedIndexChanged(object sender, EventArgs e) {
            setTextHistory();
        }

        private void setTextHistory() {
            textAllMessages.Text = "";
            DoctorFullDTO doctorDTO = comboDoctorsMessage.SelectedItem as DoctorFullDTO;
            if(doctorDTO != null)
            foreach (var message in ctrl.getMessagesByDoctorPatient(ctrl.Patient.Username, doctorDTO.Username)) {
                if (message.FromUsername.Equals(ctrl.Patient.Username)) {
                    textAllMessages.SelectionColor = Color.Red;
                    textAllMessages.AppendText(ctrl.Patient.ToString());
                    textAllMessages.SelectionColor = Color.Black;
                    textAllMessages.AppendText(": " + message.Text + Environment.NewLine);
                    //textAllMessages.ForeColor = Color.Red;
                    //textAllMessages.Text += ctrl.Doctor.ToString();
                    //textAllMessages.ForeColor = Color.Black;
                    //textAllMessages.Text += ": ";
                    //textAllMessages.Text += message.Text;
                    //textAllMessages.Text += Environment.NewLine;
                }
                else {
                    textAllMessages.SelectionColor = Color.DarkCyan;
                    textAllMessages.AppendText(doctorDTO.ToString());
                    textAllMessages.SelectionColor = Color.Black;
                    textAllMessages.AppendText(": " + message.Text + Environment.NewLine);
                    //    textAllMessages.ForeColor = Color.DarkCyan;
                    //    textAllMessages.Text += patientFullDTO.ToString();
                    //    textAllMessages.ForeColor = Color.Black;
                    //    textAllMessages.Text += ": ";
                    //    textAllMessages.Text += message.Text;
                    //    textAllMessages.Text += Environment.NewLine;
                }
            }
        }

        private void buttonSendMessage_Click(object sender, EventArgs e) {
            string patient = ctrl.Patient.Username;
            string text = textCurrentMessage.Text;
            DoctorFullDTO doctorFullDTO = comboDoctorsMessage.SelectedItem as DoctorFullDTO;
            string doctor = doctorFullDTO.Username;
            ctrl.sendMessage(patient, doctor, text);
            textCurrentMessage.Text = "";
        }

        private void buttonRefresh_Click(object sender, EventArgs e) {
            updateStuff();
        }

        private void updateStuff() {
            setTextHistory();
        }
    }
}
