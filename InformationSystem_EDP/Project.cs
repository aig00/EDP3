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
                    string query = "SELECT ProjectID, ProjectName, Description, StartDate, EndDate, Status, CreatedAt, UpdatedAt FROM Projects";
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
                            projectsGridView1.Columns.Add("Description", "Description");
                            projectsGridView1.Columns.Add("StartDate", "Start Date");
                            projectsGridView1.Columns.Add("EndDate", "End Date");
                            projectsGridView1.Columns.Add("Status", "Status");
                            projectsGridView1.Columns.Add("CreatedAt", "Created At");
                            projectsGridView1.Columns.Add("UpdatedAt", "Updated At");

                            foreach (DataRow row in dt.Rows)
                            {
                                int rowIndex = projectsGridView1.Rows.Add();
                                projectsGridView1.Rows[rowIndex].Cells["ProjectID"].Value = row["ProjectID"];
                                projectsGridView1.Rows[rowIndex].Cells["ProjectName"].Value = row["ProjectName"];
                                projectsGridView1.Rows[rowIndex].Cells["Description"].Value = row["Description"];
                                projectsGridView1.Rows[rowIndex].Cells["StartDate"].Value = row["StartDate"];
                                projectsGridView1.Rows[rowIndex].Cells["EndDate"].Value = row["EndDate"];
                                projectsGridView1.Rows[rowIndex].Cells["Status"].Value = row["Status"];
                                projectsGridView1.Rows[rowIndex].Cells["CreatedAt"].Value = row["CreatedAt"];
                                projectsGridView1.Rows[rowIndex].Cells["UpdatedAt"].Value = row["UpdatedAt"];
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
    }
}
