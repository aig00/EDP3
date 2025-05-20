namespace InformationSystem_EDP
{
    partial class Departments
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
            this.departmentGridView1 = new System.Windows.Forms.DataGridView();
            this.SaveD = new System.Windows.Forms.Button();
            this.AddD = new System.Windows.Forms.Button();
            this.DepartmentT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Created = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.departmentGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // departmentGridView1
            // 
            this.departmentGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.departmentGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.departmentGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DepartmentT,
            this.Description,
            this.Created});
            this.departmentGridView1.Location = new System.Drawing.Point(12, 21);
            this.departmentGridView1.Name = "departmentGridView1";
            this.departmentGridView1.RowHeadersWidth = 51;
            this.departmentGridView1.RowTemplate.Height = 24;
            this.departmentGridView1.Size = new System.Drawing.Size(781, 289);
            this.departmentGridView1.TabIndex = 0;
            // 
            // SaveD
            // 
            this.SaveD.Location = new System.Drawing.Point(849, 176);
            this.SaveD.Name = "SaveD";
            this.SaveD.Size = new System.Drawing.Size(108, 46);
            this.SaveD.TabIndex = 1;
            this.SaveD.Text = "Save ";
            this.SaveD.UseVisualStyleBackColor = true;
            // 
            // AddD
            // 
            this.AddD.Location = new System.Drawing.Point(849, 108);
            this.AddD.Name = "AddD";
            this.AddD.Size = new System.Drawing.Size(108, 46);
            this.AddD.TabIndex = 2;
            this.AddD.Text = "Add";
            this.AddD.UseVisualStyleBackColor = true;
            this.AddD.Click += new System.EventHandler(this.AddD_Click);
            // 
            // DepartmentT
            // 
            this.DepartmentT.HeaderText = "Department";
            this.DepartmentT.MinimumWidth = 6;
            this.DepartmentT.Name = "DepartmentT";
            this.DepartmentT.Width = 350;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.Width = 125;
            // 
            // Created
            // 
            this.Created.HeaderText = "Created";
            this.Created.MinimumWidth = 6;
            this.Created.Name = "Created";
            this.Created.Width = 125;
            // 
            // Departments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 384);
            this.Controls.Add(this.AddD);
            this.Controls.Add(this.SaveD);
            this.Controls.Add(this.departmentGridView1);
            this.Name = "Departments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Departments";
            ((System.ComponentModel.ISupportInitialize)(this.departmentGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView departmentGridView1;
        private System.Windows.Forms.Button SaveD;
        private System.Windows.Forms.Button AddD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartmentT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Created;
    }
}