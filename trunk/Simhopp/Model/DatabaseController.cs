using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Simhopp.Model
{
    public class DatabaseController
    {
        private SQLiteConnection dbConnection;
        /// <summary>
        /// Default Constructor. Makes the Connection file and gets the path to where the database is.
        /// </summary>
        public DatabaseController()
        {
            dbConnection = new SQLiteConnection("Data Source=C:/Users/Anders/Database/simhopp.db;Version=3;");
        }

        /// <summary>
        /// Default Constructor. Makes the Connection file and gets the path as input to where the database is.
        /// </summary>
        /// <param name="path">Database path.</param>
        public DatabaseController(string path)
        {
            dbConnection = new SQLiteConnection("Data Source='" + path + "';Version=3;");
        }

        /// <summary>
        /// Opens the connection to the database.
        /// </summary>
        public void ConnectToDatabase() 
        {
            dbConnection.Open();
        }

        /// <summary>
        /// Closes the connection to the database.
        /// </summary>
        public void CloseConnectionToDatabase() 
        {
            dbConnection.Close();
        }

        /// <summary>
        /// Returns true if the database table is empty, else false.
        /// </summary>
        /// <param name="tableName">Table to be searched.</param>
        /// <returns></returns>
        public bool IsTableEmpty(string tableName)
        {
            string sql = "SELECT COUNT(*) FROM " + tableName + "";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            int numberOfEntries = Convert.ToInt32(command.ExecuteScalar());
            if (numberOfEntries == 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Clears a table from the database. Mainly for the test class to use.  
        /// </summary>
        /// <param name="tableName">Table to be cleared.</param>
        public void ClearDatabase(string tableName)
        {
            string sql = "DELETE FROM " + tableName + " WHERE ID != 'null'";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Takes a diver objekt and adds that Diver to the database table Diver. 
        /// </summary>
        /// <param name="d">Diver objekt.</param>
        public void AddDivertoDatabase(Diver d)
        {
            string sql = "INSERT INTO Diver(Name,SSN,Nationality) VALUES('" + d.Name + "', '" + d.SSN + "','" + d.Nationality + "')";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Takes a contest objekt and adds that contest to the database table Contest.
        /// </summary>
        /// <param name="c">Contest object.</param>
        public void AddContestToDatabase(Contest c) 
        {
            string sql = "INSERT INTO Contest(Place, Name, StartDate, EndDate) VALUES('" + c.Place + "', '" + c.Name + "','" + c.StartDate + "','" + c.EndDate + "')";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Takes a judge objekt and adds that judge to the database table Judge. 
        /// </summary>
        /// <param name="j"></param>
        public void AddJudgeToDatabase(Judge j) 
        {
            string sql = "INSERT INTO Judge(Name,SSN,Nationality) VALUES('" + j.Name + "', '" + j.SSN + "','" + j.Nationality + "')";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Prints all the rows in the Diver table in the console.
        /// </summary>
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

        /// <summary>
        /// Prints all the rows in the Judge table in the console.
        /// </summary>
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

        /// <summary>
        /// Removes a row (diver) based on its social security number in the Diver table.
        /// </summary>
        /// <param name="d">Diver object.</param>
        public void RemoveDiverFromTable(Diver d) 
        {
            string sql = "DELETE FROM Diver where SSN ='" + d.SSN + "'";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Removes a row (judge) based on its social security number in the Judge table.
        /// </summary>
        /// <param name="j">Judge object.</param>
        public void RemoveJudgeFromTable(Judge j)
        {
            string sql = "DELETE FROM Judge where SSN ='" + j.SSN + "'";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
        }

        //Lägg till att alla klasser som har en tabel i databasen har ett id. Måste finnas för att följande ska kunna användas. 
        /// <summary>
        /// Removes a row (contest) based on its ID.
        /// </summary>
        /// <param name="c">Contest object.</param>
        public void RemoveContestFromTable(Contest c)
        {
            /*string sql = "DELETE FROM Contest where SSN ='" + c.ID + "'";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
            */
        }
    }
}