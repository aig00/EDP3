using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace InformationSystem_EDP
{
    public partial class Project : Form
    {
        public Project()
        {
            InitializeComponent();
            LoadProjects();
        }

        private void LoadProjects()
        {
            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ProjectID, ProjectName, StartDate, EndDate, Status, CreatedAt FROM Projects";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            projectsGridView1.Rows.Clear();
                            projectsGridView1.Columns.Clear();
                            projectsGridView1.Columns.Add("ProjectID", "Project ID");
                            projectsGridView1.Columns.Add("ProjectName", "Project Name");
                            projectsGridView1.Columns.Add("StartDate", "Start Date");
                            projectsGridView1.Columns.Add("EndDate", "End Date");
                            projectsGridView1.Columns.Add("Status", "Status");
                            projectsGridView1.Columns.Add("CreatedAt", "Created At");

                            foreach (DataRow row in dt.Rows)
                            {
                                int rowIndex = projectsGridView1.Rows.Add();
                                projectsGridView1.Rows[rowIndex].Cells["ProjectID"].Value = row["ProjectID"];
                                projectsGridView1.Rows[rowIndex].Cells["ProjectName"].Value = row["ProjectName"];
                                projectsGridView1.Rows[rowIndex].Cells["StartDate"].Value = row["StartDate"];
                                projectsGridView1.Rows[rowIndex].Cells["EndDate"].Value = row["EndDate"];
                                projectsGridView1.Rows[rowIndex].Cells["Status"].Value = row["Status"];
                                projectsGridView1.Rows[rowIndex].Cells["CreatedAt"].Value = row["CreatedAt"];
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading projects: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddP_Click(object sender, EventArgs e)
        {
            // Create and show the AddProject form
            AddProject addProjectForm = new AddProject();
            addProjectForm.Show();
        }

        private void AddTaskP_Click(object sender, EventArgs e)
        {
            // Create and show the AddTask form
            AddTask addTaskForm = new AddTask();
            addTaskForm.Show();
        }

        private void export_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog.Title = "Export Project Data";
                saveFileDialog.InitialDirectory = DbHelper.GetExportDirectory();
                saveFileDialog.FileName = "projects_" + DateTime.Now.ToString("yyyyMMdd");

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder csv = new StringBuilder();
                    
                    // Add headers
                    csv.AppendLine("Project Name,Start Date,End Date");

                    // Add data
                    foreach (DataGridViewRow row in projectsGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            csv.AppendLine(string.Format("{0},{1},{2}",
                                row.Cells["ProjectName"].Value,
                                row.Cells["StartDate"].Value,
                                row.Cells["EndDate"].Value));
                        }
                    }

                    System.IO.File.WriteAllText(saveFileDialog.FileName, csv.ToString());
                    MessageBox.Show("Data exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
