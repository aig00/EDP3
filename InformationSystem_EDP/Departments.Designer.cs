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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DepartmentT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaveD = new System.Windows.Forms.Button();
            this.AddD = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DepartmentT});
            this.dataGridView1.Location = new System.Drawing.Point(12, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(403, 289);
            this.dataGridView1.TabIndex = 0;
            // 
            // DepartmentT
            // 
            this.DepartmentT.HeaderText = "Department";
            this.DepartmentT.MinimumWidth = 6;
            this.DepartmentT.Name = "DepartmentT";
            this.DepartmentT.Width = 350;
            // 
            // SaveD
            // 
            this.SaveD.Location = new System.Drawing.Point(445, 173);
            this.SaveD.Name = "SaveD";
            this.SaveD.Size = new System.Drawing.Size(108, 46);
            this.SaveD.TabIndex = 1;
            this.SaveD.Text = "Save ";
            this.SaveD.UseVisualStyleBackColor = true;
            // 
            // AddD
            // 
            this.AddD.Location = new System.Drawing.Point(445, 121);
            this.AddD.Name = "AddD";
            this.AddD.Size = new System.Drawing.Size(108, 46);
            this.AddD.TabIndex = 2;
            this.AddD.Text = "Add";
            this.AddD.UseVisualStyleBackColor = true;
            this.AddD.Click += new System.EventHandler(this.AddD_Click);
            // 
            // Departments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 319);
            this.Controls.Add(this.AddD);
            this.Controls.Add(this.SaveD);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Departments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Departments";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartmentT;
        private System.Windows.Forms.Button SaveD;
        private System.Windows.Forms.Button AddD;
    }
}