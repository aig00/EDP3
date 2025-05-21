namespace InformationSystem_EDP
{
    partial class AddProject
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.EndDateAP = new System.Windows.Forms.DateTimePicker();
            this.StartDateAP = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.ProjectNameAP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Save1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.statusSelect = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.statusSelect);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.EndDateAP);
            this.panel1.Controls.Add(this.StartDateAP);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ProjectNameAP);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(502, 279);
            this.panel1.TabIndex = 10;
            // 
            // EndDateAP
            // 
            this.EndDateAP.Location = new System.Drawing.Point(19, 203);
            this.EndDateAP.Name = "EndDateAP";
            this.EndDateAP.Size = new System.Drawing.Size(233, 22);
            this.EndDateAP.TabIndex = 13;
            this.EndDateAP.ValueChanged += new System.EventHandler(this.EndDateAP_ValueChanged);
            // 
            // StartDateAP
            // 
            this.StartDateAP.AllowDrop = true;
            this.StartDateAP.Location = new System.Drawing.Point(19, 146);
            this.StartDateAP.Name = "StartDateAP";
            this.StartDateAP.Size = new System.Drawing.Size(233, 22);
            this.StartDateAP.TabIndex = 12;
            this.StartDateAP.ValueChanged += new System.EventHandler(this.StartDateAP_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 29);
            this.label3.TabIndex = 8;
            this.label3.Text = "End Date:";
            // 
            // ProjectNameAP
            // 
            this.ProjectNameAP.Location = new System.Drawing.Point(19, 70);
            this.ProjectNameAP.Name = "ProjectNameAP";
            this.ProjectNameAP.Size = new System.Drawing.Size(233, 22);
            this.ProjectNameAP.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 29);
            this.label4.TabIndex = 3;
            this.label4.Text = "Start Date: ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project Name:";
            // 
            // Save1
            // 
            this.Save1.Location = new System.Drawing.Point(375, 317);
            this.Save1.Name = "Save1";
            this.Save1.Size = new System.Drawing.Size(139, 50);
            this.Save1.TabIndex = 11;
            this.Save1.Text = "Save";
            this.Save1.UseVisualStyleBackColor = true;
            this.Save1.Click += new System.EventHandler(this.Save1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(278, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 29);
            this.label2.TabIndex = 14;
            this.label2.Text = "Status:";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // statusSelect
            // 
            this.statusSelect.FormattingEnabled = true;
            this.statusSelect.Location = new System.Drawing.Point(283, 70);
            this.statusSelect.Name = "statusSelect";
            this.statusSelect.Size = new System.Drawing.Size(191, 24);
            this.statusSelect.TabIndex = 17;
            this.statusSelect.SelectedIndexChanged += new System.EventHandler(this.statusSelect_SelectedIndexChanged);
            // 
            // AddProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 379);
            this.Controls.Add(this.Save1);
            this.Controls.Add(this.panel1);
            this.Name = "AddProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project";
            this.Load += new System.EventHandler(this.AddProject_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox ProjectNameAP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Save1;
        private System.Windows.Forms.DateTimePicker StartDateAP;
        private System.Windows.Forms.DateTimePicker EndDateAP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox statusSelect;
    }
}