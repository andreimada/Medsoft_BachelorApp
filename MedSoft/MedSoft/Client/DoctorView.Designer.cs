namespace ClientDoctor {
    partial class DoctorView {
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridGeneral = new System.Windows.Forms.DataGridView();
            this.columnPacient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label13 = new System.Windows.Forms.Label();
            this.dateGeneral = new System.Windows.Forms.DateTimePicker();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonAddPatient = new System.Windows.Forms.Button();
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
            this.buttonCreateMedicalLetter = new System.Windows.Forms.Button();
            this.textBoxRecommendedTreatment = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxTreatment = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxExams = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxAnamneza = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxDiagnostic = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboPatient = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.buttonRefreshTable = new System.Windows.Forms.Button();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.columnPatient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDiagnostic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.buttonSendMessage = new System.Windows.Forms.Button();
            this.textCurrentMessage = new System.Windows.Forms.TextBox();
            this.comboPatientsMessage = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.buttonRefreshAll = new System.Windows.Forms.Button();
            this.textAllMessages = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGeneral)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(781, 12);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(106, 33);
            this.buttonLogout.TabIndex = 0;
            this.buttonLogout.Text = "Deconectare";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(13, 29);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(878, 468);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridGeneral);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.dateGeneral);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(870, 439);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Prezentare generala";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridGeneral
            // 
            this.dataGridGeneral.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridGeneral.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridGeneral.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnPacient,
            this.columnTime});
            this.dataGridGeneral.Location = new System.Drawing.Point(158, 93);
            this.dataGridGeneral.Name = "dataGridGeneral";
            this.dataGridGeneral.RowHeadersWidth = 51;
            this.dataGridGeneral.RowTemplate.Height = 24;
            this.dataGridGeneral.Size = new System.Drawing.Size(506, 272);
            this.dataGridGeneral.TabIndex = 2;
            // 
            // columnPacient
            // 
            this.columnPacient.HeaderText = "Pacient";
            this.columnPacient.MinimumWidth = 30;
            this.columnPacient.Name = "columnPacient";
            // 
            // columnTime
            // 
            this.columnTime.HeaderText = "Ora";
            this.columnTime.MinimumWidth = 6;
            this.columnTime.Name = "columnTime";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label13.Location = new System.Drawing.Point(153, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 29);
            this.label13.TabIndex = 1;
            this.label13.Text = "Data:";
            // 
            // dateGeneral
            // 
            this.dateGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.dateGeneral.Location = new System.Drawing.Point(227, 24);
            this.dateGeneral.Name = "dateGeneral";
            this.dateGeneral.Size = new System.Drawing.Size(437, 34);
            this.dateGeneral.TabIndex = 0;
            this.dateGeneral.ValueChanged += new System.EventHandler(this.dateGeneral_ValueChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonAddPatient);
            this.tabPage3.Controls.Add(this.textBoxPhone);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.textBoxAddress);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.textBoxCnp);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.textBoxFirstname);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.textBoxName);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(870, 439);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Adauga pacient";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonAddPatient
            // 
            this.buttonAddPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonAddPatient.Location = new System.Drawing.Point(554, 325);
            this.buttonAddPatient.Name = "buttonAddPatient";
            this.buttonAddPatient.Size = new System.Drawing.Size(243, 62);
            this.buttonAddPatient.TabIndex = 31;
            this.buttonAddPatient.Text = "Adauga pacient";
            this.buttonAddPatient.UseVisualStyleBackColor = true;
            this.buttonAddPatient.Click += new System.EventHandler(this.buttonAddPatient_Click);
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPhone.Location = new System.Drawing.Point(176, 298);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(197, 34);
            this.textBoxPhone.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(74, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 29);
            this.label5.TabIndex = 29;
            this.label5.Text = "Telefon";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAddress.Location = new System.Drawing.Point(176, 145);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(560, 34);
            this.textBoxAddress.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(74, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 29);
            this.label4.TabIndex = 27;
            this.label4.Text = "Adresa";
            // 
            // textBoxCnp
            // 
            this.textBoxCnp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCnp.Location = new System.Drawing.Point(176, 222);
            this.textBoxCnp.Name = "textBoxCnp";
            this.textBoxCnp.Size = new System.Drawing.Size(197, 34);
            this.textBoxCnp.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(99, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 29);
            this.label3.TabIndex = 25;
            this.label3.Text = "CNP";
            // 
            // textBoxFirstname
            // 
            this.textBoxFirstname.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFirstname.Location = new System.Drawing.Point(539, 54);
            this.textBoxFirstname.Name = "textBoxFirstname";
            this.textBoxFirstname.Size = new System.Drawing.Size(197, 34);
            this.textBoxFirstname.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(422, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 29);
            this.label2.TabIndex = 23;
            this.label2.Text = "Prenume";
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Location = new System.Drawing.Point(176, 54);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(197, 34);
            this.textBoxName.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(91, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 29);
            this.label1.TabIndex = 21;
            this.label1.Text = "Nume";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonCreateMedicalLetter);
            this.tabPage2.Controls.Add(this.textBoxRecommendedTreatment);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.textBoxTreatment);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.textBoxExams);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.textBoxAnamneza);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.textBoxDiagnostic);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.comboPatient);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(870, 439);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Creare scrisoare medicala";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonCreateMedicalLetter
            // 
            this.buttonCreateMedicalLetter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonCreateMedicalLetter.Location = new System.Drawing.Point(599, 268);
            this.buttonCreateMedicalLetter.Name = "buttonCreateMedicalLetter";
            this.buttonCreateMedicalLetter.Size = new System.Drawing.Size(223, 114);
            this.buttonCreateMedicalLetter.TabIndex = 12;
            this.buttonCreateMedicalLetter.Text = "Creare Scrisoare Medicala";
            this.buttonCreateMedicalLetter.UseVisualStyleBackColor = true;
            this.buttonCreateMedicalLetter.Click += new System.EventHandler(this.buttonCreateMedicalLetter_Click);
            // 
            // textBoxRecommendedTreatment
            // 
            this.textBoxRecommendedTreatment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxRecommendedTreatment.Location = new System.Drawing.Point(287, 350);
            this.textBoxRecommendedTreatment.Multiline = true;
            this.textBoxRecommendedTreatment.Name = "textBoxRecommendedTreatment";
            this.textBoxRecommendedTreatment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRecommendedTreatment.Size = new System.Drawing.Size(271, 59);
            this.textBoxRecommendedTreatment.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label11.Location = new System.Drawing.Point(11, 353);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(270, 29);
            this.label11.TabIndex = 10;
            this.label11.Text = "Tratament Recomandat:";
            // 
            // textBoxTreatment
            // 
            this.textBoxTreatment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxTreatment.Location = new System.Drawing.Point(274, 259);
            this.textBoxTreatment.Multiline = true;
            this.textBoxTreatment.Name = "textBoxTreatment";
            this.textBoxTreatment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxTreatment.Size = new System.Drawing.Size(284, 59);
            this.textBoxTreatment.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label10.Location = new System.Drawing.Point(37, 262);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(217, 29);
            this.label10.TabIndex = 8;
            this.label10.Text = "Tratament efactuat:";
            // 
            // textBoxExams
            // 
            this.textBoxExams.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxExams.Location = new System.Drawing.Point(599, 140);
            this.textBoxExams.Multiline = true;
            this.textBoxExams.Name = "textBoxExams";
            this.textBoxExams.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxExams.Size = new System.Drawing.Size(223, 76);
            this.textBoxExams.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label9.Location = new System.Drawing.Point(473, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 29);
            this.label9.TabIndex = 6;
            this.label9.Text = "Examene:";
            // 
            // textBoxAnamneza
            // 
            this.textBoxAnamneza.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxAnamneza.Location = new System.Drawing.Point(148, 137);
            this.textBoxAnamneza.Multiline = true;
            this.textBoxAnamneza.Name = "textBoxAnamneza";
            this.textBoxAnamneza.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxAnamneza.Size = new System.Drawing.Size(260, 79);
            this.textBoxAnamneza.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label8.Location = new System.Drawing.Point(11, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 29);
            this.label8.TabIndex = 4;
            this.label8.Text = "Anamneza:";
            // 
            // textBoxDiagnostic
            // 
            this.textBoxDiagnostic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxDiagnostic.Location = new System.Drawing.Point(599, 35);
            this.textBoxDiagnostic.Multiline = true;
            this.textBoxDiagnostic.Name = "textBoxDiagnostic";
            this.textBoxDiagnostic.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDiagnostic.Size = new System.Drawing.Size(223, 59);
            this.textBoxDiagnostic.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label7.Location = new System.Drawing.Point(461, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 29);
            this.label7.TabIndex = 2;
            this.label7.Text = "Diagnostic:";
            // 
            // comboPatient
            // 
            this.comboPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.comboPatient.FormattingEnabled = true;
            this.comboPatient.Location = new System.Drawing.Point(148, 35);
            this.comboPatient.Name = "comboPatient";
            this.comboPatient.Size = new System.Drawing.Size(260, 37);
            this.comboPatient.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label6.Location = new System.Drawing.Point(37, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 29);
            this.label6.TabIndex = 0;
            this.label6.Text = "Pacient: ";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.buttonRefreshTable);
            this.tabPage5.Controls.Add(this.buttonDownload);
            this.tabPage5.Controls.Add(this.dataGridView);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(870, 439);
            this.tabPage5.TabIndex = 5;
            this.tabPage5.Text = "Lista scrisori medicale";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // buttonRefreshTable
            // 
            this.buttonRefreshTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonRefreshTable.Location = new System.Drawing.Point(43, 334);
            this.buttonRefreshTable.Name = "buttonRefreshTable";
            this.buttonRefreshTable.Size = new System.Drawing.Size(205, 64);
            this.buttonRefreshTable.TabIndex = 3;
            this.buttonRefreshTable.Text = "Improspateaza";
            this.buttonRefreshTable.UseVisualStyleBackColor = true;
            this.buttonRefreshTable.Click += new System.EventHandler(this.buttonRefreshTable_Click);
            // 
            // buttonDownload
            // 
            this.buttonDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonDownload.Location = new System.Drawing.Point(508, 334);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(215, 62);
            this.buttonDownload.TabIndex = 1;
            this.buttonDownload.Text = "Descarca";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnPatient,
            this.columnDoctor,
            this.columnDiagnostic,
            this.columnDate});
            this.dataGridView.Location = new System.Drawing.Point(43, 48);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(680, 268);
            this.dataGridView.TabIndex = 0;
            // 
            // columnPatient
            // 
            this.columnPatient.HeaderText = "Pacient";
            this.columnPatient.MinimumWidth = 6;
            this.columnPatient.Name = "columnPatient";
            // 
            // columnDoctor
            // 
            this.columnDoctor.HeaderText = "Doctor";
            this.columnDoctor.MinimumWidth = 6;
            this.columnDoctor.Name = "columnDoctor";
            // 
            // columnDiagnostic
            // 
            this.columnDiagnostic.HeaderText = "Diagnostic";
            this.columnDiagnostic.MinimumWidth = 6;
            this.columnDiagnostic.Name = "columnDiagnostic";
            // 
            // columnDate
            // 
            this.columnDate.HeaderText = "Data";
            this.columnDate.MinimumWidth = 6;
            this.columnDate.Name = "columnDate";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.textAllMessages);
            this.tabPage4.Controls.Add(this.buttonSendMessage);
            this.tabPage4.Controls.Add(this.textCurrentMessage);
            this.tabPage4.Controls.Add(this.comboPatientsMessage);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(870, 439);
            this.tabPage4.TabIndex = 6;
            this.tabPage4.Text = "Mesagerie";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // buttonSendMessage
            // 
            this.buttonSendMessage.Location = new System.Drawing.Point(706, 338);
            this.buttonSendMessage.Name = "buttonSendMessage";
            this.buttonSendMessage.Size = new System.Drawing.Size(106, 47);
            this.buttonSendMessage.TabIndex = 4;
            this.buttonSendMessage.Text = "Trimite";
            this.buttonSendMessage.UseVisualStyleBackColor = true;
            this.buttonSendMessage.Click += new System.EventHandler(this.buttonSendMessage_Click);
            // 
            // textCurrentMessage
            // 
            this.textCurrentMessage.Location = new System.Drawing.Point(78, 338);
            this.textCurrentMessage.Multiline = true;
            this.textCurrentMessage.Name = "textCurrentMessage";
            this.textCurrentMessage.Size = new System.Drawing.Size(622, 47);
            this.textCurrentMessage.TabIndex = 3;
            // 
            // comboPatientsMessage
            // 
            this.comboPatientsMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboPatientsMessage.FormattingEnabled = true;
            this.comboPatientsMessage.Location = new System.Drawing.Point(275, 19);
            this.comboPatientsMessage.Name = "comboPatientsMessage";
            this.comboPatientsMessage.Size = new System.Drawing.Size(439, 33);
            this.comboPatientsMessage.TabIndex = 1;
            this.comboPatientsMessage.SelectedIndexChanged += new System.EventHandler(this.comboPatientsMessage_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label12.Location = new System.Drawing.Point(161, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 25);
            this.label12.TabIndex = 0;
            this.label12.Text = "Pacient:";
            // 
            // buttonRefreshAll
            // 
            this.buttonRefreshAll.Location = new System.Drawing.Point(656, 12);
            this.buttonRefreshAll.Name = "buttonRefreshAll";
            this.buttonRefreshAll.Size = new System.Drawing.Size(119, 33);
            this.buttonRefreshAll.TabIndex = 1;
            this.buttonRefreshAll.Text = "Improspateaza";
            this.buttonRefreshAll.UseVisualStyleBackColor = true;
            this.buttonRefreshAll.Click += new System.EventHandler(this.buttonRefreshAll_Click);
            // 
            // textAllMessages
            // 
            this.textAllMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textAllMessages.Location = new System.Drawing.Point(78, 58);
            this.textAllMessages.Name = "textAllMessages";
            this.textAllMessages.ReadOnly = true;
            this.textAllMessages.Size = new System.Drawing.Size(734, 274);
            this.textAllMessages.TabIndex = 5;
            this.textAllMessages.Text = "";
            // 
            // DoctorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(903, 509);
            this.ControlBox = false;
            this.Controls.Add(this.buttonRefreshAll);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.tabControl1);
            this.Name = "DoctorView";
            this.Text = "DoctorView";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGeneral)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button buttonAddPatient;
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
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonCreateMedicalLetter;
        private System.Windows.Forms.TextBox textBoxRecommendedTreatment;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxTreatment;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxExams;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxAnamneza;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxDiagnostic;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboPatient;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDiagnostic;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDate;
        private System.Windows.Forms.Button buttonRefreshTable;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.DateTimePicker dateGeneral;
        private System.Windows.Forms.Button buttonRefreshAll;
        private System.Windows.Forms.ComboBox comboPatientsMessage;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonSendMessage;
        private System.Windows.Forms.TextBox textCurrentMessage;
        private System.Windows.Forms.DataGridView dataGridGeneral;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPacient;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTime;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RichTextBox textAllMessages;
    }
}