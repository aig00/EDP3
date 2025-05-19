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
    public partial class Departments : Form
    {
        public Departments()
        {
            InitializeComponent();
        }

        private void AddD_Click(object sender, EventArgs e)
        {
            // Create and show the AddDepartment form
            AddDepartment addDepartmentForm = new AddDepartment();
            addDepartmentForm.Show();
        }
    }
}
