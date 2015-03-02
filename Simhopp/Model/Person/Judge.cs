using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Simhopp.Model
{
    /// <summary>
    /// Class that inherits from person class and holds information about a diver.
    /// Also has hash & salt string and functions to calculate them. 
    /// </summary>
    public class Judge : Person
    {
        #region Data

        private string hash = string.Empty;
        private string salt = string.Empty;
        private static RNGCryptoServiceProvider rngCrypto = new RNGCryptoServiceProvider();

        #endregion

        #region Properties

        public string Hash
        {
            get { return hash; }
        }

        public string Salt
        {
            get { return salt; }
        }

        #endregion

        #region Constructors

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
        /// Constructor with parameters.
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

        /// <summary>
        /// Constructor with parameters.
        /// Should only be used by databasecontroller.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="nationality"></param>
        /// <param name="ssn"></param>
        public Judge(int id, string name, string nationality, string ssn)
        {
            this.id = id;
            this.name = name;
            this.nationality = nationality;
            this.ssn = ssn;
        }

        public Judge(int id, string name, string nationality, string ssn, string hash, string salt)
        {
            this.id = id;
            this.name = name;
            this.nationality = nationality;
            this.ssn = ssn;
            this.hash = hash;
            this.salt = salt;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Calculates a pseudo-random salt used for authentication.
        /// </summary>
        public void CalculateSalt()
        {
            const int SALT_SIZE = 5;

            var saltBytes = new byte[SALT_SIZE];
            rngCrypto.GetNonZeroBytes(saltBytes);

            salt = saltBytes.Aggregate("", (current, x) => current + String.Format("{0:x2}", x));
        }

        /// <summary>
        /// Calculates a SHA256 hash from judge password + his salt. 
        /// Judge.CalculateSalt has to be run before this function.
        /// </summary>
        /// <param name="password"></param>
        public void CalculateHash(string password)
        {
            if (string.IsNullOrEmpty(salt))
            {
                throw new Exception("Salt is not set. Run Judge.CalculateSalt first.");
            }

            var stringToHash = password + salt;
            var crypt = new SHA256Managed();
            var tempString = String.Empty;
            var crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(stringToHash), 0,
                Encoding.UTF8.GetByteCount(stringToHash));

            hash = crypto.Aggregate(tempString, (current, bit) => current + bit.ToString("x2"));
            // Same as foreach(var bit in crypto) tempstring += bit.ToString("x2));
             
        }

        #endregion
    }
}
