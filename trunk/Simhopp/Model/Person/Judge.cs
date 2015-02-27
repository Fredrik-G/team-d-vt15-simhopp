using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace Simhopp.Model
{
    /// <summary>
    /// Class that inherits from person class and holds information about a diver.
    /// </summary>
    public class Judge : Person
    {
        private string hash = string.Empty;
        private string salt = string.Empty;
        private static RNGCryptoServiceProvider rngCrypto = new RNGCryptoServiceProvider();

        public string Hash
        {
            get { return hash;  }
        }

        public string Salt
        {
            get { return salt; }
        }
        /// <summary>
        /// Default constructor
        /// </summary>
        public Judge()
        {
            this.id = -1;
            this.name = "";
            this.nationality = "";
            this.ssn = "";
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="nationality"></param>
        /// <param name="ssn"></param>
        public Judge(string name, string nationality, string ssn)
        {
            this.id = -1;
            this.name = name;
            this.nationality = nationality;
            this.ssn = ssn;
        }

        public Judge(int id, string name, string nationality, string ssn)
        {
            this.id = id;
            this.name = name;
            this.nationality = nationality;
            this.ssn = ssn;
        }

        public void CalculateSalt()
        {
            var saltBytes = new byte[5];
            rngCrypto.GetNonZeroBytes(saltBytes);

            salt = saltBytes.Aggregate("", (current, x) => current + String.Format("{0:x2}", x));
        }

        public void CalculateHash(string password)
        {
            if (salt == string.Empty)
            {
                return;
            }

            var stringToHash = password + salt;
            var crypt = new SHA256Managed();
            var tempString = String.Empty;
            var crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(stringToHash), 0, Encoding.UTF8.GetByteCount(stringToHash));

            hash = crypto.Aggregate(tempString, (current, bit) => current + bit.ToString("x2"));
        }
    }
}
