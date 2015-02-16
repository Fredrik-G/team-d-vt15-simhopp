using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Björn", "Olsson", "password");
            Person p2 = new Person("Jimmy", "Makkonen", "pw");
            Person p3 = new Person("Gnurra", "Larsson", "password");
            DatabaseController dbc = new DatabaseController();
            dbc.ConnectToDatabase();
            dbc.AddPersonToDatabase(p1);
            dbc.AddPersonToDatabase(p2);
            dbc.AddPersonToDatabase(p3);
            Console.WriteLine("Persons in db:");
            dbc.PrintPersonTable();
            dbc.DeletePersonFromDatabase(p1);
            Console.WriteLine("Persons in db after remove:");
            dbc.PrintPersonTable();
            dbc.CloseConnectionToDatabase();
            Console.ReadKey();
        }
    }
}
