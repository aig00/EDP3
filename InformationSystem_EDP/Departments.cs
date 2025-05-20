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
    public partial class Departments : Form
    {
        public Departments()
        {
            InitializeComponent();
            LoadDepartments();
        }

        private void AddD_Click(object sender, EventArgs e)
        {
            // Create and show the AddDepartment form
            AddDepartment addDepartmentForm = new AddDepartment();
            addDepartmentForm.Show();
        }
        private void LoadDepartments()
        {
            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT DepartmentName, Description, CreatedAt FROM Departments";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            departmentGridView1.Rows.Clear();
                            departmentGridView1.Columns.Clear();
                            departmentGridView1.Columns.Add("DepartmentName", "Department Name");
                            departmentGridView1.Columns.Add("Description", "Description");
                            departmentGridView1.Columns.Add("CreatedAt", "Created At");

                            foreach (DataRow row in dt.Rows)
                            {
                                int rowIndex = departmentGridView1.Rows.Add();
                                departmentGridView1.Rows[rowIndex].Cells["DepartmentName"].Value = row["DepartmentName"];
                                departmentGridView1.Rows[rowIndex].Cells["Description"].Value = row["Description"];
                                departmentGridView1.Rows[rowIndex].Cells["CreatedAt"].Value = row["CreatedAt"];
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
    }
}
