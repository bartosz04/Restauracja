using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Restauracja_Stoly
{
    public partial class Form1 : Form
    {
        private string databaseFilePath = "restauracja_db.sqlite";

        public Form1()
        {
            InitializeComponent();
            buttonSearch.Click += buttonSearch_Click; 
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string nameSearchTerm = textBoxName.Text; // Get the search term from the TextBox
            bool isReserved = checkBoxReserved.Checked; // Check if the checkbox is checked
            List<RestaurantTable> results = SearchTables(nameSearchTerm, isReserved); // Call the search method
            DisplayResults(results); // Display the results in the DataGridView
        }

        private List<RestaurantTable> SearchTables(string nameSearchTerm, bool isReserved)
        {
            List<RestaurantTable> tables = new List<RestaurantTable>();
            string connectionString = $"Data Source={databaseFilePath};Version=3;";

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string selectQuery = "SELECT * FROM tables WHERE handler LIKE @nameSearchTerm";

                    // Adjust the query based on the checkbox state
                    if (isReserved)
                    {
                        selectQuery += " AND status = 'reserved'"; // Search for reserved tables
                    }
                    else
                    {
                        selectQuery += " AND (status = 'available' OR status IS NULL)"; // Search for available tables or those with NULL status
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
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); // Display any errors
            }

            return tables;
        }

        private void DisplayResults(List<RestaurantTable> tables)
        {
            dataGridViewResults.DataSource = null; // Clear existing data
            dataGridViewResults.DataSource = tables; // Bind the new data
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Label clicked!"); // Example action
        }

        private void dataGridViewResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
}