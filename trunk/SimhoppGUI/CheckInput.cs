using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simhopp.Model;

namespace SimhoppGUI
{
    /// <summary>
    /// Static class that contains methods for checking if input is correct. 
    /// Also shows incorrect input by coloring the wrong textboxes red.
    /// </summary>
    public static class CheckInput
    {
        #region Correct Input
        public static bool CheckCorrectContestInput(ErrorProvider errorProvider,
            TextBox nameTextBox,
            TextBox placeTextBox)
        {
            var correctName = CorrectContestNameInput(errorProvider, nameTextBox);
            var correctPlace = CorrectContestPlaceInput(errorProvider, placeTextBox);

            return (correctName && correctPlace);
            //return (CorrectNameInput(nameTextBox) && CorrectPlaceInput(placeTextBox)); //funkar ej?
        }
        public static bool CheckCorrectPersonInput(ErrorProvider errorProvider,
            TextBox nameTextBox,
            TextBox nationalityTextBox,
            TextBox ssnTextBox)
        {

            var correctName = CorrectPersonNameInput(errorProvider, nameTextBox);
            var correctNationality = CorrectPersonNationalityInput(errorProvider, nationalityTextBox);
            var correctSSN = CorrectPersonSSNInput(errorProvider, ssnTextBox, nationalityTextBox);

            return (correctName && correctNationality && correctSSN);
        }
        #endregion

        #region Correct Contest
        private static bool CorrectContestNameInput(ErrorProvider errorProvider, TextBox nameTextBox)
        {
            if (Contest.CheckCorrectName(nameTextBox.Text))
            {
                errorProvider.Clear();
                return true;
            }
            else
            {
                ShowError(errorProvider, nameTextBox, "Incorrect name. Allowed characters: 'a-Z '.-'");
                return false;
            }
        }
        private static bool CorrectContestPlaceInput(ErrorProvider errorProvider, TextBox placeTextBox)
        {
            if (Contest.CheckCorrectPlace(placeTextBox.Text))
            {
                errorProvider.Clear();
                return true;
            }
            else
            {
                ShowError(errorProvider, placeTextBox, "Incorrect City. Allowed characters: 'a-Z '.-'");
                return false;
            }
        }
        #endregion

        #region Correct Person
        private static bool CorrectPersonNameInput(ErrorProvider errorProvider, TextBox nameTextBox)
        {
            if (Person.CheckCorrectName(nameTextBox.Text))
            {
                errorProvider.Clear();
                return true;
            }
            else
            {
                ShowError(errorProvider, nameTextBox, "Incorrect name. Allowed characters: 'A-Z ',.-'");
                return false;
            }
        }
        private static bool CorrectPersonNationalityInput(ErrorProvider errorProvider, TextBox nationalityTextBox)
        {
            if (Person.CheckCorrectNationality(nationalityTextBox.Text))
            {
                errorProvider.Clear();
                return true;
            }
            else
            {
                ShowError(errorProvider, nationalityTextBox, "Incorrect nationality. Allowed characters: 'A-Z ,-'");
                return false;
            }
        }
        private static bool CorrectPersonSSNInput(ErrorProvider errorProvider,
            TextBox ssnTextBox,
            TextBox nationalityTextBox)
        {
            if (Person.CheckCorrectSSN(ssnTextBox.Text, nationalityTextBox.Text))
            {
                errorProvider.Clear();
                return true;
            }
            else
            {
                ShowError(errorProvider, ssnTextBox, "Incorrect SSN. Swedish: yyyymmdd-xxxx. Rest: xxx-yy-zzzz");
                return false;
            }
        }
        #endregion

        #region Correct Date

        /// <summary>
        /// Checks if date is correct.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool CheckCorrectDate(string date)
        {
            return Contest.CheckCorrectDate(date);
        }

        /// <summary>
        /// Kollar om startdatum kommer efter slutdatum. Visar även ett error om datum är fel.
        /// </summary>
        /// <param name="errorProvider"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static bool CheckCorrectStartDate(ErrorProvider errorProvider ,DateTimePicker startDate, DateTimePicker endDate)
        {
            if (startDate.Value > endDate.Value)
            {
                ShowError(errorProvider, startDate, "Start date can not occur before end date.");
                return false;
            }
            errorProvider.Clear();
            return true;
        }
        #endregion    

        private static void ShowError(ErrorProvider errorProvider, Control control, string errorMessage)
        {
            errorProvider.SetError(control, "Error: " + errorMessage);
        }
    }
}
