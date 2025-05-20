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
    public partial class AddProject : Form
    {
        public AddProject()
        {
            InitializeComponent();
        }

        private void Save1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ProjectNameAP.Text))
            {
                MessageBox.Show("Please enter a project name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO Projects (ProjectName, Description, StartDate, EndDate, Status, CreatedAt, UpdatedAt) 
                                   VALUES (@ProjectName, @Description, @StartDate, @EndDate, 'Active', NOW(), NOW())";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProjectName", ProjectNameAP.Text);
                        cmd.Parameters.AddWithValue("@Description", EmailAE.Text);
                        cmd.Parameters.AddWithValue("@StartDate", StartDateAP.Value);
                        cmd.Parameters.AddWithValue("@EndDate", EndDateAP.Value);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Project added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding project: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void AddProject_Load(object sender, EventArgs e)
        {
            // Set default dates
            StartDateAP.Value = DateTime.Now;
            EndDateAP.Value = DateTime.Now.AddMonths(1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void ProjectNameAP_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
