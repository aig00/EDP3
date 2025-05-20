namespace InformationSystem_EDP
{
    partial class AddEmployee
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
            this.FullNameAE = new System.Windows.Forms.TextBox();
            this.EmailAE = new System.Windows.Forms.TextBox();
            this.PhoneNumberAE = new System.Windows.Forms.TextBox();
            this.DepartmentAE = new System.Windows.Forms.ComboBox();
            this.Save1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FullNameAE
            // 
            this.FullNameAE.Location = new System.Drawing.Point(160, 15);
            this.FullNameAE.Margin = new System.Windows.Forms.Padding(4);
            this.FullNameAE.Name = "FullNameAE";
            this.FullNameAE.Size = new System.Drawing.Size(265, 22);
            this.FullNameAE.TabIndex = 0;
            // 
            // EmailAE
            // 
            this.EmailAE.Location = new System.Drawing.Point(160, 47);
            this.EmailAE.Margin = new System.Windows.Forms.Padding(4);
            this.EmailAE.Name = "EmailAE";
            this.EmailAE.Size = new System.Drawing.Size(265, 22);
            this.EmailAE.TabIndex = 1;
            // 
            // PhoneNumberAE
            // 
            this.PhoneNumberAE.Location = new System.Drawing.Point(160, 79);
            this.PhoneNumberAE.Margin = new System.Windows.Forms.Padding(4);
            this.PhoneNumberAE.Name = "PhoneNumberAE";
            this.PhoneNumberAE.Size = new System.Drawing.Size(265, 22);
            this.PhoneNumberAE.TabIndex = 2;
            // 
            // DepartmentAE
            // 
            this.DepartmentAE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DepartmentAE.FormattingEnabled = true;
            this.DepartmentAE.Location = new System.Drawing.Point(160, 111);
            this.DepartmentAE.Margin = new System.Windows.Forms.Padding(4);
            this.DepartmentAE.Name = "DepartmentAE";
            this.DepartmentAE.Size = new System.Drawing.Size(265, 24);
            this.DepartmentAE.TabIndex = 3;
            this.DepartmentAE.SelectedIndexChanged += new System.EventHandler(this.DepartmentAE_SelectedIndexChanged);
            // 
            // Save1
            // 
            this.Save1.Location = new System.Drawing.Point(160, 176);
            this.Save1.Margin = new System.Windows.Forms.Padding(4);
            this.Save1.Name = "Save1";
            this.Save1.Size = new System.Drawing.Size(100, 28);
            this.Save1.TabIndex = 5;
            this.Save1.Text = "Save";
            this.Save1.UseVisualStyleBackColor = true;
            this.Save1.Click += new System.EventHandler(this.Save1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Full Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Phone Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 114);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Department";
            // 
            // AddEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 223);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Save1);
            this.Controls.Add(this.DepartmentAE);
            this.Controls.Add(this.PhoneNumberAE);
            this.Controls.Add(this.EmailAE);
            this.Controls.Add(this.FullNameAE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Employee";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FullNameAE;
        private System.Windows.Forms.TextBox EmailAE;
        private System.Windows.Forms.TextBox PhoneNumberAE;
        private System.Windows.Forms.ComboBox DepartmentAE;
        private System.Windows.Forms.Button Save1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}