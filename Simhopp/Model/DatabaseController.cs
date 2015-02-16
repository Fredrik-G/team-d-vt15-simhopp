using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SimhoppGUI
{
    public class DatabaseController
    {
        private SQLiteConnection dbConnection;
        
        public DatabaseController()
        {
            dbConnection = new SQLiteConnection("Data Source=C:/Users/Anders/Database/simhopp.db;Version=3;");
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
            string sql = "INSERT INTO Diver(Name,SSN,Nationality) VALUES('" +p.Name + "', '" +p.SSN + "','" + p.Nationality + "')";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }
        public void AddContest(Contest c) 
        {
            string sql = "INSERT INTO Contest(Place, Name, StartDate, EndDate) VALUES('" + c.Place + "', '" + c.Name + "','" + c.StartDate + "')";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        public void AddJudgeToDatabase(Judge j) 
        {
            string sql = "INSERT INTO Judge(Name,SSN,Nationality) VALUES('" + j.Name + "', '" + j.SSN + "','" + j.Nationality + "')";
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
                Console.WriteLine("{0,-8}{1,-32}{2,-15}{3,-16}", ("ID: " + reader["ID"]), ("Name: " + reader["Name"]), ("NAT: " + reader["Nationality"]), ("SSN: " + reader["SSN"]));
            }
        }

        public void PrintJudgeTable() 
        {
            string sql = "SELECT * FROM Judge";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0,-8}{1,-32}{2,-15}{3,-16}", ("ID: " + reader["ID"]), ("Name: " + reader["Name"]), ("NAT: " + reader["Nationality"]), ("SSN: " + reader["SSN"]));
            }
        
        }

        public void RemoveDiverFromTable(Diver d) 
        {
            string sql = "DELETE FROM Diver where SSN ='"+d.SSN+"'";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        public void RemoveJudgeFromTable(Judge j)
        {
            string sql = "DELETE FROM Judge where SSN ='"+j.SSN+"'";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

    }
}
