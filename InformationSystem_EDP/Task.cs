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
    public partial class Task : Form
    {
        public Task()
        {
            InitializeComponent();
            LoadTasks();
        }

        private void AddT_Click(object sender, EventArgs e)
        {
            // Create and show the AddTask form
            AddTask addTaskForm = new AddTask();
            addTaskForm.Show();
        }

        private void LoadTasks()
        {
            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT TaskID, Title, Description, AssignedTo, DueDate, ProjectID, Status, Priority, CreatedAt, UpdatedAt FROM Tasks";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            tasksGridView1.Rows.Clear();
                            tasksGridView1.Columns.Clear();
                            tasksGridView1.Columns.Add("TaskID", "Task ID");
                            tasksGridView1.Columns.Add("Title", "Title");
                            tasksGridView1.Columns.Add("Description", "Description");
                            tasksGridView1.Columns.Add("AssignedTo", "Assigned To");
                            tasksGridView1.Columns.Add("DueDate", "Due Date");
                            tasksGridView1.Columns.Add("ProjectID", "Project ID");
                            tasksGridView1.Columns.Add("Status", "Status");
                            tasksGridView1.Columns.Add("Priority", "Priority");
                            tasksGridView1.Columns.Add("CreatedAt", "Created At");
                            tasksGridView1.Columns.Add("UpdatedAt", "Updated At");

                            foreach (DataRow row in dt.Rows)
                            {
                                int rowIndex = tasksGridView1.Rows.Add();
                                tasksGridView1.Rows[rowIndex].Cells["TaskID"].Value = row["TaskID"];
                                tasksGridView1.Rows[rowIndex].Cells["Title"].Value = row["Title"];
                                tasksGridView1.Rows[rowIndex].Cells["Description"].Value = row["Description"];
                                tasksGridView1.Rows[rowIndex].Cells["AssignedTo"].Value = row["AssignedTo"];
                                tasksGridView1.Rows[rowIndex].Cells["DueDate"].Value = row["DueDate"];
                                tasksGridView1.Rows[rowIndex].Cells["ProjectID"].Value = row["ProjectID"];
                                tasksGridView1.Rows[rowIndex].Cells["Status"].Value = row["Status"];
                                tasksGridView1.Rows[rowIndex].Cells["Priority"].Value = row["Priority"];
                                tasksGridView1.Rows[rowIndex].Cells["CreatedAt"].Value = row["CreatedAt"];
                                tasksGridView1.Rows[rowIndex].Cells["UpdatedAt"].Value = row["UpdatedAt"];
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading tasks: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
