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
                return true;
            }
            else
            {
                ShowError(errorProvider, nameTextBox);
                return false;
            }
        }
        private static bool CorrectContestPlaceInput(ErrorProvider errorProvider, TextBox placeTextBox)
        {
            if (Contest.CheckCorrectPlace(placeTextBox.Text))
            {
                return true;
            }
            else
            {
                ShowError(errorProvider, placeTextBox);
                return false;
            }
        }
        #endregion

        #region Correct Person
        private static bool CorrectPersonNameInput(ErrorProvider errorProvider, TextBox nameTextBox)
        {
            if (Person.CheckCorrectName(nameTextBox.Text))
            {
                return true;
            }
            else
            {
                ShowError(errorProvider, nameTextBox);
                return false;
            }
        }
        private static bool CorrectPersonNationalityInput(ErrorProvider errorProvider, TextBox nationalityTextBox)
        {
            if (Person.CheckCorrectNationality(nationalityTextBox.Text))
            {
                return true;
            }
            else
            {
                ShowError(errorProvider, nationalityTextBox);
                return false;
            }
        }
        private static bool CorrectPersonSSNInput(ErrorProvider errorProvider,
            TextBox ssnTextBox,
            TextBox nationalityTextBox)
        {
            if (Person.CheckCorrectSSN(ssnTextBox.Text, nationalityTextBox.Text))
            {
                return true;
            }
            else
            {
                ShowError(errorProvider, ssnTextBox);
                return false;
            }
        }
        #endregion

        #region Correct Date

        public static bool CheckCorrectDate(DateTimePicker startDate, DateTimePicker endDate)
        {
            if (startDate.Value >= endDate.Value)
            {
                endDate.ForeColor = Color.Red;
                endDate.BackColor = Color.Red;
                return false;
            }
            return true;
        }
        #endregion    

        private static void ShowError(ErrorProvider errorProvider, TextBox textBox)
        {
            errorProvider.SetError(textBox, "Error: Invalid input");
        }
    }
}
