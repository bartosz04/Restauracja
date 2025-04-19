using System;
using System.Data.SQLite;
using System.IO;

class Program
{
    static void Main()
    {

        string databaseFilePath = "restauracja_db.sqlite";


        if (!File.Exists(databaseFilePath))
        {

            SQLiteConnection.CreateFile(databaseFilePath);
            Console.WriteLine("Database file created.");
        }


        string connectionString = $"Data Source={databaseFilePath};Version=3;";


        using (SQLiteConnection conn = new SQLiteConnection(connectionString))
        {
            try
            {

                conn.Open();
                Console.WriteLine("Connected to the SQLite database successfully!");





                string selectQuery = "SELECT * FROM tables";
                using (SQLiteCommand cmd = new SQLiteCommand(selectQuery, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            int tableNumber = reader.GetInt32(1);
                            int seats = reader.GetInt32(2);
                            string status = reader.GetString(3);
                            string handler = reader.IsDBNull(4) ? null : reader.GetString(4);

                            Console.WriteLine($"ID: {id}, Table Number: {tableNumber}, Seats: {seats}, Status: {status}, Handler: {handler}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}