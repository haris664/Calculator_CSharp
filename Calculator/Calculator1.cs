using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator1 : Form
    {
        double CalculateResult = 0;
        double BinaryValue = 0;
        double DecimalValue = 0;
        string Operation = "";
        bool CheckOperation = false;

        public Calculator1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (textInput.Text == "0" || CheckOperation)
            {
                textInput.Text = "";
            }
            CheckOperation = false;
            Button btn = (Button)sender;
            textInput.Text = textInput.Text + btn.Text;
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Operation = btn.Text;
            CalculateResult = double.Parse(textInput.Text);
            CheckOperation = true;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textInput.Clear();
            CalculateResult = 0;
        }

        private void BtnEqual_Click(object sender, EventArgs e)
        {
            switch (Operation)
            {
                case "+":
                    textInput.Text = (CalculateResult + double.Parse(textInput.Text)).ToString();
                    break;
                case "-":
                    textInput.Text = (CalculateResult - double.Parse(textInput.Text)).ToString();
                    break;
                case "*":
                    textInput.Text = (CalculateResult * double.Parse(textInput.Text)).ToString();
                    break;
                case "/":
                    textInput.Text = (CalculateResult / double.Parse(textInput.Text)).ToString();
                    break;
            }
        }

        private void textInput_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }


            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }
        private void buttonBinary_Click(object sender, EventArgs e)
        {
            try
            {
                BinaryValue = Convert.ToDouble(ConvertToBinary(Convert.ToInt32(textInput.Text)));
                textInput.Text = BinaryValue.ToString();
            }
            catch
            {
                textInput.Text = "Error please enter a correct format";
            }
        }
        static string ConvertToBinary(int number)
        {
            var binaryResult = "";

            while (number > 0)
            {
                var reminder = number % 2;
                number = number / 2;
                binaryResult = reminder.ToString() + binaryResult;
            }
            return binaryResult;
        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            try
            {
                DecimalValue = Convert.ToInt32(textInput.Text, 2);
                textInput.Text = DecimalValue.ToString();
            }
            catch
            {
                textInput.Text = "Error please enter binary number";
            }
        }

        private void buttonLocation_Num_Click(object sender, EventArgs e)
        {
            var LocationNum = LocationNumerals(Convert.ToInt32(textInput.Text));
            textInput.Text = LocationNum.ToString();
        }
        static string LocationNumerals(int number)
        {
            String alphabetKey = "abcdefghijklmnopqrstuvwxyz";
            int enterNumber = number;
            String returnValue = "";
            int position;
            while (enterNumber > 0)
            {
                position = (int)(Math.Log(enterNumber) / Math.Log(2));
                enterNumber -= (int)Math.Round(Math.Pow(2, position));
                returnValue = alphabetKey[position] + returnValue;
            }

            return returnValue;
        }
    }
}
