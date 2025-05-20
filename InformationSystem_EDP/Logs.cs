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
                    string query = "SELECT LogID, EmployeeID, Action, ActionDate, Details FROM Logs";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            logsGridView1.Rows.Clear();
                            logsGridView1.Columns.Clear();
                            logsGridView1.Columns.Add("LogID", "Log ID");
                            logsGridView1.Columns.Add("EmployeeID", "Employee ID");
                            logsGridView1.Columns.Add("Action", "Action");
                            logsGridView1.Columns.Add("ActionDate", "Action Date");
                            logsGridView1.Columns.Add("Details", "Details");

                            foreach (DataRow row in dt.Rows)
                            {
                                int rowIndex = logsGridView1.Rows.Add();
                                logsGridView1.Rows[rowIndex].Cells["LogID"].Value = row["LogID"];
                                logsGridView1.Rows[rowIndex].Cells["EmployeeID"].Value = row["EmployeeID"];
                                logsGridView1.Rows[rowIndex].Cells["Action"].Value = row["Action"];
                                logsGridView1.Rows[rowIndex].Cells["ActionDate"].Value = row["ActionDate"];
                                logsGridView1.Rows[rowIndex].Cells["Details"].Value = row["Details"];
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
    }
}
