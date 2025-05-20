namespace InformationSystem_EDP
{
    partial class Project
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
            this.projectsGridView1 = new System.Windows.Forms.DataGridView();
            this.ProjectNamePT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionPT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDatePT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDatePT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddP = new System.Windows.Forms.Button();
            this.SaveP = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.projectsGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // projectsGridView1
            // 
            this.projectsGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.projectsGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.projectsGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProjectNamePT,
            this.DescriptionPT,
            this.StartDatePT,
            this.EndDatePT});
            this.projectsGridView1.Location = new System.Drawing.Point(15, 16);
            this.projectsGridView1.Name = "projectsGridView1";
            this.projectsGridView1.RowHeadersWidth = 51;
            this.projectsGridView1.RowTemplate.Height = 24;
            this.projectsGridView1.Size = new System.Drawing.Size(603, 415);
            this.projectsGridView1.TabIndex = 0;
            // 
            // ProjectNamePT
            // 
            this.ProjectNamePT.HeaderText = "Project Name";
            this.ProjectNamePT.MinimumWidth = 6;
            this.ProjectNamePT.Name = "ProjectNamePT";
            this.ProjectNamePT.Width = 150;
            // 
            // DescriptionPT
            // 
            this.DescriptionPT.HeaderText = "Description";
            this.DescriptionPT.MinimumWidth = 6;
            this.DescriptionPT.Name = "DescriptionPT";
            this.DescriptionPT.Width = 150;
            // 
            // StartDatePT
            // 
            this.StartDatePT.HeaderText = "Start Date";
            this.StartDatePT.MinimumWidth = 6;
            this.StartDatePT.Name = "StartDatePT";
            this.StartDatePT.Width = 125;
            // 
            // EndDatePT
            // 
            this.EndDatePT.HeaderText = "End Date";
            this.EndDatePT.MinimumWidth = 6;
            this.EndDatePT.Name = "EndDatePT";
            this.EndDatePT.Width = 125;
            // 
            // AddP
            // 
            this.AddP.Location = new System.Drawing.Point(671, 169);
            this.AddP.Name = "AddP";
            this.AddP.Size = new System.Drawing.Size(108, 46);
            this.AddP.TabIndex = 4;
            this.AddP.Text = "Add";
            this.AddP.UseVisualStyleBackColor = true;
            this.AddP.Click += new System.EventHandler(this.AddP_Click);
            // 
            // SaveP
            // 
            this.SaveP.Location = new System.Drawing.Point(671, 221);
            this.SaveP.Name = "SaveP";
            this.SaveP.Size = new System.Drawing.Size(108, 46);
            this.SaveP.TabIndex = 5;
            this.SaveP.Text = "Save";
            this.SaveP.UseVisualStyleBackColor = true;
            // 
            // Project
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 450);
            this.Controls.Add(this.SaveP);
            this.Controls.Add(this.AddP);
            this.Controls.Add(this.projectsGridView1);
            this.Name = "Project";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project";
            ((System.ComponentModel.ISupportInitialize)(this.projectsGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView projectsGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectNamePT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionPT;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDatePT;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDatePT;
        private System.Windows.Forms.Button AddP;
        private System.Windows.Forms.Button SaveP;
    }
}