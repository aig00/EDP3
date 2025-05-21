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
        private Task parentTaskForm;

        public AddTask(Task parentForm = null)
        {
            InitializeComponent();
            parentTaskForm = parentForm;
            LoadProjects();
            LoadEmployees();
            InitializeComboBoxes();
            InitializeDateTimePicker();
        }

        private void InitializeDateTimePicker()
        {
            DueDateAT.Format = DateTimePickerFormat.Short;
            DueDateAT.Value = DateTime.Now.AddDays(7); // Default to 1 week from now
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

        private void InitializeComboBoxes()
        {
            // Initialize Status ComboBox
            statusSelect.Items.AddRange(new string[] { "Pending", "In Progress", "Completed", "On Hold", "Cancelled" });
            statusSelect.SelectedIndex = 0;

            // Initialize Priority ComboBox
            prioritySelect.Items.AddRange(new string[] { "Low", "Medium", "High", "Urgent" });
            prioritySelect.SelectedIndex = 1; // Default to Medium
        }

        private void Save1_Click(object sender, EventArgs e)
        {
            

            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Save1_Click_1(object sender, EventArgs e)
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

            try
            {
                using (MySqlConnection conn = DbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO Tasks (Title, ProjectID, AssignedTo, DueDate, Status, Priority, CreatedAt) 
                                   VALUES (@Title, @ProjectID, @AssignedTo, @DueDate, @Status, @Priority, NOW())";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        var selectedProject = (KeyValuePair<int, string>)projectSelect.SelectedItem;
                        var selectedEmployee = (KeyValuePair<int, string>)AssignedToAT.SelectedItem;

                        cmd.Parameters.AddWithValue("@Title", TitleAT.Text);
                        cmd.Parameters.AddWithValue("@ProjectID", selectedProject.Key);
                        cmd.Parameters.AddWithValue("@AssignedTo", selectedEmployee.Key);
                        cmd.Parameters.AddWithValue("@DueDate", DueDateAT.Value);
                        cmd.Parameters.AddWithValue("@Status", statusSelect.SelectedItem?.ToString() ?? "Pending");
                        cmd.Parameters.AddWithValue("@Priority", prioritySelect.SelectedItem?.ToString() ?? "Medium");

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Task added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Reload the parent form's grid if it exists
                        if (parentTaskForm != null)
                        {
                            parentTaskForm.LoadTasks();
                        }
                        
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding task: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TitleAT_TextChanged(object sender, EventArgs e)
        {

        }

        private void projectSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AssignedToAT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void statusSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void prioritySelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DueDateAT_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
