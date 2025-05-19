using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InformationSystem_EDP
{
    public partial class EmployeeM : Form
    {
        public EmployeeM()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddE_Click(object sender, EventArgs e)
        {
            // Create and show the AddEmployee form
            AddEmployee addEmployeeForm = new AddEmployee();
            addEmployeeForm.Show();
        }
    }
}
