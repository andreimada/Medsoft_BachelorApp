using Model;
using Service;
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
    public partial class PatientLogin : Form {
        private PatientController ctrl;
        public PatientLogin(PatientController controller) {
            this.ctrl = controller;
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e) {
            try {
                ctrl.login(textBoxUsername.Text, textBoxPassword.Text);
                Patient patient = ctrl.login(textBoxUsername.Text, textBoxPassword.Text);
                textBoxPassword.Text = "";
                textBoxUsername.Text = "";
                PatientView patientView = new PatientView(ctrl, this);
                patientView.Show();
                this.Hide();
            }
            catch(MedsoftException err) {
                MessageBox.Show(err.Message);
            }
        }

        private void butonIesire_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
