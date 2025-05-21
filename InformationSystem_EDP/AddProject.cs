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
            InitializeStatusComboBox();
        }

        private void InitializeStatusComboBox()
        {
            // Initialize Status ComboBox with project statuses
            statusSelect.Items.AddRange(new string[] { "Active", "On Hold", "Completed", "Cancelled" });
            statusSelect.SelectedIndex = 0; // Default to Active
        }

        private void Save1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void AddProject_Load(object sender, EventArgs e)
        {
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void Save1_Click_1(object sender, EventArgs e)
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
                    string query = @"INSERT INTO Projects (ProjectName, StartDate, EndDate, Status, CreatedAt) 
                                   VALUES (@ProjectName, @StartDate, @EndDate, @Status, NOW())";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProjectName", ProjectNameAP.Text);
                        cmd.Parameters.AddWithValue("@StartDate", StartDateAP.Value);
                        cmd.Parameters.AddWithValue("@EndDate", EndDateAP.Value);
                        cmd.Parameters.AddWithValue("@Status", statusSelect.SelectedItem?.ToString() ?? "Active");

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

        private void statusSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EndDateAP_ValueChanged(object sender, EventArgs e)
        {

        }

        private void StartDateAP_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
