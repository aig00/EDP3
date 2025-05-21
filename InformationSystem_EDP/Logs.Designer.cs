namespace InformationSystem_EDP
{
    partial class Logs
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
            this.logsGridView1 = new System.Windows.Forms.DataGridView();
            this.export = new System.Windows.Forms.Button();
            this.ActionL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionDateL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.logsGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // logsGridView1
            // 
            this.logsGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.logsGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logsGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ActionL,
            this.ActionDateL});
            this.logsGridView1.Location = new System.Drawing.Point(12, 12);
            this.logsGridView1.Name = "logsGridView1";
            this.logsGridView1.RowHeadersWidth = 51;
            this.logsGridView1.RowTemplate.Height = 24;
            this.logsGridView1.Size = new System.Drawing.Size(776, 379);
            this.logsGridView1.TabIndex = 0;
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(671, 401);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(117, 37);
            this.export.TabIndex = 6;
            this.export.Text = "EXPORT";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // ActionL
            // 
            this.ActionL.HeaderText = "Action";
            this.ActionL.MinimumWidth = 6;
            this.ActionL.Name = "ActionL";
            this.ActionL.ReadOnly = true;
            this.ActionL.Width = 220;
            // 
            // ActionDateL
            // 
            this.ActionDateL.HeaderText = "Action Date";
            this.ActionDateL.MinimumWidth = 6;
            this.ActionDateL.Name = "ActionDateL";
            this.ActionDateL.ReadOnly = true;
            this.ActionDateL.Width = 220;
            // 
            // Logs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.export);
            this.Controls.Add(this.logsGridView1);
            this.Name = "Logs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logs";
            ((System.ComponentModel.ISupportInitialize)(this.logsGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView logsGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionDateL;
        private System.Windows.Forms.Button export;
    }
}