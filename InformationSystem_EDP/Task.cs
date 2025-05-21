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
            AddTask addTaskForm = new AddTask(this);
            addTaskForm.Show();
        }

        public void LoadTasks()
        {
            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT TaskID, Title, AssignedTo, DueDate, ProjectID, Status, Priority, CreatedAt FROM Tasks";
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
                            tasksGridView1.Columns.Add("AssignedTo", "Assigned To");
                            tasksGridView1.Columns.Add("DueDate", "Due Date");
                            tasksGridView1.Columns.Add("ProjectID", "Project ID");
                            tasksGridView1.Columns.Add("Status", "Status");
                            tasksGridView1.Columns.Add("Priority", "Priority");
                            tasksGridView1.Columns.Add("CreatedAt", "Created At");

                            foreach (DataRow row in dt.Rows)
                            {
                                int rowIndex = tasksGridView1.Rows.Add();
                                tasksGridView1.Rows[rowIndex].Cells["TaskID"].Value = row["TaskID"];
                                tasksGridView1.Rows[rowIndex].Cells["Title"].Value = row["Title"];
                                tasksGridView1.Rows[rowIndex].Cells["AssignedTo"].Value = row["AssignedTo"];
                                tasksGridView1.Rows[rowIndex].Cells["DueDate"].Value = row["DueDate"];
                                tasksGridView1.Rows[rowIndex].Cells["ProjectID"].Value = row["ProjectID"];
                                tasksGridView1.Rows[rowIndex].Cells["Status"].Value = row["Status"];
                                tasksGridView1.Rows[rowIndex].Cells["Priority"].Value = row["Priority"];
                                tasksGridView1.Rows[rowIndex].Cells["CreatedAt"].Value = row["CreatedAt"];
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

        private void export_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog.Title = "Export Task Data";
                saveFileDialog.FileName = "tasks_" + DateTime.Now.ToString("yyyyMMdd");

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder csv = new StringBuilder();
                    
                    // Add headers
                    csv.AppendLine("Title,Description,Due Date,Assigned To,Project");

                    // Add data
                    foreach (DataGridViewRow row in tasksGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            csv.AppendLine(string.Format("{0},{1},{2},{3},{4}",
                                row.Cells["TitleT"].Value,
                                row.Cells["DescriptionE"].Value,
                                row.Cells["DueDateT"].Value,
                                row.Cells["AssignedToT"].Value,
                                row.Cells["ProjectT"].Value));
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
