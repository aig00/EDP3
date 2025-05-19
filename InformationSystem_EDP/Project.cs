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
    public partial class Project : Form
    {
        public Project()
        {
            InitializeComponent();
        }

        private void AddP_Click(object sender, EventArgs e)
        {
            // Create and show the AddProject form
            AddProject addProjectForm = new AddProject();
            addProjectForm.Show();
        }

        private void AddTaskP_Click(object sender, EventArgs e)
        {
            // Create and show the AddTask form
            AddTask addTaskForm = new AddTask();
            addTaskForm.Show();
        }
    }
}
