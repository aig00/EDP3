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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Dashboard1_Click(object sender, EventArgs e)
        {

        }

        private void EmployeeD_Click(object sender, EventArgs e)
        {
            // Create and show the EmployeeM form
            EmployeeM employeeForm = new EmployeeM();
            employeeForm.Show();
        }

        private void DepartmentD_Click(object sender, EventArgs e)
        {
            // Create and show the Departments form
            Departments departmentForm = new Departments();
            departmentForm.Show();
        }

        private void ProjectsD_Click(object sender, EventArgs e)
        {
            // Create and show the Project form
            Project projectForm = new Project();
            projectForm.Show();
        }

        private void TasksD_Click(object sender, EventArgs e)
        {
            // Create and show the Task form
            Task taskForm = new Task();
            taskForm.Show();
        }

        private void LogsD_Click(object sender, EventArgs e)
        {
            // Create and show the Logs form
            Logs logsForm = new Logs();
            logsForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
