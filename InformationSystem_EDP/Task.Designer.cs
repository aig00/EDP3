namespace InformationSystem_EDP
{
    partial class Task
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
            this.tasksGridView1 = new System.Windows.Forms.DataGridView();
            this.TitleT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDateT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssignedToT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddT = new System.Windows.Forms.Button();
            this.export = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tasksGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tasksGridView1
            // 
            this.tasksGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.tasksGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tasksGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TitleT,
            this.DescriptionE,
            this.DueDateT,
            this.AssignedToT,
            this.ProjectT});
            this.tasksGridView1.Location = new System.Drawing.Point(7, 11);
            this.tasksGridView1.Name = "tasksGridView1";
            this.tasksGridView1.RowHeadersWidth = 51;
            this.tasksGridView1.RowTemplate.Height = 24;
            this.tasksGridView1.Size = new System.Drawing.Size(678, 431);
            this.tasksGridView1.TabIndex = 0;
            // 
            // TitleT
            // 
            this.TitleT.HeaderText = "Title";
            this.TitleT.MinimumWidth = 6;
            this.TitleT.Name = "TitleT";
            this.TitleT.Width = 125;
            // 
            // DescriptionE
            // 
            this.DescriptionE.HeaderText = "Description";
            this.DescriptionE.MinimumWidth = 6;
            this.DescriptionE.Name = "DescriptionE";
            this.DescriptionE.Width = 125;
            // 
            // DueDateT
            // 
            this.DueDateT.HeaderText = "Due Date";
            this.DueDateT.MinimumWidth = 6;
            this.DueDateT.Name = "DueDateT";
            this.DueDateT.Width = 125;
            // 
            // AssignedToT
            // 
            this.AssignedToT.HeaderText = "Assigned To";
            this.AssignedToT.MinimumWidth = 6;
            this.AssignedToT.Name = "AssignedToT";
            this.AssignedToT.Width = 125;
            // 
            // ProjectT
            // 
            this.ProjectT.HeaderText = "Project";
            this.ProjectT.MinimumWidth = 6;
            this.ProjectT.Name = "ProjectT";
            this.ProjectT.Width = 125;
            // 
            // AddT
            // 
            this.AddT.Location = new System.Drawing.Point(714, 180);
            this.AddT.Name = "AddT";
            this.AddT.Size = new System.Drawing.Size(108, 46);
            this.AddT.TabIndex = 4;
            this.AddT.Text = "Add";
            this.AddT.UseVisualStyleBackColor = true;
            this.AddT.Click += new System.EventHandler(this.AddT_Click);
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(714, 232);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(108, 46);
            this.export.TabIndex = 6;
            this.export.Text = "EXPORT";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // Task
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 450);
            this.Controls.Add(this.export);
            this.Controls.Add(this.AddT);
            this.Controls.Add(this.tasksGridView1);
            this.Name = "Task";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task";
            ((System.ComponentModel.ISupportInitialize)(this.tasksGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tasksGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDateT;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssignedToT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectT;
        private System.Windows.Forms.Button AddT;
        private System.Windows.Forms.Button export;
    }
}