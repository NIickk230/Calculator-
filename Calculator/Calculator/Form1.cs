using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    //make multiplication and dividing functins code more like ro root and square function for to make dividion and multiplication functions that happenes before others
    // make operation char instead of string

    public partial class Form1 : Form
    {
        string currentInput = "";
        double result = 0;
        string operation = "";
        bool firsOperation = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void commonButtonsforNumbers(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            currentInput += btn.Text;
            textBox.Text += btn.Text;
        }

        private void commonButtonForOperations(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(operation))
            {

                Calculate();
            }
            else
            {
                operation = "+";
                Calculate();
            }
            Button btn = (Button)sender;
            operation = btn.Text;
            textBox.Text += operation;
        }

        private void RootBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            textBox.Text += btn.Text;
            double input = Math.Sqrt(double.Parse(currentInput));
            currentInput = input.ToString();
        }

        private void SquareBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            textBox.Text += btn.Text;
            double input = double.Parse(currentInput);
            currentInput = (input * input).ToString();
        }

        private void EqBtn_Click(object sender, EventArgs e)
        {
            Calculate();
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Text = textBox.Text;
            }
            else
            {
                textBox2.Text = "";
                textBox2.Text = textBox.Text;
            }

            if(result % 1 != 0)
            {
                string formattedResult = result.ToString("F3");
                textBox.Text = formattedResult;
            }
            else
            {
                textBox.Text = result.ToString();
            }
            
        }
        private void CleareBtn_Click(object sender, EventArgs e)
        {
            currentInput = "";
            result = 0;
            operation = "";
            textBox.Text = "";
            textBox2.Text = "";
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
            if (string.IsNullOrEmpty(currentInput))
            {
                string input2 = result.ToString();
                input2 = input2.Substring(0, input2.Length - 1);
                //sometimes if result is only one number when we try to find what is last character after deleteing the only character result contains  the input2.Length - 1 is equal to -1 and errror occures
                char lastChar = input2[input2.Length - 1];
                if (lastChar == '.')
                {
                    input2 = input2.Substring(0, input2.Length - 1);
                }
                else
                {
                    result = double.Parse(input2);
                }
            }
            else
            {
                if (!textBox.Text.EndsWith("^2") || !textBox.Text.EndsWith("√2"))
                {
                    currentInput = currentInput.Substring(0, currentInput.Length - 1);
                }
            } 
        }

        private void Calculate()
        {
            if (String.IsNullOrEmpty(currentInput))
            {
                currentInput = "0";
            }
                
            double input = double.Parse(currentInput);

            switch (operation)
            {
                case "+":
                    result += input;
                    currentInput = "";
                    operation = "";
                    break;
                case "-":
                    result -= input;
                    currentInput = "";
                    operation = "";
                    break;
                case "X":
                    result *= input;
                    currentInput = "";
                    operation = "";
                    break;
                case "/":
                    if (input == 0)
                    {
                        textBox.Text = "error";
                    }
                    else
                    {
                        currentInput = "";
                        operation = "";
                        result /= input;
                    }
                    break;
                default:
                    result = input;
                    break;
            }

        }

    }
}