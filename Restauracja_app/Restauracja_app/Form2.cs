using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Restauracja_app
{
    public partial class Form2 : Form
    {
        private string? userType;
        
        private string databaseFilePath = "restauracja_db.sqlite";

        public Form2()
        {
            InitializeComponent();
            changeButton2.Click += changeButton2_Click; 
            buttonChange.Click += buttonChange_Click; 
        }

        private void changeButton2_Click(object sender, EventArgs e)
        {
           
            int TtableNumber;

            // Try to parse the input from the tableNumber TextBox
            if (!int.TryParse(tableNumber.Text, out TtableNumber)) 
            {
                MessageBox.Show("Proszę wprowadzić prawidłowy numer tabeli.");
                return;
            }

            string handler = Handler.Text; 
            string status;

            if (radioStatus1.Checked) // If Reserved is selected
            {
                status = "reserved";
            }
            else if (radioStatus2.Checked) // If Available is selected
            {
                status = "available";
                handler = string.Empty; // Set handler to an empty string
            }
            else
            {
                MessageBox.Show("Proszę wybierz status.");
                return;
            }

            UpdateTableStatus(TtableNumber, handler, status);
        }

        private void UpdateTableStatus(int tableNumber, string handler, string status)
        {
            string connectionString = $"Data Source={databaseFilePath};Version=3;";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string updateQuery = "UPDATE tables SET handler = @handler, status = @status WHERE table_number = @tableNumber";

                    using (SQLiteCommand cmd = new SQLiteCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@handler", handler);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@tableNumber", tableNumber);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Status tabeli został pomyślnie zaktualizowany.");
                        }
                        else
                        {
                            MessageBox.Show("Nie znaleziono tabeli o podanym numerze.\r\n");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // Display any errors
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}