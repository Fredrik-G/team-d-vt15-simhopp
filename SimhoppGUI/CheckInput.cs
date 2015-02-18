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
    public class CheckInput
    {
        #region Correct Input
        public static bool CheckCorrectInput(TextBox nameTextBox, TextBox placeTextBox)
        {
            var correctName = CorrectNameInput(nameTextBox);
            var correctPlace = CorrectPlaceInput(placeTextBox);

            return (correctName && correctPlace);
            //return (CorrectNameInput(nameTextBox) && CorrectPlaceInput(placeTextBox));
        }

        private static bool CorrectNameInput(TextBox textBox)
        {
            if (Contest.CheckCorrectName(textBox.Text))
            {
                return true;
            }
            else
            {
                ShowError(textBox);
                return false;
            }
        }
        private static bool CorrectPlaceInput(TextBox textBox)
        {
            if (Contest.CheckCorrectPlace(textBox.Text))
            {
                return true;
            }
            else
            {
                ShowError(textBox);
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
