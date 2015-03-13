using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace Simhopp.Model
{
    /// <summary>
    /// Controlls the connection to a database and handles SQL queries.
    /// There should not be any queries outside of this class.
    /// </summary>
    public class DatabaseController : IDisposable
    {
        #region Data


        private SQLiteConnection dbConnection;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

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
            #region Exceptions
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
            #endregion
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
            #region Exceptions
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
            #endregion
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
                log.Info("New database connection open.");
            }

            #region Exceptions
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
            #endregion
        }


        /// <summary>
        /// Closes the connection to the database.
        /// </summary>
        public void CloseConnectionToDatabase()
        {
            if (dbConnection == null)
            {
                MsgBox.CreateErrorBox("The connection to the database has not been initialized.", MethodBase.GetCurrentMethod().Name);
                return;
            }
            try
            {
                dbConnection.Close();
                log.Info("Database connection closed.");
            }
            #region Exceptions

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
            #endregion
        }

        #endregion

        #region Methods
        /// <summary>
        /// Returns true if the database table is empty, else false.
        /// </summary>
        /// <param name="tableName">Table to be searched.</param>
        /// <returns></returns>
        public bool TableIsEmpty(string tableName) //Fixa till denna. vad ska den returnera om ett exception händer. Fråga Kjell!!
            //denna funktion borde väl heta IsTableEmpty btw? boolvariabler/funktioner ska antyda yes/no/true/false enligt C# Code Style Guide - Scott Bellware
        {
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + " run on table " + tableName);

            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
                return false;
            }
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
                MsgBox.CreateErrorBox(tableName + "does not exist in the database.", MethodBase.GetCurrentMethod().Name);
            }
            #region Exceptions

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
            #endregion
            return false;
        }

        /// <summary>
        /// Clears a table from the database. Mainly for the test class to use.  
        /// </summary>
        /// <param name="tableName">Table to be cleared.</param>
        public void ClearDatabase(string tableName)
        {
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + " run on table " + tableName);

            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
                return;
            }
            try
            {
                string sql = "DELETE FROM " + tableName + " WHERE ID != 'null'";
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                command.ExecuteNonQuery();
            }
            #region Exceptions

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
            #endregion
        }

        /// <summary>
        /// Sends a error to the MsgBox function.
        /// </summary>
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
            #region Exceptions

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
            #endregion
        }

        #endregion

        #region Diver Methods
        /// <summary>
        /// Takes a diver objekt and adds that Diver to the database table Diver. 
        /// </summary>
        /// <param name="d">Diver objekt.</param>
        public void AddDiverToDatabase(Diver d)
        {
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + " run on SSN " + d.SSN);

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
            #region Exceptions

            catch (SQLiteException sqliteEx)
            {
                MsgBox.CreateErrorBox("Could not add the following Diver to database: \n" + d.Name + ", " + d.Nationality + ", " + d.SSN + "\nExeption: " + sqliteEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (Exception e)
            {
                MsgBox.CreateErrorBox("Could not add the following Diver to database: \n" + d.Name + ", " + d.Nationality + ", " + d.SSN + "\nExeption: " + e, MethodBase.GetCurrentMethod().Name);
            }
            #endregion
        }

        /// <summary>
        /// Removes a row (diver) based on its social security number in the Diver table.
        /// </summary>
        /// <param name="d">Diver object.</param>
        public void RemoveDiverFromTable(Diver d)
        {
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + " run on SSN " + d.SSN);

            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
                return;
            }
            try
            {
                string sql = "DELETE FROM Diver where SSN ='" + d.SSN + "'";
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                command.ExecuteNonQuery();
            }
            #region Exceptions

            catch (SQLiteException sqliteEx)
            {
                MsgBox.CreateErrorBox("Could not delete the following diver from database: \n" + d.Name + ", " + d.Nationality + ", " + d.SSN + "\nExeption: " + sqliteEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (Exception e)
            {
                MsgBox.CreateErrorBox("Could not delete the following diver from database: \n" + d.Name + ", " + d.Nationality + ", " + d.SSN + "\nExeption: " + e, MethodBase.GetCurrentMethod().Name);
            }
            #endregion
        }

        /// <summary>
        /// Console function.
        /// Prints all the rows in the Diver table in the console.
        /// </summary>
        public void PrintDiverTableInConsole()
        {
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + " used.");

            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
                return;
            }
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
            #region Exceptions

            catch (SQLiteException sqliteEx)
            {
                Console.WriteLine("Could not print the Diver table.\n" + sqliteEx);
            }

            catch (Exception e)
            {
                Console.WriteLine("Could not print the Diver table.\n" + e);
            }
            #endregion
        }

        /// <summary>
        /// Update a diver row in the database.
        /// </summary>
        /// <param name="d">Diver object.</param>
        public void UpdateDiver(Diver d)
        {
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + " run on SSN " + d.SSN);

            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
                return;
            }
            try
            {
                string sql = "UPDATE Diver SET Name = '" + d.Name + "', SSN = '" + d.SSN + "', Nationality = '" + d.Nationality + "' WHERE ID = '" + d.Id + "'";
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                command.ExecuteNonQuery();
            }
            #region Exceptions

            catch (SQLiteException sqliteEx)
            {
                MsgBox.CreateErrorBox("Could not update the following Diver in database: \n" + d.Name + ", " + d.Nationality + ", " + d.SSN + "\nExeption: " + sqliteEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (Exception e)
            {
                MsgBox.CreateErrorBox("Could not update the following Diver in database: \n" + d.Name + ", " + d.Nationality + ", " + d.SSN + "\nExeption: " + e, MethodBase.GetCurrentMethod().Name);
            }
            #endregion
        }

        /// <summary>
        /// Gets the divers from datbase, puts them in a lisa and returns it.
        /// </summary>
        /// <returns>List of Judge objects.</returns>
        public BindingList<Diver> GetDiverList()
        {
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + " used.");

            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
                return new BindingList<Diver>();
            }
            try
            {
                string sql = "SELECT * FROM Diver";
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                BindingList<Diver> dl = new BindingList<Diver>();
                while (reader.Read())
                {
                    Diver d = new Diver(Convert.ToInt32(reader["ID"]), Convert.ToString(reader["Name"]), Convert.ToString(reader["Nationality"]), Convert.ToString(reader["SSN"]));
                    dl.Add(d);
                }
                return dl;
            }
                #region Exceptions

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
            #endregion

            return new BindingList<Diver>();
        }

        /// <summary>
        /// Returns a diver id from database based on divers ssn.
        /// </summary>
        /// <param name="ssn">Diver ssn (social security number)</param>
        /// <returns>diver id (int)</returns>
        public int GetDiverId(string ssn)
        {
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + "run on SSN " + ssn);

            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
                throw new Exception("No connection to database.");
            }

            try
            {
                int id = -1;
                string sql = "SELECT ID FROM Diver WHERE SSN = '" + ssn + "'";
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["ID"]);
                }
                return id;
            }
            #region Exceptions

            catch (SQLiteException sqliteEx)
            {
                MsgBox.CreateErrorBox("Could not get Diver ID from database.\n" + sqliteEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (FormatException formatEx)
            {
                MsgBox.CreateErrorBox("Could not get Diver ID from database.\n" + formatEx.GetType() + "\n" + formatEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (InvalidCastException invalidCastEx)
            {
                MsgBox.CreateErrorBox("Could not get Diver ID from database.\n" + invalidCastEx.GetType() + "\n" + invalidCastEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (OverflowException overflowEx)
            {
                MsgBox.CreateErrorBox("Could not get Diver ID from database.\n" + overflowEx.GetType() + "\n" + overflowEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (Exception e)
            {
                MsgBox.CreateErrorBox("Could not get Diver ID from database.\n" + e, MethodBase.GetCurrentMethod().Name);
            }
            #endregion
            return -1; //Can't happen.
        }

        #endregion

        #region Judge Methods
        /// <summary>
        /// Takes a judge objekt and adds that judge to the database table Judge. 
        /// </summary>
        /// <param name="j"></param>
        public void AddJudgeToDatabase(Judge j)
        {
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + "run on SSN " + j.SSN);

            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
                return;
            }
            try
            {
                if (j.Id == -1)
                {
                    string sql = "INSERT INTO Judge(Name,SSN,Nationality,Hash,Salt) VALUES('" + j.Name + "', '" + j.SSN + "','" + j.Nationality + "','" + j.Hash + "','" + j.Salt + "')";
                    SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                    command.ExecuteNonQuery();
                }
            }
            #region Exceptions

            catch (SQLiteException sqliteEx)
            {
                MsgBox.CreateErrorBox("Could not add following Judge to database: \n" + j.Name + ", " + j.Nationality + ", " + j.SSN + "\nExeption: " + sqliteEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (Exception e)
            {
                MsgBox.CreateErrorBox("Could not add following Judge to database: \n" + j.Name + ", " + j.Nationality + ", " + j.SSN + "\nExeption: " + e, MethodBase.GetCurrentMethod().Name);
            }
            #endregion
        }

        /// <summary>
        /// Removes a row (judge) based on its social security number in the Judge table.
        /// </summary>
        /// <param name="j">Judge object.</param>
        public void RemoveJudgeFromTable(Judge j)
        {
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + "run on SSN " + j.SSN);

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
            #region Exceptions

            catch (SQLiteException sqliteEx)
            {
                MsgBox.CreateErrorBox("Could not delete the following Judge from database: \n" + j.Name + ", " + j.Nationality + ", " + j.SSN + "\nExeption: " + sqliteEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (Exception e)
            {
                MsgBox.CreateErrorBox("Could not delete the following Judge from database: \n" + j.Name + ", " + j.Nationality + ", " + j.SSN + "\nExeption: " + e, MethodBase.GetCurrentMethod().Name);
            }
            #endregion
        }

        /// <summary>
        /// Prints all the rows in the Judge table in the console.
        /// </summary>
        public void PrintJudgeTable()
        {
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + " used.");

            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
                return;
            }
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
            #region Exceptions

            catch (SQLiteException sqliteEx)
            {
                Console.WriteLine("Could not print the Judge table.\n" + sqliteEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (Exception e)
            {
                Console.WriteLine("Could not print the Judge table.\n" + e, MethodBase.GetCurrentMethod().Name);
            }
            #endregion
        }

        /// <summary>
        /// Updates a Judge row in the database.
        /// </summary>
        /// <param name="j">Judge object.</param>
        public void UpdateJudge(Judge j)
        {
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + "run on SSN " + j.SSN);

            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
                return;
            }
            try
            {
                string sql = "UPDATE Judge SET Name = '" + j.Name + "', SSN = '" + j.SSN + "', Nationality = '" + j.Nationality + "' WHERE ID = '" + j.Id + "'";
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                command.ExecuteNonQuery();
            }
            #region Exceptions

            catch (SQLiteException sqliteEx)
            {
                MsgBox.CreateErrorBox("Could not update the following Judge in database: \n" + j.Name + ", " + j.Nationality + ", " + j.SSN + "\nExeption: " + sqliteEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (Exception e)
            {
                MsgBox.CreateErrorBox("Could not update the following Judge in database: \n" + j.Name + ", " + j.Nationality + ", " + j.SSN + "\nExeption: " + e, MethodBase.GetCurrentMethod().Name);
            }
            #endregion
        }

        /// <summary>
        /// Updates a Judge row in the database.
        /// </summary>
        /// <param name="j"></param>
        public void UpdateJudgeWithHash(Judge j)
        {
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + "run on SSN " + j.SSN);

            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
                return;
            }

            try
            {
                var sql = "UPDATE Judge SET Name = '" + j.Name + "', SSN = '" + j.SSN + "'," +
                             " Nationality = '" + j.Nationality + "', Hash = '" + j.Hash +
                             "', Salt = '" + j.Salt + "' WHERE ID = '" + GetJudgeId(j.SSN) + "'";
                var command = new SQLiteCommand(sql, dbConnection);
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
        /// <summary>
        /// Gets the judges from datbase, puts them in a lisa and returns it.
        /// </summary>
        /// <returns>List of Judge objects.</returns>
        public BindingList<Judge> GetJudgeList()
        {
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + " used. ");

            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
                return new BindingList<Judge>();
            }
            else
            {
                try
                {
                    string sql = "SELECT * FROM Judge";
                    SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    BindingList<Judge> jl = new BindingList<Judge>();
                    while (reader.Read())
                    {
                        Judge j = new Judge(Convert.ToInt32(reader["ID"]), Convert.ToString(reader["Name"]), Convert.ToString(reader["Nationality"]), Convert.ToString(reader["SSN"]));
                        jl.Add(j);
                    }
                    return jl;
                }
                #region Exceptions

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
                #endregion
            }
            return new BindingList<Judge>();
        }

        /// <summary>
        /// Gets a judge id from database based on the judges ssn.
        /// </summary>
        /// <param name="ssn">Judge ssn (social security number)</param>
        /// <returns>Judge id int.</returns>
        public int GetJudgeId(string ssn)
        {
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + "run on SSN " + ssn);

            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
                throw new Exception("No connection to database.");
            }
            try
            {
                int id = -1;
                string sql = "SELECT ID FROM Judge WHERE SSN = '" + ssn + "'";
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["ID"]);
                }
                return id;
            }
            #region Exceptions

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
            #endregion
            return -1; //Can't happen.
        }

        /// <summary>
        /// Gets hash for judge.
        /// </summary>
        /// <param name="judge"></param>
        /// <returns></returns>
        public string GetJudgeHash(Judge judge)
        {
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + "run on SSN " + judge.SSN);

            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
                throw new Exception("No connection to database.");
            }
            try
            {
                var sql = "SELECT Hash FROM Judge WHERE ID = '" + judge.Id + "'";
                var command = new SQLiteCommand(sql, dbConnection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return Convert.ToString(reader["Hash"]);
                }
            }

            catch (SQLiteException sqliteEx)
            {
                MsgBox.CreateErrorBox("Could not get Judge hash from database\n" + sqliteEx, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception e)
            {
                MsgBox.CreateErrorBox("Could not get Judge hash from database.\n" + e, MethodBase.GetCurrentMethod().Name);
            }

            return null;//Can't happen.
        }
        /// <summary>
        /// Gets salt for judge.
        /// </summary>
        /// <param name="judge"></param>
        /// <returns></returns>
        public string GetJudgeSalt(Judge judge)
        {
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + "run on SSN " + judge.SSN);

            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
                throw new Exception("No connection to database.");
            }
            try
            {
                var sql = "SELECT Salt FROM Judge WHERE ID = '" + judge.Id + "'";
                var command = new SQLiteCommand(sql, dbConnection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return Convert.ToString(reader["Salt"]);
                }
            }

            catch (SQLiteException sqliteEx)
            {
                MsgBox.CreateErrorBox("Could not get Judge salt from database\n" + sqliteEx, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception e)
            {
                MsgBox.CreateErrorBox("Could not get Judge salt from database.\n" + e, MethodBase.GetCurrentMethod().Name);
            }

            return null;//Can't happen.
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
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + "run on name " + c.Name);

            //Checks if the given contest already exists in the database.
            if (c.Id != -1)
            {
                MsgBox.CreateErrorBox("Competition is already initialized.", MethodBase.GetCurrentMethod().Name);
                return;
            }
            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
                return;
            }
            try
            {
                //Add the contest info to contest database.
                string sql = "INSERT INTO Contest(Place, Name, StartDate, EndDate, Finished) VALUES('" + c.Place + "', '" + c.Name + "','" + c.StartDate + "','" + c.EndDate + "','" + c.IsFinished + "')";
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                command.ExecuteNonQuery();

                c.Id = GetLastId();

            }
                #region Exceptions
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
            #endregion
        }


        /// <summary>
        /// Removes a row (contest) based on its ID.
        /// </summary>
        /// <param name="c">Contest object.</param>
        public void RemoveContestFromTable(Contest c) //Lägg till att alla klasser som har en tabell i databasen har ett id. Måste finnas för att följande ska kunna användas. 
        {
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + "run on name " + c.Name);

            /*string sql = "DELETE FROM Contest where ??? ='" + c.??? + "'";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
            */
        }

        /// <summary>
        /// Creates a list of all the saved competitions in the database and returns that list.
        /// </summary>
        /// <returns>BindingList with contests.</returns>
        public BindingList<Contest> GetContestList()
        {
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + " used.");

            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
                return new BindingList<Contest>();
            }
            try
            {
                string sql = "SELECT * FROM Contest";
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                BindingList<Contest> cl = new BindingList<Contest>();
                while (reader.Read())
                {
                    Contest c = new Contest(Convert.ToInt32(reader["ID"]), Convert.ToString(reader["Place"]), Convert.ToString(reader["Name"]), Convert.ToString(reader["StartDate"]), Convert.ToString(reader["EndDate"]));
                    c.IsFinished = Convert.ToBoolean(reader["Finished"]); 

                    cl.Add(c);
                }
                return cl;
            }
                #region Exceptions

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
            #endregion

            return new BindingList<Contest>();
        }

        /// <summary>
        /// Builds up a contest object from informations stored in database and returns it.
        /// </summary>
        /// <param name="contest"></param>
        /// <returns>Contest object.</returns>
        public Contest GetContest(Contest contest)
        {
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + "run on name " + contest.Name);

            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
            }
            try
            {

                //Get all judges in the contest.
                string sqlGetJudges = "SELECT DISTINCT Judge.ID, Judge.Name, Judge.SSN, Judge.Nationality, Judge.Hash, Judge.Salt" +
                             " FROM Judge, Jump, Evaluation, Contest" +
                             " WHERE Contest.ID = '" + contest.Id + "'" +
                             " AND Evaluation.Judge = Judge.ID;";
                SQLiteCommand commandGetJudges = new SQLiteCommand(sqlGetJudges, dbConnection);
                SQLiteDataReader readerGetJudges = commandGetJudges.ExecuteReader();
                while (readerGetJudges.Read())
                {
                    contest.AddJudge(new Judge(Convert.ToInt32(readerGetJudges["ID"]), 
                                                Convert.ToString(readerGetJudges["Name"]), 
                                                Convert.ToString(readerGetJudges["Nationality"]), 
                                                Convert.ToString(readerGetJudges["SSN"]), 
                                                Convert.ToString(readerGetJudges["Hash"]), 
                                                Convert.ToString(readerGetJudges["Salt"])));
                }
                
                //Add participants to contest.
                //Get participant divers.
                string sqlGetDivers = "SELECT DISTINCT Diver.ID, Diver.Name, Diver.Nationality, Diver.SSN" +
                             " FROM Diver, Jump" +
                             " WHERE Jump.Contest = '" + contest.Id + "'" +
                             " AND Jump.Diver = Diver.ID;";
                SQLiteCommand commandGetDivers = new SQLiteCommand(sqlGetDivers, dbConnection);
                SQLiteDataReader readerGetDivers = commandGetDivers.ExecuteReader();
                while (readerGetDivers.Read())
                {
                    
                    Diver d = new Diver(Convert.ToInt32(readerGetDivers["ID"]), Convert.ToString(readerGetDivers["Name"]), Convert.ToString(readerGetDivers["SSN"]), Convert.ToString(readerGetDivers["Nationality"]));
                    Participant p = new Participant(d);
                    //Get participant jumpResults
                    string sqlGetJumpResult = "SELECT DISTINCT Trick.Name, Evaluation.Point, Jump.TotalPoint" +
                                              " FROM Trick, Evaluation, Jump" +
                                              " WHERE Jump.Contest = '" + contest.Id + "'" +
                                              " AND Jump.Diver = '" + d.Id + "'" +
                                              " AND Jump.Trick = Trick.ID" +
                                              " AND Jump.ID = Evaluation.Jump;";
                    SQLiteCommand commandGetJumpResult = new SQLiteCommand(sqlGetJumpResult, dbConnection);
                    SQLiteDataReader readerGetJumpResult = commandGetJumpResult.ExecuteReader();
                    int numberOfJudges = contest.GetNumberOfJudges();
                    int JumpNumber = 0;
                    int judgeNumber = 0;
                    while (readerGetJumpResult.Read() && JumpNumber < 3)
                    {
                        if (judgeNumber == (numberOfJudges - 1))
                        {
                            p.SetTrick(JumpNumber, Convert.ToString(readerGetJumpResult["Name"]));
                            judgeNumber = 0;
                            JumpNumber++;
                        }
                        p.SetJudgePoint(JumpNumber, judgeNumber, Convert.ToDouble(readerGetJumpResult["Point"]));
                        judgeNumber++;
                    }
                    p.CalculatePoints();
                    //Uppdatera tot poäng för alla tre hopp.
                    contest.AddParticipant(p);
                }
                return contest;
            }
            #region Exceptions

            catch (SQLiteException sqliteEx)
            {
                MsgBox.CreateErrorBox("Could not get contest from database.\n" + sqliteEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (FormatException formatEx)
            {
                MsgBox.CreateErrorBox("Could not get contest from database.\n" + formatEx.GetType() + "\n" + formatEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (InvalidCastException invalidCastEx)
            {
                MsgBox.CreateErrorBox("Could not get contest from database.\n" + invalidCastEx.GetType() + "\n" + invalidCastEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (OverflowException overflowEx)
            {
                MsgBox.CreateErrorBox("Could not get contest from database.\n" + overflowEx.GetType() + "\n" + overflowEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (Exception e)
            {
                MsgBox.CreateErrorBox("Could not get contest from database.\n" + e, MethodBase.GetCurrentMethod().Name);
            }
            #endregion
            return null;
        }
        /// <summary>
        /// Updates a Contest row in the database.
        /// </summary>
        /// <param name="contest">Contest object</param>
        public void UpdateContest(Contest contest)
        {
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + " run on contest " + contest.Name);

            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
                return;
            }
            if (!contest.IsFinished)
            {
                MsgBox.CreateErrorBox("Contest is not finished and can not be saved to database.", MethodBase.GetCurrentMethod().Name);
                return;
            }
            try
            {
                string sql = "UPDATE Contest SET Name = '" + contest.Name + "', Place = '" + contest.Place + "', StartDate = '" + contest.StartDate + "', EndDate = '" + contest.EndDate + "' WHERE ID = '" + contest.Id + "'";
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                command.ExecuteNonQuery();

                //Add all new judges to the database and update their id.
                foreach (var judges in contest.GetJudgesList())
                {
                    if (judges.Id == -1)
                    {
                        //Checks if judge exicts in database already.
                        int judgeId = GetJudgeId(judges.SSN);
                        if (judgeId != -1)
                        {
                            judges.Id = judgeId;
                        }
                        else
                        {
                            AddJudgeToDatabase(judges);
                            judges.Id = GetLastId();
                        }
                    }
                }


                foreach (var participant in contest.GetParticipants())
                {
                    //Add participant to database if not already initialized and update divers id.
                    if (participant.GetDiverId() == -1)
                    {
                        int diverId = GetDiverId(participant.GetDiverSSN());
                        if (diverId != -1)
                        {
                            participant.SetDiverId(diverId);
                        }
                        else
                        {
                            AddDiverToDatabase(participant.GetDiver());
                            participant.SetDiverId(GetLastId());
                        }
                    }

                    foreach (var jumpResult in participant.GetJumpResults())
                    {
                        //Add Jump to database.
                        AddJumpToDatabase(jumpResult.SumJudgePoints, participant.GetDiverId(), contest.Id, GetTrickIdByName(jumpResult.TrickName));
                        int latestJumpId = GetLastId();
                        int pointNumber = 0;
                        foreach (var judges in contest.GetJudgesList())
                        {
                            //Add evaluation to database.
                            AddEvaluationToDatabase(latestJumpId, judges.Id, jumpResult.GetJudgePoint(pointNumber++));
                        }
                    }
                }
            }
            #region Exceptions

            catch (SQLiteException sqliteEx)
            {
                MsgBox.CreateErrorBox("Could not update the following Contest in database: \n" + contest.Name + ", " + contest.Place + ", " + contest.StartDate + ", " + contest.EndDate + "\nExeption: " + sqliteEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (Exception e)
            {
                MsgBox.CreateErrorBox("Could not update the following Contest in database: \n" + contest.Name + ", " + contest.Place + ", " + contest.StartDate +  ", " + contest.EndDate + "\nExeption: " + e, MethodBase.GetCurrentMethod().Name);
            }
            #endregion
        }
        #endregion

        #region Trick Methods
        /// <summary>
        /// Adds a Trick objekt to the database.
        /// </summary>
        /// <param name="t"></param>
        public void AddTrickToDatabase(Trick t)
        {
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + "run on name " + t.Name);

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
            #region Exceptions

            catch (SQLiteException sqliteEx)
            {
                MsgBox.CreateErrorBox("Could not add the following Trick to database: \n" + t.Name + ", " + t.Difficulty + "\nExeption: " + sqliteEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (Exception e)
            {
                MsgBox.CreateErrorBox("Could not add the following Trick to database: \n" + t.Name + ", " + t.Difficulty + "\nExeption: " + e, MethodBase.GetCurrentMethod().Name);
            }
            #endregion
        }

        public BindingList<Trick> GetTrickListFromDatabase()
        {
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + " used. ");

            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
            }
            try
            {
                BindingList<Trick> trickList = new BindingList<Trick>();
                string sql = "SELECT * FROM Trick";
                SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    
                    Trick t = new Trick(Convert.ToString(reader["Name"]), Convert.ToDouble(reader["Difficulty"]));
                    trickList.Add(t);
                }
                return trickList;
            }
            #region Exceptions

            catch (SQLiteException sqliteEx)
            {
                MsgBox.CreateErrorBox("Could not get Tricks from database.\n" + sqliteEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (FormatException formatEx)
            {
                MsgBox.CreateErrorBox("Could not get Tricks from database.\n" + formatEx.GetType() + "\n" + formatEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (InvalidCastException invalidCastEx)
            {
                MsgBox.CreateErrorBox("Could not get Tricks from database.\n" + invalidCastEx.GetType() + "\n" + invalidCastEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (OverflowException overflowEx)
            {
                MsgBox.CreateErrorBox("Could not get Tricks from database.\n" + overflowEx.GetType() + "\n" + overflowEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (Exception e)
            {
                MsgBox.CreateErrorBox("Could not get Tricks from database.\n" + e, MethodBase.GetCurrentMethod().Name);
            }
            #endregion
            return null;
        }

        /// <summary>
        /// Adds trick to the database by name and difficulty by creating a 
        /// Trick object and sending it to the other AddTrickToDatabase(Trick t) function.
        /// </summary>
        /// <param name="trickName"></param>
        /// <param name="difficulty"></param>
        public void AddTrickToDatabase(string trickName, double difficulty)
        {
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + "run on name " + trickName);

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
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + "run on name " + trickName);

            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
                throw new Exception("No connetion to database.");
            }
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
                #region Exceptions

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
            #endregion

            return -1; //Can't happen.
        }

        #endregion

        #region JumpResults Methods

        public void AddJumpResultToDatabase(Participant participant, int contestId) ///Gör färdigt efter get trick id by name. Bättre att ta ett participantobjekt???
        {
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + "run on SSN " + participant.GetDiverSSN() +  " and contest id " + contestId);

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
            #region Exceptions

            catch (SQLiteException sqliteEx)
            {
                MsgBox.CreateErrorBox("Could not add following Judge to database: \n" + sqliteEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (Exception e)
            {
                MsgBox.CreateErrorBox("Could not add following Judge to database: \n" + e, MethodBase.GetCurrentMethod().Name);
            }
            #endregion
        }

        public List<JumpResult> GetJumpResults() //Gör så att denna funkar!!!
        {
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + " used");
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
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + "run on (diverId, contestId, trickId) ( + " +
                diverId + ", " + contestId + ", " + trickId + ")");

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
            #region Exceptions

            catch (SQLiteException sqliteEx)
            {
                MsgBox.CreateErrorBox("Could not add Jump to database: \n" + sqliteEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (Exception e)
            {
                MsgBox.CreateErrorBox("Could not add Jump to database: \n" + e, MethodBase.GetCurrentMethod().Name);
            }
            #endregion
        }

        #endregion

        #region Evaluation
        /// <summary>
        /// Adds a jump evaluation to the database.
        /// </summary>
        /// <param name="jumpId"></param>
        /// <param name="judgeId"></param>
        /// <param name="point"></param>
        public void AddEvaluationToDatabase(int jumpId, int judgeId, double point)
        {
            log.Debug("Function " + MethodBase.GetCurrentMethod().Name + "run on (judgeId, jumpId) ( + " + judgeId + ", " + jumpId + ")");

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
            #region Exceptions

            catch (SQLiteException sqliteEx)
            {
                MsgBox.CreateErrorBox("Could not add evaluation database: \n" + sqliteEx, MethodBase.GetCurrentMethod().Name);
            }

            catch (Exception e)
            {
                MsgBox.CreateErrorBox("Could not add evaluation to database: \n" + e, MethodBase.GetCurrentMethod().Name);
            }
            #endregion
        }
        #endregion

        #region Trick

        #endregion

        #region IDisposable methods

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbConnection.Close();
                log.Info("Database connection closed.");
            }
        }

        #endregion

    }
}