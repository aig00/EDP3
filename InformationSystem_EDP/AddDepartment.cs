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
    public partial class AddDepartment : Form
    {
        public AddDepartment()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddDepartment_Load(object sender, EventArgs e)
        {

        }

        private void Save1_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DepartmentAD.Text))
            {
                MessageBox.Show("Please enter a department name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO Departments (DepartmentName, CreatedAt) 
                                   VALUES (@DepartmentName, NOW())";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@DepartmentName", DepartmentAD.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Department added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding department: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
