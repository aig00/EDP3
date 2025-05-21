using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
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
    public partial class signUp : Form
    {
        public signUp()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (passwordSignUp.Text != confirmpasswordSignUp.Text)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(usernameSignUp.Text) ||
                string.IsNullOrWhiteSpace(emailSignUp.Text) ||
                string.IsNullOrWhiteSpace(passwordSignUp.Text) ||
                string.IsNullOrWhiteSpace(roleSignUp.Text) ||
                string.IsNullOrWhiteSpace(securityquestionSignUp.Text) ||
                string.IsNullOrWhiteSpace(answerSignUp.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DbHelper db = new DbHelper();
            bool isSuccess = db.InsertUser(
                usernameSignUp.Text,
                passwordSignUp.Text,
                emailSignUp.Text,
                roleSignUp.Text,
                securityquestionSignUp.Text,
                answerSignUp.Text
            );

            if (isSuccess)
            {
                MessageBox.Show("Registration successful!");
                this.Hide();
                login login = new login();
                login.Show();
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void securityquestionSignUp_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_Click(object sender, EventArgs e)
        {
            this.Hide();
            login loginForm = new login();
            loginForm.Show();
        }
    }
}
