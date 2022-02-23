using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraJeanSibaja
{
    public partial class Calculadora : Form
    {
        private Actions calc;
        private string operation;

        public Calculadora()
        {
            this.calc = new Actions();
            InitializeComponent();
        }

        private void btnNum0_Click(object sender, EventArgs e)
        {
            this.cleanInput();
            tbxDisplay.Text = tbxDisplay.Text + "0";
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            this.cleanInput();
            tbxDisplay.Text = tbxDisplay.Text + ",";
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            try
            {
                this.cleanInput();
                if (operation != null && operation != "")
                {

                    string[] numberTwo = tbxDisplay.Text.Split('+', '-', '/', '*');

                    if (numberTwo.Length == 2 && (numberTwo[1] != null && numberTwo[1] != ""))
                    {
                        calc.numberTwo = double.Parse(numberTwo[1]);
                        tbxDisplay.Text = calc.calculation(operation);
                        operation = "";
                    }
                }
            }
            catch (Exception)
            {
                tbxDisplay.Text = "SYNTAX ERROR";
            }
        }

        private void btnMemoryMinus_Click(object sender, EventArgs e)
        {
            try
            {
                this.cleanInput();
                if (tbxDisplay.Text.Trim() != "")
                {
                    calc.mMinus(double.Parse(tbxDisplay.Text.Trim()));
                    tbxDisplay.Text = "";
                }
            }
            catch (Exception)
            {
                tbxDisplay.Text = "SYNTAX ERROR";
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            try
            {
                this.cleanInput();
                if (calc.numberOne == 0.0 && tbxDisplay.Text.Trim() != "")
                {
                    operation = "+";
                    calc.numberOne = double.Parse(tbxDisplay.Text.Trim());
                    tbxDisplay.Text = tbxDisplay.Text + "+";
                }
            }
            catch (Exception)
            {
                tbxDisplay.Text = "SYNTAX ERROR";
            }
        }

        private void btnNum3_Click(object sender, EventArgs e)
        {
            this.cleanInput();
            tbxDisplay.Text = tbxDisplay.Text + "3";
        }

        private void btnNum2_Click(object sender, EventArgs e)
        {
            this.cleanInput();
            tbxDisplay.Text = tbxDisplay.Text + "2";
        }

        private void btnNum1_Click(object sender, EventArgs e)
        {
            this.cleanInput();
            tbxDisplay.Text = tbxDisplay.Text + "1";
        }

        private void btnNum4_Click(object sender, EventArgs e)
        {
            this.cleanInput();
            tbxDisplay.Text = tbxDisplay.Text + "4";
        }

        private void btnNum5_Click(object sender, EventArgs e)
        {
            this.cleanInput();
            tbxDisplay.Text = tbxDisplay.Text + "5";
        }

        private void btnNum6_Click(object sender, EventArgs e)
        {
            this.cleanInput();
            tbxDisplay.Text = tbxDisplay.Text + "6";
        }

        private void btnNum7_Click(object sender, EventArgs e)
        {
            this.cleanInput();
            tbxDisplay.Text = tbxDisplay.Text + "7";
        }

        private void btnNum8_Click(object sender, EventArgs e)
        {
            this.cleanInput();
            tbxDisplay.Text = tbxDisplay.Text + "8";
        }

        private void btnNum9_Click(object sender, EventArgs e)
        {
            this.cleanInput();
            tbxDisplay.Text = tbxDisplay.Text + "9";
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            try
            {
                this.cleanInput();
                if (calc.numberOne == 0.0 && tbxDisplay.Text.Trim() != "")
                {
                    operation = "-";
                    calc.numberOne = double.Parse(tbxDisplay.Text.Trim());
                    tbxDisplay.Text = tbxDisplay.Text + "-";
                }
            }
            catch (Exception)
            {
                tbxDisplay.Text = "SYNTAX ERROR";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbxDisplay.Text = "";
            calc.clear();
            operation = "";
        }

        private void btnClearError_Click(object sender, EventArgs e)
        {
            try
            {
                this.cleanInput();
                string txtDisplay = tbxDisplay.Text.Trim();

                if (txtDisplay.Length > 1)
                {
                    txtDisplay = txtDisplay.Substring(0, txtDisplay.Length - 1);
                }
                else
                {
                    txtDisplay = "";
                }


                calc.clearNumbers();
                operation = "";
                tbxDisplay.Text = txtDisplay;
            }
            catch (Exception)
            {
                tbxDisplay.Text = "SYNTAX ERROR";
            }
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            try
            {
                this.cleanInput();
                if (calc.numberOne == 0.0 && tbxDisplay.Text.Trim() != "")
                {
                    operation = "*";
                    calc.numberOne = double.Parse(tbxDisplay.Text.Trim());
                    tbxDisplay.Text = tbxDisplay.Text + "*";
                }
            }
            catch (Exception)
            {
                tbxDisplay.Text = "SYNTAX ERROR";
            }
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            try
            {
                this.cleanInput();
                if (calc.numberOne == 0.0 && tbxDisplay.Text.Trim() != "")
                {
                    operation = "/";
                    calc.numberOne = double.Parse(tbxDisplay.Text.Trim());
                    tbxDisplay.Text = tbxDisplay.Text + "/";
                }
            }

            catch (Exception)
            {
                tbxDisplay.Text = "SYNTAX ERROR";
            }
        }

        private void btnMOD_Click(object sender, EventArgs e)
        {
            try
            {
                this.cleanInput();
                if (operation != "" && operation == "/")
                {
                    string[] numbers = tbxDisplay.Text.Split('/');

                    if (numbers.Length == 2 && (numbers[1] != null && numbers[1] != ""))
                    {
                        calc.numberTwo = double.Parse(numbers[1]);
                        tbxDisplay.Text = calc.mod().ToString();
                        operation = "";
                    }
                }
            }
            catch (Exception)
            {
                tbxDisplay.Text = "SYNTAX ERROR";
            }
        }

        private void btnMemoryStorage_Click(object sender, EventArgs e)
        {
            try
            {
                this.cleanInput();
                if (tbxDisplay.Text.Trim() != "")
                {
                    char[] operators = { '+', '-', '/', '*' };

                    if (tbxDisplay.Text.IndexOfAny(operators) == -1)
                    {
                        calc.memoryStorage(double.Parse(tbxDisplay.Text.Trim()));
                        tbxDisplay.Text = "";
                    }
                }
            }
            catch (Exception)
            {
                tbxDisplay.Text = "SYNTAX ERROR";
            }
        }

        private void btnMemoryClear_Click(object sender, EventArgs e)
        {
            calc.memoryClear();
            tbxDisplay.Text = "";
        }

        private void btnMemoryRecall_Click(object sender, EventArgs e)
        {
            this.cleanInput();
            tbxDisplay.Text = tbxDisplay.Text + calc.memoryRecall();
        }

        private void btnMemoryPlus_Click(object sender, EventArgs e)
        {
            try
            {
                this.cleanInput();
                if (tbxDisplay.Text.Trim() != "")
                {
                    calc.mPlus(double.Parse(tbxDisplay.Text.Trim()));
                    tbxDisplay.Text = "";
                }
            }
            catch (Exception)
            {
                tbxDisplay.Text = "SYNTAX ERROR";
            }
        }

        private void cleanInput()
        {
            if (tbxDisplay.Text == "SYNTAX ERROR" || tbxDisplay.Text == "You typed more than 20 numbers.")
            {
                tbxDisplay.Text = "";
            }
        }

        private void Calculadora_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString().Equals("L"))
            {
                this.btnMemoryClear_Click(sender,e);
            }

            if (e.Control && e.KeyCode.ToString().Equals("R"))
            {
                this.btnMemoryRecall_Click(sender, e);
            }

            if (e.Control && e.KeyCode.ToString().Equals("M"))
            {
                this.btnMemoryStorage_Click(sender, e);
            }

            if (e.Control && e.KeyCode.ToString().Equals("P"))
            {
                this.btnMemoryPlus_Click(sender, e);
            }

            if (e.Control && e.KeyCode.ToString().Equals("Q"))
            {
                this.btnMemoryMinus_Click(sender, e);
            }

            if (e.KeyCode.ToString().Equals("Delete"))
            {
                this.btnClearError_Click(sender, e);
            }

            if (e.KeyCode.ToString().Equals("Escape"))
            {
                this.btnClear_Click(sender, e);
            }

        }
    }
}
