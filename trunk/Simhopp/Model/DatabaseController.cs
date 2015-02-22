using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Data.SQLite;

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
                Console.WriteLine("Could not connect to the database.\n" + sqliteEx.GetType() + "\n" + sqliteEx);
                MessageBox.Show("Could not connect to the database.\n" + sqliteEx.GetType() + "\n" + sqliteEx);
                dbConnection = null;
            }

            catch (Exception e)
            {
                Console.WriteLine("Could not connect to the database.\n" + e.GetType() + "\n" + e);
                MessageBox.Show("Could not connect to the database.\n" + e.GetType() + "\n" + e);
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
                Console.WriteLine("Could not connect to the database.\n" + sqliteEx.GetType() + "\n" + sqliteEx);
                MessageBox.Show("Could not connect to the database.\n" + sqliteEx.GetType() + "\n" + sqliteEx);
                dbConnection = null;
            }

            catch (Exception e)
            {
                Console.WriteLine("Could not connect to the database.\n" + e.GetType() + "\n" + e);
                MessageBox.Show("Could not connect to the database.\n" + e.GetType() + "\n" + e);
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
                Console.WriteLine("Could not connect to the database.\n" + sqliteEx.GetType() + "\n" +sqliteEx);
                MessageBox.Show("Could not connect to the database.\n" + sqliteEx.GetType() + "\n" + sqliteEx);
                dbConnection = null;
            }

            catch (Exception e)
            {
                Console.WriteLine("Could not connect to the database.\n" + e.GetType() + "\n" + e);
                MessageBox.Show("Could not connect to the database.\n" + e.GetType() + "\n" + e);
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
                Console.WriteLine("The connection to the database has not been initialized.");
                MessageBox.Show("The connection to the database has not been initialized.");
            }
            else
            {
                try
                {
                    dbConnection.Close();
                }

                catch (SQLiteException sqliteEx)
                {
                    Console.WriteLine("Could not close connection to the database.\n" + sqliteEx.GetType() + "\n" + sqliteEx);
                    MessageBox.Show("Could not close connection to the database.\n" + sqliteEx.GetType() + "\n" + sqliteEx);
                    dbConnection = null;
                }

                catch (Exception e)
                {
                    Console.WriteLine("Could not close connection to the database.\n" + e.GetType() + "\n" + e);
                    MessageBox.Show("Could not close connection to the database.\n" + e.GetType() + "\n" + e);
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
        public bool TableIsEmpty(string tableName) //Fixa till denna. vad ska den returnera om ett exception händer.
        {
            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
            }
            else
            {
                try
                {
                    string sql = "SELECT COUNT(*) FROM " + tableName + "";
                    SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                    var numberOfEntries = Convert.ToInt32(command.ExecuteScalar());
                    if (numberOfEntries == 0)
                    {
                        return true;
                    }
                    return false;
                }
                catch (SQLiteException sqliteex)
                {
                    Console.WriteLine(sqliteex);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
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
                            Console.WriteLine("Table " + tableName + " could not be cleared.\n" + sqliteEx.GetType() + "\n" + sqliteEx);
                            MessageBox.Show("Table " + tableName + " could not be cleared.\n" + sqliteEx.GetType() + "\n" + sqliteEx);
                            dbConnection = null;
                        }

                        catch (Exception e)
                        {
                            Console.WriteLine("Table " + tableName + " could not be cleared.\n" + e.GetType() + "\n" + e);
                            MessageBox.Show("Table " + tableName + " could not be cleared.\n" + e.GetType() + "\n" + e);
                            dbConnection = null;
                        }

                    }
        }

        public void NoConnectionErrorMessage()
        {
            Console.WriteLine("Connection to a database is missing.");
            MessageBox.Show("Connection to a database is missing.");
        }
        #endregion

        #region Diver Methods
        /// <summary>
        /// Takes a diver objekt and adds that Diver to the database table Diver. 
        /// </summary>
        /// <param name="d">Diver objekt.</param>
        public void AddDivertoDatabase(Diver d)
        {
            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
            }
            else
            {
                try
                {
                    string sql = "INSERT INTO Diver(Name,SSN,Nationality) VALUES('" + d.Name + "', '" + d.SSN + "','" + d.Nationality + "')";
                    SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                    command.ExecuteNonQuery();
                }

                catch (SQLiteException sqliteEx)
                {
                    Console.WriteLine("Could not add the following Diver to database: \n" + d.Name + ", " + d.Nationality + ", " + d.SSN + "\nExeption: " + sqliteEx);
                    MessageBox.Show("Could not add the following Diver to database: \n" + d.Name + ", " + d.Nationality + ", " + d.SSN + "\nExeption: " + sqliteEx);
                }

                catch (Exception e)
                {
                    Console.WriteLine("Could not add the following Diver to database: \n" + d.Name + ", " + d.Nationality + ", " + d.SSN + "\nExeption: " + e);
                    MessageBox.Show("Could not add the following Diver to database: \n" + d.Name + ", " + d.Nationality + ", " + d.SSN + "\nExeption: " + e);
                }
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
                    Console.WriteLine("Could not delete the following diver from database: \n" + d.Name + ", " + d.Nationality +
                                      ", " + d.SSN + "\nExeption: " + sqliteEx);
                    MessageBox.Show("Could not delete the following diver from database: \n" + d.Name + ", " + d.Nationality +
                                      ", " + d.SSN + "\nExeption: " + sqliteEx);
                }

                catch (Exception e)
                {
                    Console.WriteLine("Could not delete the following diver from database: \n" + d.Name + ", " + d.Nationality +
                                      ", " + d.SSN + "\nExeption: " + e);
                    MessageBox.Show("Could not delete the following diver from database: \n" + d.Name + ", " + d.Nationality +
                                      ", " + d.SSN + "\nExeption: " + e);
                }
                
            }
        }

        /// <summary>
        /// Prints all the rows in the Diver table in the console.
        /// </summary>
        public void PrintDiverTable()
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
                    MessageBox.Show("Could not print the Diver table.\n" + sqliteEx);
                }

                catch (Exception e)
                {
                    Console.WriteLine("Could not print the Diver table.\n" + e);
                    MessageBox.Show("Could not print the Diver table.\n" + e);
                }
            }
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
            }
            else
            {
                try
                {
                    string sql = "INSERT INTO Judge(Name,SSN,Nationality) VALUES('" + j.Name + "', '" + j.SSN + "','" + j.Nationality + "')";
                    SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                    command.ExecuteNonQuery();
                }

                catch (SQLiteException sqliteEx)
                {
                    Console.WriteLine("Could not add following Judge to database: \n" + j.Name + ", " + j.Nationality +
                                      ", " + j.SSN + "\nExeption: " + sqliteEx);
                    MessageBox.Show("Could not add following Judge to database: \n" + j.Name + ", " + j.Nationality +
                                      ", " + j.SSN + "\nExeption: " + sqliteEx);
                }

                catch (Exception e)
                {
                    Console.WriteLine("Could not add following Judge to database: \n" + j.Name + ", " + j.Nationality +
                                      ", " + j.SSN + "\nExeption: " + e);
                    MessageBox.Show("Could not add following Judge to database: \n" + j.Name + ", " + j.Nationality +
                                      ", " + j.SSN + "\nExeption: " + e);
                }
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
            }
            else
            {
                try
                {
                    string sql = "DELETE FROM Judge where SSN ='" + j.SSN + "'";
                    SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                    command.ExecuteNonQuery();
                }

                catch (SQLiteException sqliteEx)
                {
                    Console.WriteLine("Could not delete the following Judge from database: \n" + j.Name + ", " + j.Nationality +
                                      ", " + j.SSN + "\nExeption: " + sqliteEx);
                    MessageBox.Show("Could not delete the following Judge from database: \n" + j.Name + ", " + j.Nationality +
                                      ", " + j.SSN + "\nExeption: " + sqliteEx);
                }

                catch (Exception e)
                {
                    Console.WriteLine("Could not delete the following Judge from database: \n" + j.Name + ", " + j.Nationality +
                                      ", " + j.SSN + "\nExeption: " + e);
                    MessageBox.Show("Could not delete the following Judge from database: \n" + j.Name + ", " + j.Nationality +
                                      ", " + j.SSN + "\nExeption: " + e);
                }

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
                    Console.WriteLine("Could not print the Judge table.\n" + sqliteEx);
                    MessageBox.Show("Could not print the Judge table.\n" + sqliteEx);
                }

                catch (Exception e)
                {
                    Console.WriteLine("Could not print the Judge table.\n" + e);
                    MessageBox.Show("Could not print the Judge table.\n" + e);
                }
            }
        }


        #endregion

        #region Contest Methods
        /// <summary>
        /// Takes a contest objekt and adds that contest to the database table Contest.
        /// </summary>
        /// <param name="c">Contest object.</param>
        public void AddContestToDatabase(Contest c)
        {
            if (dbConnection == null)
            {
                NoConnectionErrorMessage();
            }
            else
            {
                try
                {
                    string sql = "INSERT INTO Contest(Place, Name, StartDate, EndDate) VALUES('" + c.Place + "', '" + c.Name + "','" + c.StartDate + "','" + c.EndDate + "')";
                    SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
                    command.ExecuteNonQuery();
                }

                catch (SQLiteException sqliteEx)
                {
                    Console.WriteLine("Could not add the following Contest to database: \n" + c.Place + "', '" + c.Name + "','" + c.StartDate + "','" + c.EndDate + "\nExeption: " + sqliteEx);
                    MessageBox.Show("Could not add the following Contest to database: \n" + c.Place + "', '" + c.Name + "','" + c.StartDate + "','" + c.EndDate + "\nExeption: " + sqliteEx);
                }

                catch (Exception e)
                {
                    Console.WriteLine("Could not add the following Contest to database: \n" + c.Place + "', '" + c.Name + "','" + c.StartDate + "','" + c.EndDate + "\nExeption: " + e);
                    MessageBox.Show("Could not add the following Contest to database: \n" + c.Place + "', '" + c.Name + "','" + c.StartDate + "','" + c.EndDate + "\nExeption: " + e);
                }
            }
        }

        //Lägg till att alla klasser som har en tabel i databasen har ett id. Måste finnas för att följande ska kunna användas. 
        /// <summary>
        /// Removes a row (contest) based on its ID.
        /// </summary>
        /// <param name="c">Contest object.</param>
        public void RemoveContestFromTable(Contest c)
        {
            /*string sql = "DELETE FROM Contest where ??? ='" + c.??? + "'";
            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();
            */
        }

        /// <summary>
        /// Save the contest, diver, judge, jump and points result data in the database.  
        /// </summary>
        public void SaveFinishedContestToDatabase()
        {
            
        }

        #endregion

        #region Trick Methods

        #endregion

        #region Jump Methods

        #endregion
    }
}