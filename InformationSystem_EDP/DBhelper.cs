using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace InformationSystem_EDP
{
    public class DbHelper
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public User SearchUserByUsername(string username)
        {
            User user = null;
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var query = "SELECT user_id, username, password, email, role FROM users WHERE username = @Username";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User()
                            {
                                UserId = reader.GetInt32("user_id"),
                                Username = reader["username"].ToString(),
                                Password = reader["password"].ToString(),
                                Email = reader["email"].ToString(),
                                Role = reader["role"].ToString()
                            };
                        }
                    }
                }
            }
            return user;
        }

        public class User
        {
            public int UserId { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public string Role { get; set; }
        }

        public bool InsertUser(string username, string password, string email,
                       string role, string securityQuestion, string securityAnswer)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("register_user", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_username", username);
                    cmd.Parameters.AddWithValue("@p_email", email);
                    cmd.Parameters.AddWithValue("@p_password", password);
                    cmd.Parameters.AddWithValue("@p_role", role);
                    cmd.Parameters.AddWithValue("@p_sec_question", securityQuestion);
                    cmd.Parameters.AddWithValue("@p_sec_answer", securityAnswer);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public string ValidateLogin(string username, string password)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("validate_login", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_username", username);
                    cmd.Parameters.AddWithValue("@p_password", password);

                    var roleParam = new MySqlParameter("@p_role", MySqlDbType.VarChar, 20);
                    roleParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(roleParam);

                    cmd.ExecuteNonQuery();

                    var role = roleParam.Value?.ToString();
                    return string.IsNullOrEmpty(role) ? null : role;
                }
            }
        }

        public bool ResetPassword(string username, string answer, string newPassword)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("update_password_by_username", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@p_username", username);
                    cmd.Parameters.AddWithValue("@p_answer", answer);
                    cmd.Parameters.AddWithValue("@p_new_password", newPassword);

                    var successParam = new MySqlParameter("@p_success", MySqlDbType.Bit);
                    successParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(successParam);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return Convert.ToBoolean(successParam.Value);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public string GetSecurityQuestion(string username)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SELECT security_question FROM users WHERE username = @username", conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    var result = cmd.ExecuteScalar();
                    return result?.ToString();
                }
            }
        }

        public void InsertUserActivityLog(int employeeID, string action, string details)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("INSERT INTO Logs (EmployeeID, Action, ActionDate, Details) VALUES (@EmployeeID, @Action, NOW(), @Details)", conn))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                    cmd.Parameters.AddWithValue("@Action", action);
                    cmd.Parameters.AddWithValue("@Details", details);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
