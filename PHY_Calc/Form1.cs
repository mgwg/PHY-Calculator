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
            if (op.Length == 1)
            {
                pastOp.Text += (" " + input.Text);
            }
            //don't do anything otherwise

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

            if (op == "" & input.Text.Contains("E"))
            {
                input.Text = (Double.Parse(input.Text)).ToString();
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
                    input.Text = (9.81).ToString();
                    break;
                case "c":
                    input.Text = (2.9979E8).ToString();
                    break;
                case "R":
                    input.Text = (8.314).ToString();
                    break;
                case "N":
                    input.Text = (6.022E24).ToString();
                    break;
                case "K":
                    input.Text = (1.3806E-23).ToString();
                    break;
                case "eV":
                    input.Text = (1.6022E-19).ToString();
                    break;
                case "q_e":
                    input.Text = (1.6022E-19).ToString();
                    break;
                case "m_e":
                    input.Text = (9.1094E-31).ToString();
                    break;
                case "m_p":
                    input.Text = (1.6726E-27).ToString();
                    break;
                case "h":
                    input.Text = (6.6261E-34).ToString();
                    break;
                case "ħ":
                    input.Text = (1.0546E-34).ToString();
                    break;
                case "π":
                    input.Text = (3.1416).ToString();
                    break;
                case "e":
                    input.Text = (prevAns + Double.Parse(input.Text)).ToString();
                    break;
                default:
                    break;
            }
            
        }


    }
}
