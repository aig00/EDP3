using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

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
                                        (SELECT DepartmentID FROM Departments WHERE DepartmentName = @DepartmentName)";
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
                        }

                        cmd.ExecuteNonQuery();
                        MessageBox.Show($"Employee {(isEditMode ? "updated" : "added")} successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
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
    }
}