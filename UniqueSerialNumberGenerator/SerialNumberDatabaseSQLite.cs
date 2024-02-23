using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueSerialNumberGenerator
{
    public class SerialNumberDatabaseSQLite
    {
        private readonly string connectionString = "Data Source=serialNumbers.db;Version=3;";

        public bool InitializeDatabase()
        {
            using SQLiteConnection connection = new(connectionString);

            string sql = @"CREATE TABLE IF NOT EXISTS SerialNumbers (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                SerialNumber TEXT UNIQUE
                            );";

            using SQLiteCommand command = new(sql, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool TryInsertSerialNumber(string serialNumber)
        {
            using SQLiteConnection connection = new(connectionString);
            string sql = "INSERT INTO SerialNumbers (SerialNumber) VALUES (@SerialNumber)";
            using SQLiteCommand command = new(sql, connection);
            command.Parameters.AddWithValue("@SerialNumber", serialNumber);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
