using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;

namespace Restauracja_app
{
    public partial class Form1 : Form
    {
        
        private string? userType;

        
        private string databaseFilePath = "restauracja_db.sqlite";

        public Form1(string? userType)
        {
            InitializeComponent();
            buttonSearch.Click += buttonSearch_Click;
            buttonChange.Click += buttonChange_Click; 
            buttonRegister.Click += buttonRegister_Click; 
            this.userType = userType;
        }
        
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (userType == "admin")
            {
                RegisterForm registerForm = new RegisterForm(); 
                registerForm.Show(); 
                this.Hide(); 
            }
            else
            {
                MessageBox.Show("Rejestracja użytkowników jest dostępna wyłącznie dla administratorów.",
                    "Odmowa dostępu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    


        
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string nameSearchTerm = textBoxName.Text; 
            bool isReserved = checkBoxReserved.Checked;
            bool isEmpty = checkBoxEmpty.Checked;
            List<RestaurantTable> results = SearchTables(nameSearchTerm, isReserved , isEmpty);
            DisplayResults(results);
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show(); 
            this.Hide(); 
        }
        
        



        private List<RestaurantTable> SearchTables(string nameSearchTerm, bool isReserved, bool isEmpty)
        {
            List<RestaurantTable> tables = new List<RestaurantTable>();
            string connectionString = $"Data Source={databaseFilePath};Version=3;";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string selectQuery = "SELECT * FROM tables WHERE handler LIKE @nameSearchTerm";
                    
                    
                    
                    if (isReserved && isEmpty)
                    {
                        MessageBox.Show("Proszę wybierz tylko jedną.");
                    }
                    else
                    {
                        if (isReserved)
                        {
                            selectQuery += " AND status = 'reserved'";
                        }
                        else if(isEmpty)
                        {
                            selectQuery += " AND status = 'available'";
                        }
                        else
                        {
                            selectQuery += " AND (status = 'available' OR status = 'reserved')";
                        } 
                        
                        using (SQLiteCommand cmd = new SQLiteCommand(selectQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@nameSearchTerm", "%" + nameSearchTerm + "%");
                            using (SQLiteDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    RestaurantTable table = new RestaurantTable
                                    {
                                        Id = reader.GetInt32(0),
                                        TableNumber = reader.GetInt32(1),
                                        Seats = reader.GetInt32(2),
                                        Status = reader.GetString(3),
                                        Handler = reader.GetString(4)
                                    };
                                    tables.Add(table);
                                }
                            }
                        }
                    }
                }
                        
                        
                    }
                    
                   

                    
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return tables;
        }

        private void DisplayResults(List<RestaurantTable> tables)
        {
            dataGridViewResults.DataSource = null;
            dataGridViewResults.DataSource = tables;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }


    }
}

    public class RestaurantTable
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public int Seats { get; set; }
        public string Status { get; set; }
        public string Handler { get; set; }
    }
