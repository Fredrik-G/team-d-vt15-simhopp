using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SQLite;
using System.Globalization;
using System.Reflection;
using Simhopp;

namespace Simhopp.Model
{
    public class DatabaseController
    {
        private SQLiteConnection dbConnection;

        #region Constructors
        /// <summary>
        /// Default Constructor. Makes the Connection file and gets the path to where the database is.
        /// </summary>
        public DatabaseController()
        {
            try
            {
                dbConnection = new SQLiteConnection("Data Source=C:/Users/Anders/Database/simhopp.db; Version=3; FailIfMissing=True");
            }

            catch (SQLiteException sqliteEx)
            {
                MsgBox.CreateErrorBox("Could not connect to the database.\n" + sqliteEx.GetType() + "\n" + sqliteEx, MethodBase.GetCurrentMethod().Name);
                dbConnection = null;
            }

            catch (Exception e)
            {
                MsgBox.CreateErrorBox("Could not connect to the database.\n" + e.GetType() + "\n" + e, MethodBase.GetCurrentMethod().Name);
                dbConnection = null;
            }

        }

        /// <summary>
        /// Constructor that creates a connection to a a database with a certain path.
        /// </summary>
        /// <param name="path">Database path.</param>
        public DatabaseController(string path)
        {
            try
            {
                dbConnection = new SQLiteConnection("Data Source='" + path + "'; Version=3; FailIfMissing=True");
            }

            catch (SQLiteException sqliteEx)
            {
                MsgBox.CreateErrorBox("Could not connect to the database.\n" + sqliteEx.GetType() + "\n" + sqliteEx, MethodBase.GetCurrentMethod().Name);
                dbConnection = null;
            }

            catch (Exception e)
            {
                MsgBox.CreateErrorBox("Could not connect to the database.\n" + e.GetType() + "\n" + e, MethodBase.GetCurrentMethod().Name);
                dbConnection = null;
            }
        }
        #endregion

        #region Open/Close database connection
        /// <summary>
        /// Opens the connection to the database.
        /// </summary>
        public void ConnectToDatabase() 
        {
            try
            {
                dbConnection.Open();
            }

            catch (SQLiteException sqliteEx)
            {
                MsgBox.CreateErrorBox("Could not connect to the database.\n" + sqliteEx.GetType() + "\n" + sqliteEx, MethodBase.GetCurrentMethod().Name);
                dbConnection = null;
            }

            catch (Exception e)
            {
                MsgBox.CreateErrorBox("Could not connect to the database.\n" + e.GetType() + "\n" + e, MethodBase.GetCurrentMethod().Name);
                dbConnection = null;
            }
        }
        

