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
                    string query = @"SELECT e.*, d.DepartmentName, u.Username 
                                   FROM Employees e 
                                   JOIN Departments d ON e.DepartmentID = d.DepartmentID 
                                   JOIN Users u ON e.UserID = u.UserID 
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
                                UsernameAE.Text = reader["Username"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading employee data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private void Save1_Click(object sender, EventArgs e)
        {
            // Collect data from textboxes
            string fullName = FullNameAE.Text.Trim();
            string email = EmailAE.Text.Trim();
            string phoneNumber = PhoneNumberAE.Text.Trim();
            string departmentName = DepartmentAE.Text.Trim();
            string username = UsernameAE.Text.Trim();

            // Basic Validation
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(departmentName) || string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Email validation
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            if (!isEditMode)
                            {
                                // Insert new employee
                                InsertNewEmployee(conn, transaction, fullName, email, phoneNumber, departmentName, username);
                            }
                            else
                            {
                                // Update existing employee
                                UpdateExistingEmployee(conn, transaction, fullName, email, phoneNumber, departmentName, username);
                            }

                            transaction.Commit();
                            MessageBox.Show($"Employee {(isEditMode ? "updated" : "added")} successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InsertNewEmployee(MySqlConnection conn, MySqlTransaction transaction, string fullName, string email, string phoneNumber, string departmentName, string username)
        {
            // 1. Insert into Users
            string insertUserQuery = @"INSERT INTO Users (Username, PasswordHash, Email, RoleID) 
                                     VALUES (@Username, @PasswordHash, @Email, 3)";
            using (MySqlCommand cmdUser = new MySqlCommand(insertUserQuery, conn, transaction))
            {
                cmdUser.Parameters.AddWithValue("@Username", username);
                cmdUser.Parameters.AddWithValue("@PasswordHash", HashPassword("defaultpassword")); // Default password
                cmdUser.Parameters.AddWithValue("@Email", email);
                cmdUser.ExecuteNonQuery();
            }

            // 2. Get the newly inserted UserID
            long userID = cmdLastInsertId(conn);

            // 3. Get DepartmentID
            int departmentID = GetDepartmentID(conn, transaction, departmentName);

            // 4. Insert into Employees
            string insertEmployeeQuery = @"INSERT INTO Employees (FullName, Email, PhoneNumber, DepartmentID, UserID)
                                         VALUES (@FullName, @Email, @PhoneNumber, @DepartmentID, @UserID)";
            using (MySqlCommand cmdEmployee = new MySqlCommand(insertEmployeeQuery, conn, transaction))
            {
                cmdEmployee.Parameters.AddWithValue("@FullName", fullName);
                cmdEmployee.Parameters.AddWithValue("@Email", email);
                cmdEmployee.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                cmdEmployee.Parameters.AddWithValue("@DepartmentID", departmentID);
                cmdEmployee.Parameters.AddWithValue("@UserID", userID);
                cmdEmployee.ExecuteNonQuery();
            }
        }

        private void UpdateExistingEmployee(MySqlConnection conn, MySqlTransaction transaction, string fullName, string email, string phoneNumber, string departmentName, string username)
        {
            // 1. Get the UserID for this employee
            string getUserIDQuery = "SELECT UserID FROM Employees WHERE EmployeeID = @EmployeeID";
            long userID;
            using (MySqlCommand cmd = new MySqlCommand(getUserIDQuery, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                userID = Convert.ToInt64(cmd.ExecuteScalar());
            }

            // 2. Update Users table
            string updateUserQuery = @"UPDATE Users 
                                     SET Username = @Username, Email = @Email 
                                     WHERE UserID = @UserID";
            using (MySqlCommand cmdUser = new MySqlCommand(updateUserQuery, conn, transaction))
            {
                cmdUser.Parameters.AddWithValue("@Username", username);
                cmdUser.Parameters.AddWithValue("@Email", email);
                cmdUser.Parameters.AddWithValue("@UserID", userID);
                cmdUser.ExecuteNonQuery();
            }

            // 3. Get DepartmentID
            int departmentID = GetDepartmentID(conn, transaction, departmentName);

            // 4. Update Employees table
            string updateEmployeeQuery = @"UPDATE Employees 
                                         SET FullName = @FullName, 
                                             Email = @Email, 
                                             PhoneNumber = @PhoneNumber, 
                                             DepartmentID = @DepartmentID 
                                         WHERE EmployeeID = @EmployeeID";
            using (MySqlCommand cmdEmployee = new MySqlCommand(updateEmployeeQuery, conn, transaction))
            {
                cmdEmployee.Parameters.AddWithValue("@FullName", fullName);
                cmdEmployee.Parameters.AddWithValue("@Email", email);
                cmdEmployee.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                cmdEmployee.Parameters.AddWithValue("@DepartmentID", departmentID);
                cmdEmployee.Parameters.AddWithValue("@EmployeeID", employeeId);
                cmdEmployee.ExecuteNonQuery();
            }
        }

        private int GetDepartmentID(MySqlConnection conn, MySqlTransaction transaction, string departmentName)
        {
            string getDeptQuery = "SELECT DepartmentID FROM Departments WHERE DepartmentName = @DepartmentName";
            using (MySqlCommand cmdDept = new MySqlCommand(getDeptQuery, conn, transaction))
            {
                cmdDept.Parameters.AddWithValue("@DepartmentName", departmentName);
                object result = cmdDept.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    throw new Exception("Invalid Department Name.");
                }
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private long cmdLastInsertId(MySqlConnection conn)
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT LAST_INSERT_ID();", conn))
            {
                object id = cmd.ExecuteScalar();
                return (id != null) ? Convert.ToInt64(id) : 0;
            }
        }

        private void DepartmentAE_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
