using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        public static bool CheckCorrectContestInput(TextBox nameTextBox, TextBox placeTextBox)
        {
            var correctName = CorrectContestNameInput(nameTextBox);
            var correctPlace = CorrectContestPlaceInput(placeTextBox);

            return (correctName && correctPlace);
            //return (CorrectNameInput(nameTextBox) && CorrectPlaceInput(placeTextBox)); //funkar ej?
        }
        public static bool CheckCorrectPersonInput(TextBox nameTextBox, TextBox nationalityTextBox, TextBox ssnTextBox)
        {
            var correctName = CorrectPersonNameInput(nameTextBox);
            var correctNationality = CorrectPersonNationalityInput(nationalityTextBox);
            var correctSSN = CorrectPersonSSNInput(ssnTextBox, nationalityTextBox);

            return (correctName && correctNationality && correctSSN);
        }
        #endregion

        #region Correct Contest
        private static bool CorrectContestNameInput(TextBox nameTextBox)
        {
            if (Contest.CheckCorrectName(nameTextBox.Text))
            {
                return true;
            }
            else
            {
                ShowError(nameTextBox);
                return false;
            }
        }
        private static bool CorrectContestPlaceInput(TextBox placeTextBox)
        {
            if (Contest.CheckCorrectPlace(placeTextBox.Text))
            {
                return true;
            }
            else
            {
                ShowError(placeTextBox);
                return false;
            }
        }
        #endregion

        #region Correct Person
        private static bool CorrectPersonNameInput(TextBox nameTextBox)
        {
            if (Person.CheckCorrectName(nameTextBox.Text))
            {
                return true;
            }
            else
            {
                ShowError(nameTextBox);
                return false;
            }
        }
        private static bool CorrectPersonNationalityInput(TextBox nationalityTextBox)
        {
            if (Person.CheckCorrectNationality(nationalityTextBox.Text))
            {
                return true;
            }
            else
            {
                ShowError(nationalityTextBox);
                return false;
            }
        }
        private static bool CorrectPersonSSNInput(TextBox ssnTextBox, TextBox nationalityTextBox)
        {
            if (Person.CheckCorrectSSN(ssnTextBox.Text, nationalityTextBox.Text))
            {
                return true;
            }
            else
            {
                ShowError(ssnTextBox);
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

        private static void ShowError(TextBox textBox)
        {
            textBox.BackColor = Color.Red;
        }
    }
}