        /// <summary>
        /// Closes the connection to the database.
        /// </summary>
        public void CloseConnectionToDatabase() 
        {
            if (dbConnection == null)
            {
                MsgBox.CreateErrorBox("The connection to the database has not been initialized.", MethodBase.GetCurrentMethod().Name);
            }
            else
            {
                try
                {
                    dbConnection.Close();
                }

                catch (SQLiteException sqliteEx)
                {
                    MsgBox.CreateErrorBox("Could not close connection to the database.\n" + sqliteEx.GetType() + "\n" + sqliteEx, MethodBase.GetCurrentMethod().Name);
                    dbConnection = null;
                }

                catch (Exception e)
                {
                    MsgBox.CreateErrorBox("Could not close connection to the database.\n" + e.GetType() + "\n" + e, MethodBase.GetCurrentMethod().Name);
                    dbConnection = null;
                }
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Returns true if the database table is empty, else false.
        /// </summary>
        /// <param name="tableName">Table to be searched.</param>
        /// <returns></returns>
        public bool TableIsEmpty(string tableName) //Fixa till denna. vad ska den returnera om ett exception händer. Fråga Kjell!!
        {
            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
            }
            else
            {
                try
                {
                    //Checks if the table exists in the database. 
                    string sql = "SELECT count(*) FROM sqlite_master WHERE type='table' AND name='" + tableName + "'";
                    SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                    var doesTableExist = Convert.ToInt32(command.ExecuteScalar());

                    //If table exists, check if it is empty or not. 
                    if (doesTableExist == 1)
                    {
                        sql = "SELECT COUNT(*) FROM " + tableName + "";
                        command = new SQLiteCommand(sql, dbConnection);
                        var numberOfEntries = Convert.ToInt32(command.ExecuteScalar());
                        return numberOfEntries == 0;
                    }
                    else
                    {
                        MsgBox.CreateErrorBox(tableName + "does not exist in the database.", MethodBase.GetCurrentMethod().Name);
                    }
                }
                catch (SQLiteException sqliteEx)
                {
                    MsgBox.CreateErrorBox("Could not find out if " + tableName + " is empty or not.\n" + sqliteEx.GetType() + "\n" + sqliteEx, MethodBase.GetCurrentMethod().Name);
                }

                catch (FormatException formatEx)
                {
                    MsgBox.CreateErrorBox("Could not find out if " + tableName + " is empty or not.\n" + formatEx.GetType() + "\n" + formatEx, MethodBase.GetCurrentMethod().Name);
                }

                catch (InvalidCastException invalidCastEx)
                {
                    MsgBox.CreateErrorBox("Could not find out if " + tableName + " is empty or not.\n" + invalidCastEx.GetType() + "\n" + invalidCastEx, MethodBase.GetCurrentMethod().Name);
                }

                catch (OverflowException overflowEx)
                {
                    MsgBox.CreateErrorBox("Could not find out if " + tableName + " is empty or not.\n" + overflowEx.GetType() + "\n" + overflowEx, MethodBase.GetCurrentMethod().Name);
                }

                catch (Exception e)
                {
                    MsgBox.CreateErrorBox("Could not find out if " + tableName + " is empty or not.\n" + e.GetType() + "\n" + e, MethodBase.GetCurrentMethod().Name);
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Clears a table from the database. Mainly for the test class to use.  
        /// </summary>
        /// <param name="tableName">Table to be cleared.</param>
        public void ClearDatabase(string tableName)
        {
                    if (dbConnection == null)
                    {
                        NoConnectionErrorMessage();
                    }
                    else
                    {
                        try
                        {
                            string sql = "DELETE FROM " + tableName + " WHERE ID != 'null'";
                            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                            command.ExecuteNonQuery();
                        }

                        catch (SQLiteException sqliteEx)
                        {
                            MsgBox.CreateErrorBox("Table " + tableName + " could not be cleared.\n" + sqliteEx.GetType() + "\n" + sqliteEx, MethodBase.GetCurrentMethod().Name);
                            dbConnection = null;
                        }

                        catch (Exception e)
                        {
                            MsgBox.CreateErrorBox("Table " + tableName + " could not be cleared.\n" + e.GetType() + "\n" + e, MethodBase.GetCurrentMethod().Name);
                            dbConnection = null;
                        }

                    }
        }

        public void NoConnectionErrorMessage()
        {
            MsgBox.CreateErrorBox("Connection to a database is missing.", MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// Returns the id of the last entry put into the database.
        /// </summary>
        /// <returns>Last input id.</returns>
        private int GetLastId()
        {
            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
                throw new SQLiteException("No connection is initialized.");
            }
            try
            {
                string sql = "SELECT last_insert_rowid()";
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                int contestId = Convert.ToInt32(command.ExecuteScalar());
                return contestId;
            }

            catch (SQLiteException sqliteEx)
            {
                MsgBox.CreateErrorBox("Could not add following Judge to database: \n" + sqliteEx, MethodBase.GetCurrentMethod().Name);
                throw new SQLiteException("Could not get last insert row id." + sqliteEx);
            }

            catch (Exception e)
            {
                MsgBox.CreateErrorBox("Could not add following Judge to database: \n" + e, MethodBase.GetCurrentMethod().Name);
                throw new Exception("Could not get last insert row id." + e);
            }
        }

        #endregion

        #region Diver Methods
        /// <summary>
        /// Takes a diver objekt and adds that Diver to the database table Diver. 
        /// </summary>
        /// <param name="d">Diver objekt.</param>
        public void AddDiverToDatabase(Diver d)
        {
            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
                return;
            }
            try
            {
                if (d.Id == -1)
                {
                    string sql = "INSERT INTO Diver(Name,SSN,Nationality) VALUES('" + d.Name + "', '" + d.SSN + "','" + d.Nationality + "')";
                    SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                    command.ExecuteNonQuery();
                }
            }

            catch (SQLiteException sqliteEx)
            {
                MsgBox.CreateErrorBox("Could not add the following Diver to database: \n" + d.Name + ", " + d.Nationality + ", " + d.SSN + "\nExeption: " + sqliteEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (Exception e)
            {
                MsgBox.CreateErrorBox("Could not add the following Diver to database: \n" + d.Name + ", " + d.Nationality + ", " + d.SSN + "\nExeption: " + e, MethodBase.GetCurrentMethod().Name);
            }
        }

        /// <summary>
        /// Removes a row (diver) based on its social security number in the Diver table.
        /// </summary>
        /// <param name="d">Diver object.</param>
        public void RemoveDiverFromTable(Diver d)
        {
            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
            }
            else
            {
                try
                {
                    string sql = "DELETE FROM Diver where SSN ='" + d.SSN + "'";
                    SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                    command.ExecuteNonQuery();
                }

                catch (SQLiteException sqliteEx)
                {
                    MsgBox.CreateErrorBox("Could not delete the following diver from database: \n" + d.Name + ", " + d.Nationality + ", " + d.SSN + "\nExeption: " + sqliteEx, MethodBase.GetCurrentMethod().Name);
                }

                catch (Exception e)
                {
                    MsgBox.CreateErrorBox("Could not delete the following diver from database: \n" + d.Name + ", " + d.Nationality + ", " + d.SSN + "\nExeption: " + e, MethodBase.GetCurrentMethod().Name);
                }
                
            }
        }

        /// <summary>
        /// Console function.
        /// Prints all the rows in the Diver table in the console.
        /// </summary>
        public void PrintDiverTableInConsole()
        {
            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
            }
            else
            {
                try
                {
                    string sql = "SELECT * FROM Diver";
                    SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("{0,-8}{1,-32}{2,-15}{3,-16}", ("ID: " + reader["ID"]),
                            ("Name: " + reader["Name"]), ("NAT: " + reader["Nationality"]), ("SSN: " + reader["SSN"]));
                    }
                }

                catch (SQLiteException sqliteEx)
                {
                    Console.WriteLine("Could not print the Diver table.\n" + sqliteEx);
                }

                catch (Exception e)
                {
                    Console.WriteLine("Could not print the Diver table.\n" + e);
                }
            }
        }

        /// <summary>
        /// Update a diver row in the database.
        /// </summary>
        /// <param name="d">Diver object.</param>
        public void UpdateDiver(Diver d)
        {
            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
            }
            else
            {
                try
                {
                    string sql = "UPDATE Diver SET Name = '" + d.Name + "', SSN = '" + d.SSN + "', Nationality = '" + d.Nationality + "' WHERE ID = '" + d.Id + "'";
                    SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                    command.ExecuteNonQuery();
                }

                catch (SQLiteException sqliteEx)
                {
                    MsgBox.CreateErrorBox("Could not update the following Diver in database: \n" + d.Name + ", " + d.Nationality + ", " + d.SSN + "\nExeption: " + sqliteEx, MethodBase.GetCurrentMethod().Name);
                }

                catch (Exception e)
                {
                    MsgBox.CreateErrorBox("Could not update the following Diver in database: \n" + d.Name + ", " + d.Nationality + ", " + d.SSN + "\nExeption: " + e, MethodBase.GetCurrentMethod().Name);
                }

            }
        }

        /// <summary>
        /// Gets the divers from datbase, puts them in a lisa and returns it.
        /// </summary>
        /// <returns>List of Judge objects.</returns>
        public List<Diver> GetDivers()
        {
            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
            }
            else
            {
                try
                {
                    string sql = "SELECT * FROM Diver";
                    SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    List<Diver> dl = new List<Diver>();
                    while (reader.Read())
                    {
                        Diver d = new Diver(Convert.ToInt32(reader["ID"]), Convert.ToString(reader["Name"]), Convert.ToString(reader["Nationality"]), Convert.ToString(reader["SSN"]));
                        dl.Add(d);
                    }
                    return dl;
                }

                catch (SQLiteException sqliteEx)
                {
                    MsgBox.CreateErrorBox("Could not get Divers from database.\n" + sqliteEx, MethodBase.GetCurrentMethod().Name);
                }

                catch (FormatException formatEx)
                {
                    MsgBox.CreateErrorBox("Could not get Divers from database.\n" + formatEx.GetType() + "\n" + formatEx, MethodBase.GetCurrentMethod().Name);
                }

                catch (InvalidCastException invalidCastEx)
                {
                    MsgBox.CreateErrorBox("Could not get Divers from database.\n" + invalidCastEx.GetType() + "\n" + invalidCastEx, MethodBase.GetCurrentMethod().Name);
                }

                catch (OverflowException overflowEx)
                {
                    MsgBox.CreateErrorBox("Could not get Divers from database.\n" + overflowEx.GetType() + "\n" + overflowEx, MethodBase.GetCurrentMethod().Name);
                }

                catch (Exception e)
                {
                    MsgBox.CreateErrorBox("Could not get Divers from database.\n" + e, MethodBase.GetCurrentMethod().Name);
                }
            }
            return null;
        }
        #endregion

        #region Judge Methods
        /// <summary>
        /// Takes a judge objekt and adds that judge to the database table Judge. 
        /// </summary>
        /// <param name="j"></param>
        public void AddJudgeToDatabase(Judge j)
        {
            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
                return;
            }
            try
            {
                if (j.Id == -1)
                {
                    string sql = "INSERT INTO Judge(Name,SSN,Nationality) VALUES('" + j.Name + "', '" + j.SSN + "','" + j.Nationality + "')";
                    SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                    command.ExecuteNonQuery();
                }
            }

            catch (SQLiteException sqliteEx)
            {
                MsgBox.CreateErrorBox("Could not add following Judge to database: \n" + j.Name + ", " + j.Nationality + ", " + j.SSN + "\nExeption: " + sqliteEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (Exception e)
            {
                MsgBox.CreateErrorBox("Could not add following Judge to database: \n" + j.Name + ", " + j.Nationality + ", " + j.SSN + "\nExeption: " + e, MethodBase.GetCurrentMethod().Name);
            }
        }

        /// <summary>
        /// Removes a row (judge) based on its social security number in the Judge table.
        /// </summary>
        /// <param name="j">Judge object.</param>
        public void RemoveJudgeFromTable(Judge j)
        {
            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
                return;
            }
            try
            {
                string sql = "DELETE FROM Judge where SSN ='" + j.SSN + "'";
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                command.ExecuteNonQuery();
            }

            catch (SQLiteException sqliteEx)
            {
                MsgBox.CreateErrorBox("Could not delete the following Judge from database: \n" + j.Name + ", " + j.Nationality + ", " + j.SSN + "\nExeption: " + sqliteEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (Exception e)
            {
                MsgBox.CreateErrorBox("Could not delete the following Judge from database: \n" + j.Name + ", " + j.Nationality + ", " + j.SSN + "\nExeption: " + e, MethodBase.GetCurrentMethod().Name);
            }
        }

        /// <summary>
        /// Prints all the rows in the Judge table in the console.
        /// </summary>
        public void PrintJudgeTable()
        {
            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
            }
            else
            {
                try
                {
                    string sql = "SELECT * FROM Judge";
                    SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("{0,-8}{1,-32}{2,-15}{3,-16}", ("ID: " + reader["ID"]), ("Name: " + reader["Name"]), ("NAT: " + reader["Nationality"]), ("SSN: " + reader["SSN"]));
                    }
                }

                catch (SQLiteException sqliteEx)
                {
                    Console.WriteLine("Could not print the Judge table.\n" + sqliteEx, MethodBase.GetCurrentMethod().Name);
                }

                catch (Exception e)
                {
                    Console.WriteLine("Could not print the Judge table.\n" + e, MethodBase.GetCurrentMethod().Name);
                }
            }
        }

        /// <summary>
        /// Updates a Judge row in the database.
        /// </summary>
        /// <param name="j"></param>
        public void UpdateJudge(Judge j)
        {
            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
            }
            else
            {
                try
                {
                    string sql = "UPDATE Judge SET Name = '" + j.Name + "', SSN = '" + j.SSN + "', Nationality = '" + j.Nationality + "' WHERE ID = '" + j.Id + "'";
                    SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                    command.ExecuteNonQuery();
                }

                catch (SQLiteException sqliteEx)
                {
                    MsgBox.CreateErrorBox("Could not update the following Judge in database: \n" + j.Name + ", " + j.Nationality + ", " + j.SSN + "\nExeption: " + sqliteEx, MethodBase.GetCurrentMethod().Name);
                }

                catch (Exception e)
                {
                    MsgBox.CreateErrorBox("Could not update the following Judge in database: \n" + j.Name + ", " + j.Nationality + ", " + j.SSN + "\nExeption: " + e, MethodBase.GetCurrentMethod().Name);
                }

            }
        }

