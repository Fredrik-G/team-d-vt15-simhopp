using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Simhopp.Model
{
    class DatabaseController
    {
        private SQLiteConnection dbConnection;
        
        public DatabaseController()
        {
            dbConnection = new SQLiteConnection("Data Source=Files\\simhopp.db;Version=3;");
        }

        public void ConnectToDatabase() 
        {
            dbConnection.Open();
        }
        public void closeConnectionToDatabase() 
        {
            dbConnection.Close();
        }
        public void AddDivertoDatabase(Person p)
        {
            string sql = "SELECT INTO Person(Name,SSN,Nationality) VALUES('" +p.Name + "', '" +p.SSN + "','" + p.Nationality + "')";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        public void PrintDiverTable() 
        {
            string sql = "SELECT * FROM Diver";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read()) 
            {
                Console.WriteLine("ID: " + reader["ID"] + "\tName: " + reader["Name"] + "\tSSN: " + reader["SSN"] + "\tNationality: " + reader["Nationality"]);
            }
        
        }

    }
}
