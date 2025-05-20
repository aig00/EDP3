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
    public partial class EmployeeM : Form
    {
        public EmployeeM()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadEmployees();
            LoadDepartments();
        }

        private void SetupDataGridView()
        {
            // Clear existing columns
            dataGridView1.Columns.Clear();

            // Add data columns first
            dataGridView1.Columns.Add("FullName", "Full Name");
            dataGridView1.Columns.Add("Email", "Email");
            dataGridView1.Columns.Add("PhoneNumber", "Phone Number");
            dataGridView1.Columns.Add("DepartmentName", "Department");
            dataGridView1.Columns.Add("Username", "Username");

            // Add Edit Button Column
            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
            editButton.Name = "Edit";
            editButton.HeaderText = "Edit";
            editButton.Text = "Edit";
            editButton.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(editButton);

            // Add Delete Button Column
            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "Delete";
            deleteButton.HeaderText = "Delete";
            deleteButton.Text = "Delete";
            deleteButton.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(deleteButton);

            // Set column properties
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadEmployees()
        {
            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT e.EmployeeID, e.FullName, e.Email, e.PhoneNumber, 
                                   d.DepartmentName, u.Username 
                                   FROM Employees e 
                                   JOIN Departments d ON e.DepartmentID = d.DepartmentID 
                                   JOIN Users u ON e.UserID = u.UserID";
                    
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Clear existing rows
                            dataGridView1.Rows.Clear();

                            // Add rows
                            foreach (DataRow row in dt.Rows)
                            {
                                int rowIndex = dataGridView1.Rows.Add();
                                dataGridView1.Rows[rowIndex].Cells["FullName"].Value = row["FullName"];
                                dataGridView1.Rows[rowIndex].Cells["Email"].Value = row["Email"];
                                dataGridView1.Rows[rowIndex].Cells["PhoneNumber"].Value = row["PhoneNumber"];
                                dataGridView1.Rows[rowIndex].Cells["DepartmentName"].Value = row["DepartmentName"];
                                dataGridView1.Rows[rowIndex].Cells["Username"].Value = row["Username"];
                                dataGridView1.Rows[rowIndex].Tag = row["EmployeeID"]; // Store EmployeeID in Tag
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

        private void LoadDepartments()
        {
            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT DepartmentName FROM Departments";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            DepartmentAE.Items.Clear();
                            while (reader.Read())
                            {
                                DepartmentAE.Items.Add(reader["DepartmentName"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading departments: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddE_Click(object sender, EventArgs e)
        {
            AddEmployee addEmployeeForm = new AddEmployee();
            addEmployeeForm.FormClosed += (s, args) => LoadEmployees();
            addEmployeeForm.Show();
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = SearchBox.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                LoadEmployees();
                return;
            }

            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT e.EmployeeID, e.FullName, e.Email, e.PhoneNumber, 
                                   d.DepartmentName, u.Username 
                                   FROM Employees e 
                                   JOIN Departments d ON e.DepartmentID = d.DepartmentID 
                                   JOIN Users u ON e.UserID = u.UserID
                                   WHERE LOWER(e.FullName) LIKE @Search 
                                   OR LOWER(e.Email) LIKE @Search 
                                   OR LOWER(d.DepartmentName) LIKE @Search 
                                   OR LOWER(u.Username) LIKE @Search";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Search", "%" + searchText + "%");
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Clear existing rows
                            dataGridView1.Rows.Clear();

                            // Add rows
                            foreach (DataRow row in dt.Rows)
                            {
                                int rowIndex = dataGridView1.Rows.Add();
                                dataGridView1.Rows[rowIndex].Cells["FullName"].Value = row["FullName"];
                                dataGridView1.Rows[rowIndex].Cells["Email"].Value = row["Email"];
                                dataGridView1.Rows[rowIndex].Cells["PhoneNumber"].Value = row["PhoneNumber"];
                                dataGridView1.Rows[rowIndex].Cells["DepartmentName"].Value = row["DepartmentName"];
                                dataGridView1.Rows[rowIndex].Cells["Username"].Value = row["Username"];
                                dataGridView1.Rows[rowIndex].Tag = row["EmployeeID"]; // Store EmployeeID in Tag
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error searching employees: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int employeeId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Tag);

                if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
                {
                    EditEmployee(employeeId);
                }
                else if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
                {
                    DeleteEmployee(employeeId);
                }
            }
        }

        private void EditEmployee(int employeeId)
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
                                AddEmployee editForm = new AddEmployee(employeeId);
                                editForm.FormClosed += (s, args) => LoadEmployees();
                                editForm.Show();
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

        private void DeleteEmployee(int employeeId)
        {
            var result = MessageBox.Show("Are you sure you want to delete this employee?", 
                                       "Confirm Delete", 
                                       MessageBoxButtons.YesNo, 
                                       MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (MySqlConnection conn = DbHelper.GetConnection())
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Employee deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadEmployees();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting employee: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
