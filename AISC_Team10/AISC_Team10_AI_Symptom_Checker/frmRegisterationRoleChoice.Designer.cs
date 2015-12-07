namespace AISC_Team10_AI_Symptom_Checker
{
    partial class frmRegisterationRoleChoice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRelative = new System.Windows.Forms.Button();
            this.btnPatient = new System.Windows.Forms.Button();
            this.btnDoctor = new System.Windows.Forms.Button();
            this.grpBoxDoctorInfo = new System.Windows.Forms.GroupBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtBoxSpeciality = new System.Windows.Forms.TextBox();
            this.txtBoxAddress = new System.Windows.Forms.TextBox();
            this.txtBoxHospital = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grpBoxDoctorInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(245, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your information is saved!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Please choose your role:";
            // 
            // btnRelative
            // 
            this.btnRelative.Location = new System.Drawing.Point(75, 88);
            this.btnRelative.Name = "btnRelative";
            this.btnRelative.Size = new System.Drawing.Size(105, 35);
            this.btnRelative.TabIndex = 2;
            this.btnRelative.Text = "Relative";
            this.btnRelative.UseVisualStyleBackColor = true;
            this.btnRelative.Click += new System.EventHandler(this.btnRelative_Click);
            // 
            // btnPatient
            // 
            this.btnPatient.Location = new System.Drawing.Point(248, 88);
            this.btnPatient.Name = "btnPatient";
            this.btnPatient.Size = new System.Drawing.Size(105, 35);
            this.btnPatient.TabIndex = 3;
            this.btnPatient.Text = "Patient";
            this.btnPatient.UseVisualStyleBackColor = true;
            this.btnPatient.Click += new System.EventHandler(this.btnPatient_Click);
            // 
            // btnDoctor
            // 
            this.btnDoctor.Location = new System.Drawing.Point(396, 88);
            this.btnDoctor.Name = "btnDoctor";
            this.btnDoctor.Size = new System.Drawing.Size(105, 35);
            this.btnDoctor.TabIndex = 4;
            this.btnDoctor.Text = "Doctor";
            this.btnDoctor.UseVisualStyleBackColor = true;
            this.btnDoctor.Click += new System.EventHandler(this.btnDoctor_Click);
            // 
            // grpBoxDoctorInfo
            // 
            this.grpBoxDoctorInfo.Controls.Add(this.btnOk);
            this.grpBoxDoctorInfo.Controls.Add(this.btnCancel);
            this.grpBoxDoctorInfo.Controls.Add(this.txtBoxSpeciality);
            this.grpBoxDoctorInfo.Controls.Add(this.txtBoxAddress);
            this.grpBoxDoctorInfo.Controls.Add(this.txtBoxHospital);
            this.grpBoxDoctorInfo.Controls.Add(this.label5);
            this.grpBoxDoctorInfo.Controls.Add(this.label4);
            this.grpBoxDoctorInfo.Controls.Add(this.label3);
            this.grpBoxDoctorInfo.Location = new System.Drawing.Point(82, 160);
            this.grpBoxDoctorInfo.Name = "grpBoxDoctorInfo";
            this.grpBoxDoctorInfo.Size = new System.Drawing.Size(419, 142);
            this.grpBoxDoctorInfo.TabIndex = 5;
            this.grpBoxDoctorInfo.TabStop = false;
            this.grpBoxDoctorInfo.Text = "Doctor Extra Info";
            this.grpBoxDoctorInfo.Visible = false;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(248, 106);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(329, 106);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtBoxSpeciality
            // 
            this.txtBoxSpeciality.Location = new System.Drawing.Point(100, 80);
            this.txtBoxSpeciality.Name = "txtBoxSpeciality";
            this.txtBoxSpeciality.Size = new System.Drawing.Size(295, 20);
            this.txtBoxSpeciality.TabIndex = 5;
            // 
            // txtBoxAddress
            // 
            this.txtBoxAddress.Location = new System.Drawing.Point(100, 55);
            this.txtBoxAddress.Name = "txtBoxAddress";
            this.txtBoxAddress.Size = new System.Drawing.Size(295, 20);
            this.txtBoxAddress.TabIndex = 4;
            // 
            // txtBoxHospital
            // 
            this.txtBoxHospital.Location = new System.Drawing.Point(100, 29);
            this.txtBoxHospital.Name = "txtBoxHospital";
            this.txtBoxHospital.Size = new System.Drawing.Size(295, 20);
            this.txtBoxHospital.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Speciality:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Work Address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Hospital:";
            // 
            // frmRegisterationRoleChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 353);
            this.Controls.Add(this.grpBoxDoctorInfo);
            this.Controls.Add(this.btnDoctor);
            this.Controls.Add(this.btnPatient);
            this.Controls.Add(this.btnRelative);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmRegisterationRoleChoice";
            this.Text = "Registeration";
            this.grpBoxDoctorInfo.ResumeLayout(false);
            this.grpBoxDoctorInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRelative;
        private System.Windows.Forms.Button btnPatient;
        private System.Windows.Forms.Button btnDoctor;
        private System.Windows.Forms.GroupBox grpBoxDoctorInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxSpeciality;
        private System.Windows.Forms.TextBox txtBoxAddress;
        private System.Windows.Forms.TextBox txtBoxHospital;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}