        /// <summary>
        /// Gets the judges from datbase, puts them in a lisa and returns it.
        /// </summary>
        /// <returns>List of Judge objects.</returns>
        public List<Judge> GetJudges()
        {
            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
            }
            else
            {
                try
                {
                    string sql = "SELECT * FROM Judge";
                    SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    List<Judge> jl = new List<Judge>();
                    while (reader.Read())
                    {
                        Judge j = new Judge(Convert.ToInt32(reader["ID"]), Convert.ToString(reader["Name"]), Convert.ToString(reader["Nationality"]), Convert.ToString(reader["SSN"]));
                        jl.Add(j);
                    }
                    return jl;
                }

                catch (SQLiteException sqliteEx)
                {
                    MsgBox.CreateErrorBox("Could not get Judges from database.\n" + sqliteEx, MethodBase.GetCurrentMethod().Name);
                }

                catch (FormatException formatEx)
                {
                    MsgBox.CreateErrorBox("Could not get Judges from database.\n" + formatEx.GetType() + "\n" + formatEx, MethodBase.GetCurrentMethod().Name);
                }

                catch (InvalidCastException invalidCastEx)
                {
                    MsgBox.CreateErrorBox("Could not get Judges from database.\n" + invalidCastEx.GetType() + "\n" + invalidCastEx, MethodBase.GetCurrentMethod().Name);
                }

                catch (OverflowException overflowEx)
                {
                    MsgBox.CreateErrorBox("Could not get Judges from database.\n" + overflowEx.GetType() + "\n" + overflowEx, MethodBase.GetCurrentMethod().Name);
                }

                catch (Exception e)
                {
                    MsgBox.CreateErrorBox("Could not get Judges from database.\n" + e, MethodBase.GetCurrentMethod().Name);
                }
            }
            return null;
        }
        #endregion

