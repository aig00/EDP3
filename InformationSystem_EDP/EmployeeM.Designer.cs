using System.Windows.Forms;

namespace InformationSystem_EDP
{
    partial class EmployeeM
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
        private void SetupDataGridView()
        {
            // Assume dataGridView1 is already placed on the form.

            // Add Edit Button Column
            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
            editButton.Name = "Edit";
            editButton.HeaderText = "Edit";
            editButton.Text = "Edit";
            editButton.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(editButton);

            // Add Delete Button Column
            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "Delete";
            deleteButton.HeaderText = "Delete";
            deleteButton.Text = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(deleteButton);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FullNameE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneNumberE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartmentE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsernameE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddE = new System.Windows.Forms.Button();
            this.SaveE = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FullNameE,
            this.EmailE,
            this.PhoneNumberE,
            this.DepartmentE,
            this.UsernameE});
            this.dataGridView1.Location = new System.Drawing.Point(12, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(805, 289);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // FullNameE
            // 
            this.FullNameE.HeaderText = "Full Name";
            this.FullNameE.MinimumWidth = 6;
            this.FullNameE.Name = "FullNameE";
            this.FullNameE.Width = 150;
            // 
            // EmailE
            // 
            this.EmailE.HeaderText = "Email";
            this.EmailE.MinimumWidth = 6;
            this.EmailE.Name = "EmailE";
            this.EmailE.Width = 150;
            // 
            // PhoneNumberE
            // 
            this.PhoneNumberE.HeaderText = "Phone Number";
            this.PhoneNumberE.MinimumWidth = 6;
            this.PhoneNumberE.Name = "PhoneNumberE";
            this.PhoneNumberE.Width = 150;
            // 
            // DepartmentE
            // 
            this.DepartmentE.HeaderText = "Department";
            this.DepartmentE.MinimumWidth = 6;
            this.DepartmentE.Name = "DepartmentE";
            this.DepartmentE.Width = 150;
            // 
            // UsernameE
            // 
            this.UsernameE.HeaderText = "Username";
            this.UsernameE.MinimumWidth = 6;
            this.UsernameE.Name = "UsernameE";
            this.UsernameE.Width = 150;
            // 
            // AddE
            // 
            this.AddE.Location = new System.Drawing.Point(843, 145);
            this.AddE.Name = "AddE";
            this.AddE.Size = new System.Drawing.Size(108, 46);
            this.AddE.TabIndex = 3;
            this.AddE.Text = "Add";
            this.AddE.UseVisualStyleBackColor = true;
            this.AddE.Click += new System.EventHandler(this.AddE_Click);
            // 
            // SaveE
            // 
            this.SaveE.Location = new System.Drawing.Point(843, 197);
            this.SaveE.Name = "SaveE";
            this.SaveE.Size = new System.Drawing.Size(108, 46);
            this.SaveE.TabIndex = 4;
            this.SaveE.Text = "Save";
            this.SaveE.UseVisualStyleBackColor = true;
            // 
            // EmployeeM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 378);
            this.Controls.Add(this.SaveE);
            this.Controls.Add(this.AddE);
            this.Controls.Add(this.dataGridView1);
            this.Name = "EmployeeM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullNameE;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneNumberE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartmentE;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsernameE;
        private System.Windows.Forms.Button AddE;
        private System.Windows.Forms.Button SaveE;
    }
}