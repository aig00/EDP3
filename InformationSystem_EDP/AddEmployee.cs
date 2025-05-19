using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace InformationSystem_EDP
{
    public partial class AddEmployee : Form
    {
        public AddEmployee()
        {
            InitializeComponent();
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

            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    // 1. Insert into Users
                    string insertUserQuery = @"INSERT INTO Users (Username, PasswordHash, Email, RoleID) 
                                               VALUES (@Username, @PasswordHash, @Email, 3)";
                    using (MySqlCommand cmdUser = new MySqlCommand(insertUserQuery, conn))
                    {
                        cmdUser.Parameters.AddWithValue("@Username", username);
                        cmdUser.Parameters.AddWithValue("@PasswordHash", "defaultpasswordhash"); // Replace with actual hashing logic
                        cmdUser.Parameters.AddWithValue("@Email", email);
                        cmdUser.ExecuteNonQuery();
                    }

                    // 2. Get the newly inserted UserID
                    long userID = cmdLastInsertId(conn);

                    // 3. Get DepartmentID
                    string getDeptQuery = "SELECT DepartmentID FROM Departments WHERE DepartmentName = @DepartmentName";
                    int departmentID = 0;
                    using (MySqlCommand cmdDept = new MySqlCommand(getDeptQuery, conn))
                    {
                        cmdDept.Parameters.AddWithValue("@DepartmentName", departmentName);
                        object result = cmdDept.ExecuteScalar();
                        if (result != null)
                        {
                            departmentID = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("Invalid Department Name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // 4. Insert into Employees
                    string insertEmployeeQuery = @"INSERT INTO Employees (FullName, Email, PhoneNumber, DepartmentID, UserID)
                                                   VALUES (@FullName, @Email, @PhoneNumber, @DepartmentID, @UserID)";
                    using (MySqlCommand cmdEmployee = new MySqlCommand(insertEmployeeQuery, conn))
                    {
                        cmdEmployee.Parameters.AddWithValue("@FullName", fullName);
                        cmdEmployee.Parameters.AddWithValue("@Email", email);
                        cmdEmployee.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        cmdEmployee.Parameters.AddWithValue("@DepartmentID", departmentID);
                        cmdEmployee.Parameters.AddWithValue("@UserID", userID);

                        cmdEmployee.ExecuteNonQuery();
                    }

                    MessageBox.Show("Employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear fields
                    FullNameAE.Clear();
                    EmailAE.Clear();
                    PhoneNumberAE.Clear();
                    DepartmentAE.SelectedIndex = -1;
                    UsernameAE.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Helper to get last inserted ID
        private long cmdLastInsertId(MySqlConnection conn)
        {
            using (MySqlCommand cmd = new MySqlCommand("SELECT LAST_INSERT_ID();", conn))
            {
                object id = cmd.ExecuteScalar();
                return (id != null) ? Convert.ToInt64(id) : 0;
            }
        }
    }
}