        #region Contest Methods
        /// <summary>
        /// Takes a contest objekt and adds that contest to the database table Contest.
        /// Only adds the contest objekt if the id is not set wich means the contest is 
        /// not already stored in the database.
        /// </summary>
        /// <param name="c">Contest object.</param>
        public void AddContestToDatabase(Contest c)
        {
            if (c.Id == -1)
            {
                if (dbConnection == null)
                {
                    NoConnectionErrorMessage();
                    return;
                }
                try
                {
                    //Add the contest info to contest database.
                    string sql = "INSERT INTO Contest(Place, Name, StartDate, EndDate) VALUES('" + c.Place + "', '" + c.Name + "','" + c.StartDate + "','" + c.EndDate + "')";
                    SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                    command.ExecuteNonQuery();

                    int lastInsertedContestId = GetLastId();

                    List<Judge> judgeList = c.GetJudgesList();

                    //Add all new judges to the database and update their id.
                    foreach (var judges in c.GetJudgesList())
                    {
                        if (judges.Id == -1)
                        {
                            AddJudgeToDatabase(judges);
                            judges.Id = GetLastId();
                        }
                    }

                    foreach (var participant in c.GetParticipants())
                    {
                        AddJumpResultToDatabase(participant, lastInsertedContestId);
                    }
                }

                catch (SQLiteException sqliteEx)
                {
                    MsgBox.CreateErrorBox(
                        "Could not add the following Contest to database: \n" + c.Place + "', '" + c.Name + "','" +
                        c.StartDate + "','" + c.EndDate + "\nExeption: " + sqliteEx,
                        MethodBase.GetCurrentMethod().Name);
                }

                catch (Exception e)
                {
                    MsgBox.CreateErrorBox(
                        "Could not add the following Contest to database: \n" + c.Place + "', '" + c.Name + "','" +
                        c.StartDate + "','" + c.EndDate + "\nExeption: " + e, MethodBase.GetCurrentMethod().Name);
                }
            }
        }

        
        /// <summary>
        /// Removes a row (contest) based on its ID.
        /// </summary>
        /// <param name="c">Contest object.</param>
        public void RemoveContestFromTable(Contest c) //Lägg till att alla klasser som har en tabell i databasen har ett id. Måste finnas för att följande ska kunna användas. 
        {
            /*string sql = "DELETE FROM Contest where ??? ='" + c.??? + "'";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
            */
        }

