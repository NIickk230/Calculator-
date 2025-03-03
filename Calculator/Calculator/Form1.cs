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
    //fuck change whole code its enough with playing
    //change currentinput some the way that it cant have more than 3 digits after . becuase if its have at the end we name it f3 format so in text it wont not have but in the current input yea it will have and when u try to delete u delete whole text in text box but will still left umbers in currentinput or result end u should make it like this after every operation because its not enough to do eat the end because before that it will add u pto eachother and give us differante answer from expected one and many aother condition so u should make sure it wont not go  more far trhen 3 numbers after . and somehow realy easly dso u have not to write all shity code 100 times in ur shity code

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
            string formattedResult = input.ToString("F3");
            currentInput = formattedResult;
        }

        private void SquareBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            textBox.Text += btn.Text;
            double input = double.Parse(currentInput);
            string formattedResult = (input * input).ToString("F3");
            currentInput = formattedResult;
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
            ///this thing sucks i know im trying to change it
            if(!string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
                if (textBox.Text.Length > 0 && textBox.Text[textBox.Text.Length - 1] == '.')
                {
                    textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
                }
            }
            
            if (string.IsNullOrEmpty(currentInput))
            {
                CleareBtn.PerformClick();
            }
            else
            {
                if (!textBox.Text.EndsWith("^2") || !textBox.Text.EndsWith("√2"))
                {
                    currentInput = currentInput.Substring(0, currentInput.Length - 1);
                }
                if (currentInput.Length > 0 && currentInput[currentInput.Length - 1] == '.')
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