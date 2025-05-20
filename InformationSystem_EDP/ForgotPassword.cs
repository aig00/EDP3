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
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameReset.Text))
            {
                MessageBox.Show("Please enter a username.");
                return;
            }

            DbHelper db = new DbHelper();
            string question = db.GetSecurityQuestion(usernameReset.Text.Trim());

            if (!string.IsNullOrEmpty(question))
            {
                QuestionDisplay.Text = question;
            }
            else
            {
                MessageBox.Show("Username not found.");
            }
        }

        private void ForgotPassword_Load(object sender, EventArgs e)
        {
            // Clear any previous data
            usernameReset.Clear();
            answerReset.Clear();
            passwordReset.Clear();
            confirmpasswordReset.Clear();
            QuestionDisplay.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = usernameReset.Text.Trim();
            string answer = answerReset.Text.Trim();
            string newPassword = passwordReset.Text;
            string confirmPassword = confirmpasswordReset.Text;

            // Validate all inputs
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter a username.");
                return;
            }

            if (string.IsNullOrWhiteSpace(answer))
            {
                MessageBox.Show("Please enter your security answer.");
                return;
            }

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Please enter a new password.");
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            if (newPassword.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.");
                return;
            }

            DbHelper db = new DbHelper();
            bool success = db.ResetPassword(username, answer, newPassword);

            if (success)
            {
                MessageBox.Show("Password has been reset successfully. You can now log in.");
                this.Hide();
                login login = new login();
                login.Show();
            }
            else
            {
                MessageBox.Show("Incorrect answer or failed to reset password.");
            }
        }

        private void passwordReset_TextChanged(object sender, EventArgs e)
        {
            // You can add password strength validation here if needed
        }
    }
}
