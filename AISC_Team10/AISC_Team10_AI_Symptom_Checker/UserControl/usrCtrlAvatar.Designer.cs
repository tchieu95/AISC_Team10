namespace AISC_Team10_AI_Symptom_Checker
{
    partial class usrCtrlAvatar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ptcAvatar = new System.Windows.Forms.PictureBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.ptcRole = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptcAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptcRole)).BeginInit();
            this.SuspendLayout();
            // 
            // ptcAvatar
            // 
            this.ptcAvatar.Image = global::AISC_Team10_AI_Symptom_Checker.Properties.Resources.img_role_relative;
            this.ptcAvatar.Location = new System.Drawing.Point(3, 3);
            this.ptcAvatar.Name = "ptcAvatar";
            this.ptcAvatar.Size = new System.Drawing.Size(47, 48);
            this.ptcAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptcAvatar.TabIndex = 0;
            this.ptcAvatar.TabStop = false;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.Location = new System.Drawing.Point(56, 3);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(113, 15);
            this.lblFullName.TabIndex = 1;
            this.lblFullName.Text = "nguyen thanh an";
            // 
            // ptcRole
            // 
            this.ptcRole.Image = global::AISC_Team10_AI_Symptom_Checker.Properties.Resources.img_role_doctor;
            this.ptcRole.Location = new System.Drawing.Point(59, 29);
            this.ptcRole.Name = "ptcRole";
            this.ptcRole.Size = new System.Drawing.Size(21, 22);
            this.ptcRole.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptcRole.TabIndex = 2;
            this.ptcRole.TabStop = false;
            // 
            // usrCtrlAvatar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ptcRole);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.ptcAvatar);
            this.Name = "usrCtrlAvatar";
            this.Size = new System.Drawing.Size(213, 55);
            ((System.ComponentModel.ISupportInitialize)(this.ptcAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptcRole)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptcAvatar;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.PictureBox ptcRole;
    }
}
