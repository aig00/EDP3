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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            LoadEmployeeDetails();
        }

        private void LoadEmployeeDetails()
        {
            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT e.FullName, e.Email, e.PhoneNumber, 
                                   d.DepartmentName, 
                                   GROUP_CONCAT(DISTINCT p.ProjectName) as Projects,
                                   GROUP_CONCAT(DISTINCT t.Title) as Tasks
                                   FROM Employees e 
                                   JOIN Departments d ON e.DepartmentID = d.DepartmentID 
                                   LEFT JOIN ProjectAssignments pa ON e.EmployeeID = pa.EmployeeID
                                   LEFT JOIN Projects p ON pa.ProjectID = p.ProjectID
                                   LEFT JOIN Tasks t ON e.EmployeeID = t.AssignedTo
                                   GROUP BY e.EmployeeID, e.FullName, e.Email, e.PhoneNumber, d.DepartmentName";
                    
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Clear existing rows
                            dashboardGridView1.Rows.Clear();

                            // Add rows
                            foreach (DataRow row in dt.Rows)
                            {
                                int rowIndex = dashboardGridView1.Rows.Add();
                                dashboardGridView1.Rows[rowIndex].Cells["NameDT"].Value = row["FullName"];
                                dashboardGridView1.Rows[rowIndex].Cells["EmailDT"].Value = row["Email"];
                                dashboardGridView1.Rows[rowIndex].Cells["PhoneNumberDT"].Value = row["PhoneNumber"];
                                dashboardGridView1.Rows[rowIndex].Cells["DepartmentDT"].Value = row["DepartmentName"];
                                dashboardGridView1.Rows[rowIndex].Cells["LinkedUsernameDT"].Value = row["Projects"];
                                dashboardGridView1.Rows[rowIndex].Cells["TasksDT"].Value = row["Tasks"];
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading employee details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Dashboard1_Click(object sender, EventArgs e)
        {
            LoadEmployeeDetails(); // Refresh the data when dashboard button is clicked
        }

        private void EmployeeD_Click(object sender, EventArgs e)
        {
            // Create and show the EmployeeM form
            EmployeeM employeeForm = new EmployeeM();
            employeeForm.FormClosed += (s, args) => LoadEmployeeDetails(); // Refresh dashboard when employee form is closed
            employeeForm.Show();
        }

        private void DepartmentD_Click(object sender, EventArgs e)
        {
            // Create and show the Departments form
            Departments departmentForm = new Departments();
            departmentForm.Show();
        }

        private void ProjectsD_Click(object sender, EventArgs e)
        {
            // Create and show the Project form
            Project projectForm = new Project();
            projectForm.FormClosed += (s, args) => LoadEmployeeDetails(); // Refresh dashboard when project form is closed
            projectForm.Show();
        }

        private void TasksD_Click(object sender, EventArgs e)
        {
            // Create and show the Task form
            Task taskForm = new Task();
            taskForm.FormClosed += (s, args) => LoadEmployeeDetails(); // Refresh dashboard when task form is closed
            taskForm.Show();
        }

        private void LogsD_Click(object sender, EventArgs e)
        {
            // Create and show the Logs form
            Logs logsForm = new Logs();
            logsForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Logout functionality
            this.Close();
            Application.Restart();
        }
    }
}
