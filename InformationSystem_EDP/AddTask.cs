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
    public partial class AddTask : Form
    {
        public AddTask()
        {
            InitializeComponent();
            LoadProjects();
            LoadEmployees();
        }

        private void LoadProjects()
        {
            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ProjectID, ProjectName FROM Projects WHERE Status = 'Active'";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                projectSelect.Items.Add(new KeyValuePair<int, string>(
                                    reader.GetInt32("ProjectID"),
                                    reader["ProjectName"].ToString()
                                ));
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

        private void LoadEmployees()
        {
            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT EmployeeID, FullName FROM Employees";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                AssignedToAT.Items.Add(new KeyValuePair<int, string>(
                                    reader.GetInt32("EmployeeID"),
                                    reader["FullName"].ToString()
                                ));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading employees: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Save1_Click(object sender, EventArgs e)
        {
            

            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Save1_Click_1(object sender, EventArgs e)
        {
            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                if (string.IsNullOrWhiteSpace(TitleAT.Text))
                {
                    MessageBox.Show("Please enter a task title.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (projectSelect.SelectedItem == null)
                {
                    MessageBox.Show("Please select a project.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (AssignedToAT.SelectedItem == null)
                {
                    MessageBox.Show("Please select an employee to assign the task to.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime dueDate;
                if (!DateTime.TryParse(DueDateAT.Text, out dueDate))
                {
                    MessageBox.Show("Please enter a valid due date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    conn.Open();
                    string query = @"INSERT INTO Tasks (Title, Description, ProjectID, AssignedTo, DueDate, Status, Priority, CreatedAt, UpdatedAt) 
                                   VALUES (@Title, @Description, @ProjectID, @AssignedTo, @DueDate, 'Pending', 'Medium', NOW(), NOW())";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        var selectedProject = (KeyValuePair<int, string>)projectSelect.SelectedItem;
                        var selectedEmployee = (KeyValuePair<int, string>)AssignedToAT.SelectedItem;

                        cmd.Parameters.AddWithValue("@Title", TitleAT.Text);
                        cmd.Parameters.AddWithValue("@ProjectID", selectedProject.Key);
                        cmd.Parameters.AddWithValue("@AssignedTo", selectedEmployee.Key);
                        cmd.Parameters.AddWithValue("@DueDate", dueDate);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Task added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding task: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
