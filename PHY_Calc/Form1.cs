using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PHY_Calc
{
    public partial class Form1 : Form
    {
        Double prevAns = 0;
        String op = "";
        bool isOpPerformed = false;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void clickNum(object sender, EventArgs e) //enter a number
        {
            Button numButton = (Button)sender;

            if ((input.Text == "0" & (numButton.Text != "." & numButton.Text != "E")) || isOpPerformed)
            {
                input.Clear();
                isOpPerformed = false;
            }

            if ((numButton.Text == "." & input.Text.Contains(".")) || numButton.Text == "E" & input.Text.Contains("E")) //avoid adding many decimal points or E's
            {
                input.Text = input.Text;
            }
            else
            {
                input.Text += numButton.Text;
            }

        }

        private void clickOp(object sender, EventArgs e) //enter an operation
        {
            Button opButton = (Button)sender;

            if (input.Text.EndsWith("E"))
            {
                input.Text += 0;
            }

            if (prevAns != 0)
            {
                buttonEqual.PerformClick();
            }

            op = opButton.Text;
            prevAns = Double.Parse(input.Text);
            isOpPerformed = true;
            
            if (opButton.Text.Length >1) //sqrt or ln
            {
                pastOp.Text = op + "(" + prevAns + ")";
                buttonEqual.PerformClick(); //don't wait for second input
            }
            else
            {
                pastOp.Text = prevAns + " " + op;
            }
        }

        private void clickEqual(object sender, EventArgs e) //evaluate operation
        {
            if (op.Length == 1) //don't change display for sqrt and ln
            {
                pastOp.Text += (" " + input.Text);
            }
            
            switch (op)
            {
                case "+":
                    input.Text = (prevAns + Double.Parse(input.Text)).ToString();
                    break;
                case "−":
                    input.Text = (prevAns - Double.Parse(input.Text)).ToString();
                    break;
                case "×":
                    input.Text = (prevAns * Double.Parse(input.Text)).ToString();
                    break;
                case "÷":
                    input.Text = (prevAns / Double.Parse(input.Text)).ToString();
                    break;
                case "sqrt":
                    input.Text = (Math.Pow(prevAns, 0.5).ToString());
                    break;
                case "^":
                    input.Text = (Math.Pow(prevAns, Double.Parse(input.Text))).ToString();
                    break;
                case "ln":
                    input.Text = (Math.Log(prevAns)).ToString();
                    break;
                default:
                    break;
            }
            
            if (input.Text.Length > 12 & input.Text.Contains("E")) // round to 8 significant digits if expressed in scientific notation
            {
                int index = input.Text.IndexOf("E");
                input.Text = Math.Round(Double.Parse(input.Text.Substring(0, index)), 8).ToString() + input.Text.Substring(index, input.Text.Length - index);
            }

            prevAns = 0;
            op = "";
        }

        private void changeSign(object sender, EventArgs e) //change sign of input
        {
            prevAns = Double.Parse(input.Text)*-1;
            input.Text = prevAns.ToString();
            pastOp.Text = input.Text;
            prevAns = 0;
        }

        private void clear(object sender, EventArgs e) //clear past inputs
        {
            input.Text = "0";
            prevAns = 0;
            isOpPerformed = false;
            pastOp.Text = "";
        }

        private void delete(object sender, EventArgs e) //delete last input
        {
            if (isOpPerformed == true) //if last input was operator
            {
                isOpPerformed = false;
                pastOp.Text = "";
                op = "";
            }

            else
            {
                input.Text = input.Text.Remove(input.Text.Length - 1); 
            }
        }

        private void clickCnst(object sender, EventArgs e)
        {
            Button cnstButton = (Button)sender;

            if(input.Text != "0" && !isOpPerformed)  //if no operation specified, add a multiplication sign
            {
                buttonMult.PerformClick();
            }

            string cnst = cnstButton.Text;
            switch(cnst)
            {
                case "g":
                    input.Text = "9.81";
                    break;
                case "c":
                    input.Text = "2.9979E8";
                    break;
                case "R":
                    input.Text = "8.314";
                    break;
                case "N":
                    input.Text = "6.022E24";
                    break;
                case "K":
                    input.Text = "1.3806E-23";
                    break;
                case "eV":
                    input.Text = "1.6022E-19";
                    break;
                case "q_e":
                    input.Text = "1.6022E-19";
                    break;
                case "m_e":
                    input.Text = "9.1094E-31";
                    break;
                case "m_p":
                    input.Text = "1.6726E-27";
                    break;
                case "h":
                    input.Text = "6.6261E-34";
                    break;
                case "ħ":
                    input.Text = "1.0546E-34";
                    break;
                case "π":
                    input.Text = "3.1416";
                    break;
                case "e":
                    input.Text = "2.71828";
                    break;
                default:
                    break;
            }
            
        }


    }
}
