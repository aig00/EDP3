namespace InformationSystem_EDP
{
    partial class AddTask
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
            this.AssignedToAT = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DueDateAT = new System.Windows.Forms.TextBox();
            this.TitleAT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Save1 = new System.Windows.Forms.Button();
            this.projectSelect = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.statusSelect = new System.Windows.Forms.ComboBox();
            this.prioritySelect = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.prioritySelect);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.statusSelect);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.projectSelect);
            this.panel1.Controls.Add(this.AssignedToAT);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.DueDateAT);
            this.panel1.Controls.Add(this.TitleAT);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 279);
            this.panel1.TabIndex = 10;
            // 
            // AssignedToAT
            // 
            this.AssignedToAT.FormattingEnabled = true;
            this.AssignedToAT.Location = new System.Drawing.Point(245, 68);
            this.AssignedToAT.Name = "AssignedToAT";
            this.AssignedToAT.Size = new System.Drawing.Size(191, 24);
            this.AssignedToAT.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 29);
            this.label5.TabIndex = 10;
            this.label5.Text = "Project:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(240, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 29);
            this.label3.TabIndex = 8;
            this.label3.Text = "Assigned To:";
            // 
            // DueDateAT
            // 
            this.DueDateAT.Location = new System.Drawing.Point(19, 210);
            this.DueDateAT.Name = "DueDateAT";
            this.DueDateAT.Size = new System.Drawing.Size(191, 22);
            this.DueDateAT.TabIndex = 7;
            // 
            // TitleAT
            // 
            this.TitleAT.Location = new System.Drawing.Point(19, 70);
            this.TitleAT.Name = "TitleAT";
            this.TitleAT.Size = new System.Drawing.Size(191, 22);
            this.TitleAT.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 29);
            this.label4.TabIndex = 3;
            this.label4.Text = "Due Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title:";
            // 
            // Save1
            // 
            this.Save1.Location = new System.Drawing.Point(334, 314);
            this.Save1.Name = "Save1";
            this.Save1.Size = new System.Drawing.Size(139, 50);
            this.Save1.TabIndex = 12;
            this.Save1.Text = "Save";
            this.Save1.UseVisualStyleBackColor = true;
            this.Save1.Click += new System.EventHandler(this.Save1_Click_1);
            // 
            // projectSelect
            // 
            this.projectSelect.FormattingEnabled = true;
            this.projectSelect.Location = new System.Drawing.Point(19, 127);
            this.projectSelect.Name = "projectSelect";
            this.projectSelect.Size = new System.Drawing.Size(191, 24);
            this.projectSelect.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(240, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 29);
            this.label2.TabIndex = 14;
            this.label2.Text = "Status:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // statusSelect
            // 
            this.statusSelect.FormattingEnabled = true;
            this.statusSelect.Location = new System.Drawing.Point(245, 141);
            this.statusSelect.Name = "statusSelect";
            this.statusSelect.Size = new System.Drawing.Size(191, 24);
            this.statusSelect.TabIndex = 15;
            // 
            // prioritySelect
            // 
            this.prioritySelect.FormattingEnabled = true;
            this.prioritySelect.Location = new System.Drawing.Point(245, 228);
            this.prioritySelect.Name = "prioritySelect";
            this.prioritySelect.Size = new System.Drawing.Size(191, 24);
            this.prioritySelect.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(240, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 29);
            this.label6.TabIndex = 16;
            this.label6.Text = "Priority:";
            // 
            // AddTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 391);
            this.Controls.Add(this.Save1);
            this.Controls.Add(this.panel1);
            this.Name = "AddTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox AssignedToAT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DueDateAT;
        private System.Windows.Forms.TextBox TitleAT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Save1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox projectSelect;
        private System.Windows.Forms.ComboBox prioritySelect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox statusSelect;
    }
}