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

                
                string createTableQuery = @"CREATE TABLE IF NOT EXISTS tables (
                                            id INTEGER PRIMARY KEY AUTOINCREMENT, 
                                            table_number INTEGER NOT NULL, 
                                            seats INTEGER NOT NULL, 
                                            status TEXT NOT NULL)";
                using (SQLiteCommand cmd = new SQLiteCommand(createTableQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Table 'tables' created successfully!");
                }

               
                string insertDataQuery = @"INSERT INTO tables (table_number, seats, status) 
                                           VALUES (1, 4, 'available'), 
                                                  (2, 2, 'reserved'), 
                                                  (3, 4, 'available')";
                using (SQLiteCommand cmd = new SQLiteCommand(insertDataQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Sample data inserted successfully!");
                }

               
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

                         
                            Console.WriteLine($"ID: {id}, Table Number: {tableNumber}, Seats: {seats}, Status: {status}");
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
