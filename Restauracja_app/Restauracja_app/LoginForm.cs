﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Security.Cryptography;

namespace Restauracja_app
{
    public partial class LoginForm : Form
    {
        private string databaseFilePath = "restauracja_db.sqlite";
        private TextBox txtusername;
        private TextBox txtpassword;
        private Button buttonLogin;
        private Button buttonClear;
        private Button buttonExit;
        private Label labelUsername;
        private Label labelPassword;
        private string userType;

        public string UserTypeValue
        {
            get { return userType; }
        }


        public LoginForm()
        {
            InitializeComponent();
            this.Text = "Panel logowania";
            this.Size = new Size(350, 220);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            LoginUser(); // Call the login method here
            UserType();
        }


        private void LoginUser()
        {
            string username = txtusername.Text;
            string password = txtpassword.Text;

            try
            {
                string connectionString = $"Data Source={databaseFilePath};Version=3;";
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string SelectQuery = "SELECT PasswordHash FROM Users WHERE Username = @username";
                    using (SQLiteCommand cmd = new SQLiteCommand(SelectQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        var storedHash = cmd.ExecuteScalar() as string;

                        if (storedHash == null)
                        {
                            MessageBox.Show("Invalid username or password.", "Login Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (PasswordScript.VerifyPassword(password, storedHash))
                        {
                            MessageBox.Show("Login successful!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            string SelectTypeQuery = "SELECT Type FROM Users WHERE Username = @username";
                            using (SQLiteCommand cmd2 = new SQLiteCommand(SelectTypeQuery, conn))
                            {
                                cmd2.Parameters.AddWithValue("@username", username);
                                userType = cmd2.ExecuteScalar() as string;

                                pulpit form1 = new pulpit(userType); 
                                form1.Show();

                            }



                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Login Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to log in. Please try again.",
                    "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void UserType()
        {
            string username = txtusername.Text;

            try
            {
                string connectionString = $"Data Source={databaseFilePath};Version=3;";
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();

                    string SelectTypeQuery = "SELECT Type FROM Users WHERE Username = @username";
                    using (SQLiteCommand cmd2 = new SQLiteCommand(SelectTypeQuery, conn))
                    {
                        cmd2.Parameters.AddWithValue("@username", username);
                        this.userType = cmd2.ExecuteScalar() as string;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while trying to log in. Please try again.",
                    "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

    public static class PasswordScript
    {

        private const int SaltSize = 16;
        private const int HashSize = 20;
        private const int Iterations = 10000;

        public static string HashPassword(string Password)
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            using (var pbkdf2 = new Rfc2898DeriveBytes(Password, salt, Iterations))
            {
                var hash = pbkdf2.GetBytes(HashSize);
                var hashBytes = new byte[SaltSize + HashSize];
                Array.Copy(salt, 0, hashBytes, 0, SaltSize);
                Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            // Extract salt
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            // Hash entered password with extracted salt
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            // Compare the results byte-by-byte
            for (int i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                    return false;
            }

            return true;
        }
    }
}