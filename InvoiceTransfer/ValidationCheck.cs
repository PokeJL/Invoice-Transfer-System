using Microsoft.Data.SqlClient;
using InvoiceData;


namespace InvoiceTransfer
{
    public static class ValidationCheck
    {
        /// <summary>
        /// Ensures that a textbox is not empty
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        public static bool NotEmpty(TextBox textBox)
        {
            bool valid = true;

            if (textBox.Text.Trim() == string.Empty)
            {
                valid = false;
                MessageBox.Show($"{textBox.Tag} must be filled.");
                textBox.Focus();
            }

            return valid;
        }

        /// <summary>
        /// Ensures that the number is positive, and actual number, and formatted properly
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns></returns>
        public static bool ProperNumber(TextBox textBox)
        {
            bool valid = true;
            decimal valDec;
            int valInt;

            if (int.TryParse(textBox.Text.Trim(), out valInt)) //Checks if a number is an integer
            {
                if (valInt < 0) //Ensues that the number is a positive number
                {
                    valid = false;
                    MessageBox.Show($"{textBox.Tag} debit amount can not be a negative number.");
                    textBox.Focus();
                }
            }
            else if (Decimal.TryParse(textBox.Text.Trim(), out valDec)) //Checks is a number is a decimal
            {
                if (valDec < 0) //Ensues that the number is a positive number
                {
                    valid = false;
                    MessageBox.Show($"{textBox.Tag} debit amount can not be a negative number.");
                    textBox.Focus();
                }
                else if (textBox.Text.Trim().Length - textBox.Text.Trim().IndexOf('.') > 3 &&   //Ensures that the number only has a max
                    textBox.Text.Trim().IndexOf('.') != -1)                                     //decimal places
                {
                    valid = false;
                    MessageBox.Show($"{textBox.Tag} debit amount can only have two digits after the decimal.");
                    textBox.Focus();
                }
                else if (textBox.Text.Trim().Length - textBox.Text.Trim().IndexOf('.') == 1)    //Ensures the number has digits after the 
                {                                                                               //decimal point
                    valid = false;
                    MessageBox.Show($"{textBox.Tag} debit amount can not end with a decimal.");
                    textBox.Focus();
                }
                else if (textBox.Text.Trim().IndexOf('.') == 0) //Ensures that the number does not lead with a decimal
                {
                    valid = false;
                    MessageBox.Show($"{textBox.Tag} debit amount can not lead with a decimal.");
                    textBox.Focus();
                }
            }
            else //If the number is not a number
            {
                valid = false;
                MessageBox.Show($"{textBox.Tag} debit amount must be a numerical number.");
                textBox.Focus();
            }

            return valid;
        }

        /// <summary>
        /// Ensures that the transfer amount does not exceed payment amounts
        /// </summary>
        /// <param name="textbox1"></param>
        /// <param name="textbox2"></param>
        /// <param name="textbox3"></param>
        /// <returns></returns>
        public static bool ProperPayAmount(TextBox textbox1, TextBox textbox2, TextBox textbox3)
        {
            bool valid = true;

            if (Convert.ToDecimal(textbox1.Text.Trim()) < Convert.ToDecimal(textbox3.Text.Trim())) //Transfer amount does not over pay invoice
            {
                valid = false;
                MessageBox.Show($"{textbox3.Tag} can not be greater than {textbox1.Tag}.");
                textbox3.Focus();
            }
            else if (Convert.ToDecimal(textbox2.Text.Trim()) < Convert.ToDecimal(textbox3.Text.Trim())) //Transfer amount does not over debit source invoice
            {
                valid = false;
                MessageBox.Show($"{textbox3.Tag} can not be greater than {textbox2.Tag}.");
                textbox3.Focus();
            }

            return valid;
        }

        /// <summary>
        /// Calculates weather or not an invoive can be payed
        /// </summary>
        /// <param name="invTotal"></param>
        /// <param name="payTotal"></param>
        /// <param name="creditTotal"></param>
        /// <returns></returns>
        public static bool NotPositiveValue(decimal invTotal, decimal payTotal, decimal creditTotal)
        {
            return invTotal - payTotal - creditTotal > (decimal)0.0;
        }
    }
}
