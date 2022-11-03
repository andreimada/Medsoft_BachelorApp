using iTextSharp.text;
using iTextSharp.text.pdf;
using Model;
using Model.Dtos;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ClientDoctor {
    public partial class DoctorView : Form {
        private DoctorController ctrl;
        private DoctorLogin logIn;

        public DoctorView(DoctorController ctrl, DoctorLogin logIn) {
            
            this.ctrl = ctrl;
            this.logIn = logIn;
            InitializeComponent();
            //timer1 = new Timer();
            //timer1.Interval = 10 * 1000;
            //timer1.Tick += new EventHandler(timer_Tick);
            //timer1.Start();
            setPatientCombo();
            setMedicalLetterTable();
            setAppointments(dateGeneral.Value.ToString("yyyy-MM-dd"));
        }

        public delegate void UpdateCallback();
        public void userUpdate(object sender, DoctorUserEventArgs args) {
            BeginInvoke(new UpdateCallback(this.updateStuff), new Object[] { });
        }

        private void updateStuff() {
            setPatientCombo();
            setMedicalLetterTable();
            setAppointments(dateGeneral.Value.ToString("yyyy-MM-dd"));
            setTextHistory();
        }

        private void timer_Tick(object sender, EventArgs e) {
            updateStuff();
        }

        private void setAppointments(string date) {
            dataGridGeneral.Rows.Clear();
            foreach(AppointmentDTO appointment in ctrl.getAppointmentsByDoctorDate(ctrl.Doctor.Username, dateGeneral.Value.ToString("yyyy-MM-dd"))) {
                dataGridGeneral.Rows.Add(ctrl.findPatientByUsername(appointment.Patient).ToString(),appointment.Time);
            }
        }

        private void setMedicalLetterTable() {
            dataGridView.Rows.Clear();
            foreach (MedicalLetterDTO medicalLetter in ctrl.getAllMedicalLetters()) {
                dataGridView.Rows.Add(medicalLetter.Patient, medicalLetter.Doctor, getDiagnostic(medicalLetter.Body), medicalLetter.Date);
            }
        }

        private void setPatientCombo() {
            comboPatient.Items.Clear();
            comboPatientsMessage.Items.Clear();
            foreach(PatientFullDTO patient in ctrl.getAllPatients()) {
                comboPatientsMessage.Items.Add(patient);
                comboPatient.Items.Add(patient);
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e) {
            logIn.Show();
            this.Close();
        }

        private void buttonAddPatient_Click(object sender, EventArgs e) {
            string username = textBoxFirstname.Text.ToLower() + textBoxName.Text.ToLower();
            string password = textBoxFirstname.Text.ToLower();
            string firstname = textBoxFirstname.Text;
            string lastname = textBoxName.Text;
            string address = textBoxAddress.Text;
            string phone = textBoxPhone.Text;
            string cnp = textBoxCnp.Text;
            if (firstname.Trim().Equals("") || lastname.Trim().Equals("") || address.Trim().Equals("") || cnp.Trim().Equals("") || phone.Trim().Equals("")) {
                MessageBox.Show("Toate campurile trebuie completate");
            }
            else {
                try {
                    ctrl.addPatient(username, password, firstname, lastname, cnp, address, phone);
                    textBoxAddress.Text = "";
                    textBoxCnp.Text = "";
                    textBoxFirstname.Text = "";
                    textBoxName.Text = "";
                    textBoxPhone.Text = "";
                    MessageBox.Show("Pacient adaugat!");
                }
                catch (MedsoftException err) {
                    MessageBox.Show(err.Message);
                }
            }
            setPatientCombo();
        }
        private string getDiagnostic(string body) {
            string diagnostic = "";
            string[] text;
            text = body.Split(':');
            text = text[2].Split('\n');
            foreach(var txt in text) {
                if (!txt.Equals("Anamneza")) {
                    diagnostic += txt + ";";
                }
            }
            return diagnostic;
        }

        private void buttonCreateMedicalLetter_Click(object sender, EventArgs e) {
            Doctor doctor = ctrl.Doctor;
            PatientFullDTO patient = comboPatient.SelectedItem as PatientFullDTO;
            string diagnostic = textBoxDiagnostic.Text;
            diagnostic = diagnostic == "" ? "N/A" : diagnostic;
            string anamneza = textBoxAnamneza.Text;
            anamneza = anamneza == "" ? "N/A" : anamneza;
            string treatment = textBoxTreatment.Text;
            treatment = treatment == "" ? "N/A" : treatment;
            string recommended = textBoxRecommendedTreatment.Text;
            recommended = recommended == "" ? "N/A" : recommended;
            string exams = textBoxExams.Text;
            exams = exams == "" ? "N/A" : exams;
            string date = DateTime.Now.ToString("dd.MM.yyyy");
            string dateDb = DateTime.Now.ToString("yyyy-MM-dd");
            if (patient != null) {
                string body = "\t\tSCRISOARE MEDICALA\n\nDenumire furnizor: MedSoft \nMedic " + doctor.Lastname + " " + doctor.Firstname + "\n\n\tStimate(a) coleg(a), va " +
                "informam ca " + patient.LastName + " " + patient.FirstName + ", CNP " + patient.Cnp + " a fost consultat in serviciul nostru la data " +
                "de " + date + ".\n\nDiagnostic: " + diagnostic + "\nAnamneza: " + anamneza + "\nExamene: " + exams + "\nTratament efectuat: " + treatment + "\n" +
                "Tratament recomandat: " + recommended+"\n\n------------\nScrisoarea medicala este un document tipizat care se intocmeste la data examinarii" +
                ", intr-un singur exemplat care este transmis medicului de familie / medicului specialist, direct ori prin intermediul paciantului.\n\n Data " + date;
                DialogResult dialog = MessageBox.Show(body, "Previzualizare", MessageBoxButtons.OKCancel);
                if (dialog == DialogResult.OK) {
                    ctrl.createMedicalLetter(patient.Username, doctor.Username, body.ToString(), dateDb);
                    MessageBox.Show("Scrisoare medicala creeata");
                    setMedicalLetterTable();
                }
            }
            else {
                MessageBox.Show("Trebuie ales un pacient");
            }
        }

        private void buttonRefreshTable_Click(object sender, EventArgs e) {
            setMedicalLetterTable();
        }

        private void buttonDownload_Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "Text files (*.txt) | *.txt|PDF Files (*.pdf)|*.pdf| All files (*.*) | *.*";
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveFileDialog.FileName = "ScrisoareMedicala";
            
            if(dataGridView.SelectedRows[0] != null) {
                DataGridViewRow row = dataGridView.SelectedRows[0];
                string pacient = row.Cells[0].Value.ToString();
                string doctor = row.Cells[1].Value.ToString();
                string date = row.Cells[3].Value.ToString();
                string body = ctrl.getBodyByPacientDoctorDate(pacient, doctor, date);
                string bodyPdf = body.Replace("\n", "<br>");
                bodyPdf = body.Replace("\t", "       ");
                if(saveFileDialog.ShowDialog() == DialogResult.OK) {
                    //StreamWriter writer = new StreamWriter(saveFileDialog.OpenFile());
                    //writer.WriteLine(bodyPdf);
                    //writer.Dispose();
                    //writer.Close();
                    using(FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create)) {
                        Document pdfDoc = new Document(PageSize.A4, 90f, 90f, 100f, 100f);
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        pdfDoc.Add(new Paragraph(bodyPdf));
                        pdfDoc.Close();
                    }
                    
                }
            }
            else {
                MessageBox.Show("Niciun rand selectat");
            }
            
        }

        private void buttonRefreshAll_Click(object sender, EventArgs e) {
            updateStuff();
        }

        private void comboPatientsMessage_SelectedIndexChanged(object sender, EventArgs e) {
            setTextHistory();
        }

        private void setTextHistory() {
            textAllMessages.Text = "";
            PatientFullDTO patientFullDTO = comboPatientsMessage.SelectedItem as PatientFullDTO;
            if(patientFullDTO != null)
            foreach (var message in ctrl.getMessagesByDoctorPatient(ctrl.Doctor.Username, patientFullDTO.Username)) {
                if (message.FromUsername.Equals(ctrl.Doctor.Username)){
                    textAllMessages.SelectionColor = Color.Red;
                    textAllMessages.AppendText(ctrl.Doctor.ToString());
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
                    textAllMessages.AppendText(patientFullDTO.ToString());
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
            string text = textCurrentMessage.Text;
            string doctor = ctrl.Doctor.Username;
            PatientFullDTO patientFullDTO = comboPatientsMessage.SelectedItem as PatientFullDTO;
            string patient = patientFullDTO.Username;
            ctrl.sendMessage(doctor, patient, text);
            textCurrentMessage.Text = "";
        }

        private void dateGeneral_ValueChanged(object sender, EventArgs e) {
            setAppointments(dateGeneral.Value.ToString("yyyy-MM-dd"));
        }
    }
}
