using System;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Restauracja_app
{
    
    public partial class RegisterForm : Form
    {
        
        private readonly RegistrationValidator _validator;
        private string databaseFilePath = "restauracja_db.sqlite";

        public RegisterForm()
        {
            InitializeComponent();
            _validator = new RegistrationValidator();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            var registrationData = new RegistrationData(
                txtUsername.Text,
                txtPassword.Text,  
                txtConfirmPassword.Text
            );

            if (!_validator.Validate(registrationData, out string errorMessage))
            {
                MessageBox.Show(errorMessage, "Błąd rejestracji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearPasswords();
                txtPassword.Focus();  
                return;
            }
            RegisterUser(registrationData.Username, registrationData.Password);
            
            MessageBox.Show("Użytkownik został zarejestrowany.", "Rejestracja zakończona", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearAll();
            txtUsername.Focus();

            
        }

        private void RegisterUser(string username, string password)
        {
            string passwordHash = PasswordScriptR.HashPassword(password);
            try
            {
                string connectionString = $"Data Source={databaseFilePath};Version=3;";
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    
                    string InsertQuery = "INSERT INTO Users (Username, PasswordHash) VALUES (@username, @passwordHash)";
                    using (SQLiteCommand cmd = new SQLiteCommand(InsertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@passwordHash", passwordHash);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\nStack Trace: {ex.StackTrace}", 
                    "Błąd rejestracji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearPasswords();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearAll();
            txtUsername.Focus();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ClearAll()
        {
            txtUsername.Clear();
            ClearPasswords();
        }

        private void ClearPasswords()
        {
            txtPassword.Clear();
            txtConfirmPassword.Clear();
        }
    }

    public record RegistrationData(string Username, string Password, string ConfirmPassword);

    public class RegistrationValidator
    {
        public bool Validate(RegistrationData data, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(data.Username) || string.IsNullOrWhiteSpace(data.Password) ||
                string.IsNullOrWhiteSpace(data.ConfirmPassword))
            {
                errorMessage = "Wszystkie pola są wymagane.";
                return false;
            }

            if (data.Password != data.ConfirmPassword)
            {
                errorMessage = "Hasła nie pasują do siebie.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }
    }
    public class PasswordScriptR
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

    
    }

}



