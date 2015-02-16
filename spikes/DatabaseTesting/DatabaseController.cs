using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace DatabaseTesting
{
    class DatabaseController
    {
        private SQLiteConnection dbConnection;

        public DatabaseController()
        {
            dbConnection = new SQLiteConnection("Data Source=test.db;Version=3;");
        }

        public void ConnectToDatabase()
        {
            dbConnection.Open();
        }

        public void CloseConnectionToDatabase()
        {
            dbConnection.Close();
        }

        public void AddPersonToDatabase(Person p)
        {
            string sql = "INSERT INTO Person(FirstName, LastName, Password) VALUES('" + p.FirstName + "', '" + p.LastName + "', '" + p.Password + "')";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        public void PrintPersonTable()
        {
            string sql = "SELECT * FROM Person";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
                    Console.WriteLine("ID: " + reader["ID"] + "\tName: " + reader["FirstName"] + " " + reader["LastName"]);
        }

        public void DeletePersonFromDatabase(Person p)
        {
            string sql = "DELETE FROM Person WHERE FirstName = '" + p.FirstName + "' AND LastName = '" + p.LastName + "'";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
    }
}