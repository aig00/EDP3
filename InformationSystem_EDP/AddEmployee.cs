using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

namespace InformationSystem_EDP
{
    public partial class AddEmployee : Form
    {
        private int? employeeId;
        private bool isEditMode;

        public AddEmployee(int? employeeId = null)
        {
            InitializeComponent();
            LoadDepartments();
            LoadProjectsForAssignment();
            this.employeeId = employeeId;
            this.isEditMode = employeeId.HasValue;

            if (isEditMode)
            {
                this.Text = "Edit Employee";
                LoadEmployeeData();
            }
            else
            {
                this.Text = "Add Employee";
            }
        }

        private void LoadDepartments()
        {
            DepartmentAE.Items.Clear();
            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT DepartmentName FROM Departments";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DepartmentAE.Items.Add(reader["DepartmentName"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading departments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadEmployeeData()
        {
            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT e.*, d.DepartmentName 
                                   FROM Employees e 
                                   LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID 
                                   WHERE e.EmployeeID = @EmployeeID";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                FullNameAE.Text = reader["FullName"].ToString();
                                EmailAE.Text = reader["Email"].ToString();
                                PhoneNumberAE.Text = reader["PhoneNumber"].ToString();
                                DepartmentAE.Text = reader["DepartmentName"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading employee data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Save1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FullNameAE.Text) ||
                string.IsNullOrWhiteSpace(EmailAE.Text) ||
                string.IsNullOrWhiteSpace(PhoneNumberAE.Text) ||
                string.IsNullOrWhiteSpace(DepartmentAE.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!isEditMode && projectAE.SelectedItem == null)
            {
                MessageBox.Show("Please select a project to assign.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query;
                    if (isEditMode)
                    {
                        query = @"UPDATE Employees 
                                SET FullName = @FullName, 
                                    Email = @Email, 
                                    PhoneNumber = @PhoneNumber, 
                                    DepartmentID = (SELECT DepartmentID FROM Departments WHERE DepartmentName = @DepartmentName)
                                WHERE EmployeeID = @EmployeeID";
                    }
                    else
                    {
                        query = @"INSERT INTO Employees (FullName, Email, PhoneNumber, DepartmentID) 
                                VALUES (@FullName, @Email, @PhoneNumber, 
                                        (SELECT DepartmentID FROM Departments WHERE DepartmentName = @DepartmentName));
                                SELECT LAST_INSERT_ID();";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", FullNameAE.Text);
                        cmd.Parameters.AddWithValue("@Email", EmailAE.Text);
                        cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumberAE.Text);
                        cmd.Parameters.AddWithValue("@DepartmentName", DepartmentAE.Text);

                        if (isEditMode)
                        {
                            cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            // Insert employee and get new EmployeeID
                            object result = cmd.ExecuteScalar();
                            int newEmployeeId = Convert.ToInt32(result);

                            // Assign to project
                            var selectedProject = (KeyValuePair<int, string>)projectAE.SelectedItem;
                            string assignQuery = "INSERT INTO ProjectAssignments (EmployeeID, ProjectID) VALUES (@EmployeeID, @ProjectID)";
                            using (MySqlCommand assignCmd = new MySqlCommand(assignQuery, conn))
                            {
                                assignCmd.Parameters.AddWithValue("@EmployeeID", newEmployeeId);
                                assignCmd.Parameters.AddWithValue("@ProjectID", selectedProject.Key);
                                assignCmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Employee added and assigned to project successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error {(isEditMode ? "updating" : "adding")} employee: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DepartmentAE_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void projectAE_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadProjectsForAssignment()
        {
            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ProjectID, ProjectName FROM Projects";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        projectAE.Items.Clear();
                        while (reader.Read())
                        {
                            projectAE.Items.Add(new KeyValuePair<int, string>(
                                reader.GetInt32("ProjectID"),
                                reader["ProjectName"].ToString()
                            ));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading projects: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}