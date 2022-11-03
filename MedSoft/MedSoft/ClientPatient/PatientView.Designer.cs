namespace ClientPatient {
    partial class PatientView {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.buttonLogout = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.detailsPage = new System.Windows.Forms.TabPage();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCnp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFirstname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonMakeAppointment = new System.Windows.Forms.Button();
            this.comboTime = new System.Windows.Forms.ComboBox();
            this.comboDoctor = new System.Windows.Forms.ComboBox();
            this.comboSpeciality = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonSendMessage = new System.Windows.Forms.Button();
            this.textCurrentMessage = new System.Windows.Forms.TextBox();
            this.comboDoctorsMessage = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.textAllMessages = new System.Windows.Forms.RichTextBox();
            this.tabControl.SuspendLayout();
            this.detailsPage.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(756, 12);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(114, 28);
            this.buttonLogout.TabIndex = 1;
            this.buttonLogout.Text = "Deconectare";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.detailsPage);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Location = new System.Drawing.Point(12, 23);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(857, 460);
            this.tabControl.TabIndex = 2;
            // 
            // detailsPage
            // 
            this.detailsPage.Controls.Add(this.textBoxPhone);
            this.detailsPage.Controls.Add(this.label5);
            this.detailsPage.Controls.Add(this.textBoxAddress);
            this.detailsPage.Controls.Add(this.label4);
            this.detailsPage.Controls.Add(this.textBoxCnp);
            this.detailsPage.Controls.Add(this.label3);
            this.detailsPage.Controls.Add(this.textBoxFirstname);
            this.detailsPage.Controls.Add(this.label2);
            this.detailsPage.Controls.Add(this.textBoxName);
            this.detailsPage.Controls.Add(this.label1);
            this.detailsPage.Location = new System.Drawing.Point(4, 25);
            this.detailsPage.Name = "detailsPage";
            this.detailsPage.Padding = new System.Windows.Forms.Padding(3);
            this.detailsPage.Size = new System.Drawing.Size(849, 431);
            this.detailsPage.TabIndex = 0;
            this.detailsPage.Text = "Detalii Pacient";
            this.detailsPage.UseVisualStyleBackColor = true;
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPhone.Location = new System.Drawing.Point(178, 295);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.ReadOnly = true;
            this.textBoxPhone.Size = new System.Drawing.Size(197, 34);
            this.textBoxPhone.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(76, 298);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 29);
            this.label5.TabIndex = 8;
            this.label5.Text = "Telefon";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAddress.Location = new System.Drawing.Point(178, 142);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.ReadOnly = true;
            this.textBoxAddress.Size = new System.Drawing.Size(560, 34);
            this.textBoxAddress.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(76, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Adresa";
            // 
            // textBoxCnp
            // 
            this.textBoxCnp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCnp.Location = new System.Drawing.Point(178, 219);
            this.textBoxCnp.Name = "textBoxCnp";
            this.textBoxCnp.ReadOnly = true;
            this.textBoxCnp.Size = new System.Drawing.Size(197, 34);
            this.textBoxCnp.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(101, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "CNP";
            // 
            // textBoxFirstname
            // 
            this.textBoxFirstname.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFirstname.Location = new System.Drawing.Point(541, 49);
            this.textBoxFirstname.Name = "textBoxFirstname";
            this.textBoxFirstname.ReadOnly = true;
            this.textBoxFirstname.Size = new System.Drawing.Size(197, 34);
            this.textBoxFirstname.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(424, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Prenume";
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Location = new System.Drawing.Point(178, 51);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(197, 34);
            this.textBoxName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nume";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonMakeAppointment);
            this.tabPage2.Controls.Add(this.comboTime);
            this.tabPage2.Controls.Add(this.comboDoctor);
            this.tabPage2.Controls.Add(this.comboSpeciality);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.datePicker);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(849, 431);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Programare";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonMakeAppointment
            // 
            this.buttonMakeAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonMakeAppointment.Location = new System.Drawing.Point(543, 369);
            this.buttonMakeAppointment.Name = "buttonMakeAppointment";
            this.buttonMakeAppointment.Size = new System.Drawing.Size(290, 56);
            this.buttonMakeAppointment.TabIndex = 9;
            this.buttonMakeAppointment.Text = "Confirma programarea";
            this.buttonMakeAppointment.UseVisualStyleBackColor = true;
            this.buttonMakeAppointment.Click += new System.EventHandler(this.buttonMakeAppointment_Click);
            // 
            // comboTime
            // 
            this.comboTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.comboTime.FormattingEnabled = true;
            this.comboTime.Location = new System.Drawing.Point(352, 283);
            this.comboTime.Name = "comboTime";
            this.comboTime.Size = new System.Drawing.Size(86, 37);
            this.comboTime.TabIndex = 8;
            // 
            // comboDoctor
            // 
            this.comboDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.comboDoctor.FormattingEnabled = true;
            this.comboDoctor.Location = new System.Drawing.Point(352, 159);
            this.comboDoctor.Name = "comboDoctor";
            this.comboDoctor.Size = new System.Drawing.Size(291, 37);
            this.comboDoctor.TabIndex = 7;
            this.comboDoctor.SelectedIndexChanged += new System.EventHandler(this.comboDoctor_SelectedIndexChanged);
            // 
            // comboSpeciality
            // 
            this.comboSpeciality.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.comboSpeciality.FormattingEnabled = true;
            this.comboSpeciality.Location = new System.Drawing.Point(352, 98);
            this.comboSpeciality.Name = "comboSpeciality";
            this.comboSpeciality.Size = new System.Drawing.Size(291, 37);
            this.comboSpeciality.TabIndex = 6;
            this.comboSpeciality.SelectedIndexChanged += new System.EventHandler(this.comboSpeciality_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label9.Location = new System.Drawing.Point(48, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(263, 29);
            this.label9.TabIndex = 5;
            this.label9.Text = "Selectare departament:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label8.Location = new System.Drawing.Point(153, 286);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(163, 29);
            this.label8.TabIndex = 4;
            this.label8.Text = "Selectare ora:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label7.Location = new System.Drawing.Point(142, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 29);
            this.label7.TabIndex = 3;
            this.label7.Text = "Selectare data:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label6.Location = new System.Drawing.Point(120, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(196, 29);
            this.label6.TabIndex = 2;
            this.label6.Text = "Selectare doctor:";
            // 
            // datePicker
            // 
            this.datePicker.CustomFormat = "dd-MM-yyy";
            this.datePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.datePicker.Location = new System.Drawing.Point(352, 228);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(291, 34);
            this.datePicker.TabIndex = 0;
            this.datePicker.ValueChanged += new System.EventHandler(this.datePicker_ValueChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textAllMessages);
            this.tabPage1.Controls.Add(this.buttonSendMessage);
            this.tabPage1.Controls.Add(this.textCurrentMessage);
            this.tabPage1.Controls.Add(this.comboDoctorsMessage);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(849, 431);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Mesagerie";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonSendMessage
            // 
            this.buttonSendMessage.Location = new System.Drawing.Point(685, 351);
            this.buttonSendMessage.Name = "buttonSendMessage";
            this.buttonSendMessage.Size = new System.Drawing.Size(106, 47);
            this.buttonSendMessage.TabIndex = 9;
            this.buttonSendMessage.Text = "Trimite";
            this.buttonSendMessage.UseVisualStyleBackColor = true;
            this.buttonSendMessage.Click += new System.EventHandler(this.buttonSendMessage_Click);
            // 
            // textCurrentMessage
            // 
            this.textCurrentMessage.Location = new System.Drawing.Point(57, 351);
            this.textCurrentMessage.Multiline = true;
            this.textCurrentMessage.Name = "textCurrentMessage";
            this.textCurrentMessage.Size = new System.Drawing.Size(622, 47);
            this.textCurrentMessage.TabIndex = 8;
            // 
            // comboDoctorsMessage
            // 
            this.comboDoctorsMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboDoctorsMessage.FormattingEnabled = true;
            this.comboDoctorsMessage.Location = new System.Drawing.Point(254, 32);
            this.comboDoctorsMessage.Name = "comboDoctorsMessage";
            this.comboDoctorsMessage.Size = new System.Drawing.Size(439, 33);
            this.comboDoctorsMessage.TabIndex = 6;
            this.comboDoctorsMessage.SelectedIndexChanged += new System.EventHandler(this.comboDoctorsMessage_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label12.Location = new System.Drawing.Point(140, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 25);
            this.label12.TabIndex = 5;
            this.label12.Text = "Doctor:";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(628, 12);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(122, 28);
            this.buttonRefresh.TabIndex = 3;
            this.buttonRefresh.Text = "Improspatare";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // textAllMessages
            // 
            this.textAllMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textAllMessages.Location = new System.Drawing.Point(57, 71);
            this.textAllMessages.Name = "textAllMessages";
            this.textAllMessages.ReadOnly = true;
            this.textAllMessages.Size = new System.Drawing.Size(734, 274);
            this.textAllMessages.TabIndex = 10;
            this.textAllMessages.Text = "";
            // 
            // PatientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(882, 495);
            this.ControlBox = false;
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.tabControl);
            this.Name = "PatientView";
            this.Text = "PatientView";
            this.tabControl.ResumeLayout(false);
            this.detailsPage.ResumeLayout(false);
            this.detailsPage.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage detailsPage;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCnp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFirstname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonMakeAppointment;
        private System.Windows.Forms.ComboBox comboTime;
        private System.Windows.Forms.ComboBox comboDoctor;
        private System.Windows.Forms.ComboBox comboSpeciality;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonSendMessage;
        private System.Windows.Forms.TextBox textCurrentMessage;
        private System.Windows.Forms.ComboBox comboDoctorsMessage;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.RichTextBox textAllMessages;
    }
}