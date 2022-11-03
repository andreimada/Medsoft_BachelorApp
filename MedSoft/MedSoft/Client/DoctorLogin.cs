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

namespace ClientDoctor {
    public partial class DoctorLogin : Form {
        private DoctorController ctrl;
        public DoctorLogin(DoctorController medsoftController) {
            this.ctrl = medsoftController;
            InitializeComponent();
        }

        private void butonIesire_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void buttonLogin_Click(object sender, EventArgs e) {
            try {
                ctrl.login(textBoxUsername.Text, textBoxPassword.Text);
                Doctor doctor = ctrl.login(textBoxUsername.Text, textBoxPassword.Text);
                textBoxUsername.Text = "";
                textBoxPassword.Text = "";
                
                DoctorView doctorView = new DoctorView(ctrl, this);
                doctorView.Show();
                this.Hide();
            }
            catch (MedsoftException err) {
                MessageBox.Show(err.Message);
            }
        }
    }
}
