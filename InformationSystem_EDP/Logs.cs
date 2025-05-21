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
    public partial class Logs : Form
    {
        public Logs()
        {
            InitializeComponent();
            LoadLogs();
        }

        private void LoadLogs()
        {
            using (MySqlConnection conn = DbHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT l.LogID, l.Action, l.Details, l.ActionDate, e.FullName as EmployeeName 
                                   FROM Logs l 
                                   LEFT JOIN Employees e ON l.EmployeeID = e.EmployeeID 
                                   ORDER BY l.ActionDate DESC";
                    
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            logsGridView1.Rows.Clear();
                            logsGridView1.Columns.Clear();
                            logsGridView1.Columns.Add("LogID", "Log ID");
                            logsGridView1.Columns.Add("Action", "Action");
                            logsGridView1.Columns.Add("Details", "Details");
                            logsGridView1.Columns.Add("ActionDate", "Action Date");
                            logsGridView1.Columns.Add("EmployeeName", "Employee");

                            foreach (DataRow row in dt.Rows)
                            {
                                int rowIndex = logsGridView1.Rows.Add();
                                logsGridView1.Rows[rowIndex].Cells["LogID"].Value = row["LogID"];
                                logsGridView1.Rows[rowIndex].Cells["Action"].Value = row["Action"];
                                logsGridView1.Rows[rowIndex].Cells["Details"].Value = row["Details"];
                                logsGridView1.Rows[rowIndex].Cells["ActionDate"].Value = row["ActionDate"];
                                logsGridView1.Rows[rowIndex].Cells["EmployeeName"].Value = row["EmployeeName"];
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading logs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void export_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog.Title = "Export Logs Data";
                saveFileDialog.FileName = "logs_" + DateTime.Now.ToString("yyyyMMdd");

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder csv = new StringBuilder();
                    // Add headers
                    csv.AppendLine("Action,Action Date,Employee");
                    // Add data
                    foreach (DataGridViewRow row in logsGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            csv.AppendLine(string.Format("{0},{1},{2}",
                                row.Cells["Action"].Value,
                                row.Cells["ActionDate"].Value,
                                row.Cells["EmployeeName"].Value));
                        }
                    }
                    System.IO.File.WriteAllText(saveFileDialog.FileName, csv.ToString());
                    MessageBox.Show("Data exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