        public List<Contest> GetContests()
        {
            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
            }
            else
            {
                try
                {
                    string sql = "SELECT * FROM Contest";
                    SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    List<Contest> cl = new List<Contest>();
                    while (reader.Read())
                    {
                        Contest c = new Contest(Convert.ToInt32(reader["ID"]), Convert.ToString(reader["Place"]), Convert.ToString(reader["Name"]), Convert.ToString(reader["StartDate"]), Convert.ToString(reader["EndDate"]));
                        ///för varje contest med id == x ska det finnas ett antal hopp osv. hämta den listan från jump.
                        cl.Add(c);
                    }
                    return cl;
                }

                catch (SQLiteException sqliteEx)
                {
                    MsgBox.CreateErrorBox("Could not get Contests from database.\n" + sqliteEx, MethodBase.GetCurrentMethod().Name);
                }

                catch (FormatException formatEx)
                {
                    MsgBox.CreateErrorBox("Could not get Contests from database.\n" + formatEx.GetType() + "\n" + formatEx, MethodBase.GetCurrentMethod().Name);
                }

                catch (InvalidCastException invalidCastEx)
                {
                    MsgBox.CreateErrorBox("Could not get Contests from database.\n" + invalidCastEx.GetType() + "\n" + invalidCastEx, MethodBase.GetCurrentMethod().Name);
                }

                catch (OverflowException overflowEx)
                {
                    MsgBox.CreateErrorBox("Could not get Contests from database.\n" + overflowEx.GetType() + "\n" + overflowEx, MethodBase.GetCurrentMethod().Name);
                }

                catch (Exception e)
                {
                    MsgBox.CreateErrorBox("Could not get Contests from database.\n" + e, MethodBase.GetCurrentMethod().Name);
                }
            }
            return null;
        } //Inte färdig. Andra funktioner som måste göras först för att få den att fungera. 
        #endregion

        #region Trick Methods
        /// <summary>
        /// Adds a Trick objekt to the database.
        /// </summary>
        /// <param name="t"></param>
        public void AddTrickToDatabase(Trick t)
        {
            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
                return;
            }
            try
            {
                string sql = "INSERT INTO Trick(Name,Difficulty) VALUES('" + t.Name + "', '" + t.Difficulty.ToString(CultureInfo.InvariantCulture) + "')";
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                command.ExecuteNonQuery();
            }

            catch (SQLiteException sqliteEx)
            {
                MsgBox.CreateErrorBox("Could not add the following Trick to database: \n" + t.Name + ", " + t.Difficulty + "\nExeption: " + sqliteEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (Exception e)
            {
                MsgBox.CreateErrorBox("Could not add the following Trick to database: \n" + t.Name + ", " + t.Difficulty + "\nExeption: " + e, MethodBase.GetCurrentMethod().Name);
            }
        }

        /// <summary>
        /// Adds trick to the database by name and difficulty by creating a 
        /// Trick object and sending it to the other AddTrickToDatabase(Trick t) function.
        /// </summary>
        /// <param name="trickName"></param>
        /// <param name="difficulty"></param>
        public void AddTrickToDatabase(string trickName, double difficulty)
        {
            Trick t = new Trick(trickName, difficulty);
            AddTrickToDatabase(t);
        }

        /// <summary>
        /// Returns a trick id from the database based on a trick name.
        /// </summary>
        /// <param name="trickName">Trick name</param>
        /// <returns>Trick ID number.</returns>
        public int GetTrickIdByName(string trickName)
        {
            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
            }
            else
            {
                try
                {
                    int id = -1;
                    string sql = "SELECT ID FROM Trick WHERE name = '" + trickName + "'";
                    SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader["ID"]);
                    }
                    return id;
                }

                catch (SQLiteException sqliteEx)
                {
                    MsgBox.CreateErrorBox("Could not get Trick ID from database.\n" + sqliteEx, MethodBase.GetCurrentMethod().Name);
                }

                catch (FormatException formatEx)
                {
                    MsgBox.CreateErrorBox("Could not get Trick ID from database.\n" + formatEx.GetType() + "\n" + formatEx, MethodBase.GetCurrentMethod().Name);
                }

                catch (InvalidCastException invalidCastEx)
                {
                    MsgBox.CreateErrorBox("Could not get Trick ID from database.\n" + invalidCastEx.GetType() + "\n" + invalidCastEx, MethodBase.GetCurrentMethod().Name);
                }

                catch (OverflowException overflowEx)
                {
                    MsgBox.CreateErrorBox("Could not get Trick ID from database.\n" + overflowEx.GetType() + "\n" + overflowEx, MethodBase.GetCurrentMethod().Name);
                }

                catch (Exception e)
                {
                    MsgBox.CreateErrorBox("Could not get Trick ID from database.\n" + e, MethodBase.GetCurrentMethod().Name);
                }
            }
            return -1;
        }

        #endregion

        #region JumpResults Methods

        public void AddJumpResultToDatabase(Participant participant, int contestId) ///Gör färdigt efter get trick id by name. Bättre att ta ett participantobjekt???
        {
            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
                return;
            }
            try
            {
                
                AddDiverToDatabase(participant.GetDiver());

                foreach (var jumpResult in participant.GetJumpResults())
                {
                    
                    //lägg till jump först sen evaluation.
                    //double[] judgePoints = participant.GetJudgePointsArray();
                    //foreach (var judgePoint in judgePoints)
                    {
                        
                    }
                }
            }

            catch (SQLiteException sqliteEx)
            {
                MsgBox.CreateErrorBox("Could not add following Judge to database: \n" + sqliteEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (Exception e)
            {
                MsgBox.CreateErrorBox("Could not add following Judge to database: \n" + e, MethodBase.GetCurrentMethod().Name);
            }
        }
       
        public List<JumpResult> GetJumpResults() //Gör så att denna funkar!!!
        {
            List<JumpResult> jr = new List<JumpResult>();
            return jr;
        }
        #endregion

        #region Jump
        /// <summary>
        /// Adds a jump to database.
        /// </summary>
        /// <param name="totalPoints">The jumps calculated points.</param>
        /// <param name="diverId"> the diver who made the jump.</param>
        /// <param name="contestId">The contest the jump belongs to.</param>
        /// <param name="trickId">The trick that was performed.</param>
        public void AddJumpToDatabase(double totalPoints, int diverId, int contestId, int trickId)
        {
            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
                return;
            }
            try
            {
                string sqlJump = "INSERT INTO Jump(TotalPoint, Diver, Contest, Trick) VALUES('" + totalPoints.ToString(CultureInfo.InvariantCulture) + "','" + diverId + "','" + contestId + "','" + trickId + "')";
                SQLiteCommand command = new SQLiteCommand(sqlJump, dbConnection);
                command.ExecuteNonQuery();
            }

            catch (SQLiteException sqliteEx)
            {
                MsgBox.CreateErrorBox("Could not add Jump to database: \n" + sqliteEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (Exception e)
            {
                MsgBox.CreateErrorBox("Could not add Jump to database: \n" + e, MethodBase.GetCurrentMethod().Name);
            }
        }
        #endregion

        #region Evaluation
        public void AddEvaluationToDatabase(int jumpId, int judgeId, double point)
        {
        if (dbConnection == null)
            {
                NoConnectionErrorMessage();
                return;
            }
            try
            {
                string sql = "INSERT INTO Evaluation(Jump, Judge, Point) VALUES('" + jumpId + "', '" + judgeId + "','" + point.ToString(CultureInfo.InvariantCulture) + "')";
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                command.ExecuteNonQuery();
            }

            catch (SQLiteException sqliteEx)
            {
                MsgBox.CreateErrorBox("Could not add evaluation database: \n" + sqliteEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (Exception e)
            {
                MsgBox.CreateErrorBox("Could not add evaluation to database: \n" + e, MethodBase.GetCurrentMethod().Name);
            }
            
        }
        #endregion

        #region Trick

        #endregion
    }
}