using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTesting
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private string password;

        public Person()
        {
            firstName = "";
            lastName = "";
            password = "";
        }

        public Person(string firstName, string lastName, string password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.password = password;
        }

        public string FirstName
        {
            get { return firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { this.lastName = value; }
        }

        public string Password
        {
            get { return password; }
            set { this.password = value; }
        }
    }
}