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
    //thiiiiiisssss thing sucks go down see new code its betteeeeer

    public partial class Form1 : Form
    {
        double result = 0;
        string operation = "";
        public Form1()
        {
            InitializeComponent();
        }


        /*
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

        private void CleareBtn_Click(object sender, EventArgs e)
        {
            result = 0;
            operation = "";
            textBox.Text = "";
            textBox2.Text = "";
            currentinput = "";
        }
        */









        //almost work correctly check 6+4×3−8÷2+√25+2^3−(3)√27
​


        char lastChar = ' ';
        private void numberButtons(object sender, EventArgs e)
        {
            Button button = (Button)sender;


            if (button.Text == "." && string.IsNullOrEmpty(textBox.Text) && lastChar == '.')
            {
                textBox.Text = "error";
            }
            else
            {
                textBox.Text += button.Text;
                lastChar = textBox.Text[textBox.TextLength - 1];
            }

        }
        HashSet<char> operationChars = new HashSet<char> { '+', '-', 'X', '/', '^', '√' };
        private void operationsButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;


            if (!string.IsNullOrEmpty(textBox.Text) && !operationChars.Contains(lastChar))
            {
                textBox.Text += button.Text;
            }
            else
            {
                textBox.Text = "error";
            }
        }

        //check if last char is number
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

            result = double.Parse(outPut.Peek());
            outPut.Pop();

            if (result % 1 != 0)
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
            result = 0;
            textBox.Text = "";
            textBox2.Text = "";
            outPut.Clear();
            RPN.Clear();
            operations.Clear();
            containsPriorityOperation = false;
        }

        //new code i know i should add much more things <3

        Stack<string> outPut = new Stack<string>();
        List<string> RPN = new List<string>();
        Stack<char> operations = new Stack<char>();
        bool containsPriorityOperation = false;
        bool containsNormalOperation = false;
        private void Calculate()
        {
            HashSet<char> PriorityOperation = new HashSet<char> { 'X', '/', '^', '√' };
            string wholeNumber = string.Empty;

            foreach (char Ch in textBox.Text)
            {
                if (char.IsDigit(Ch) || Ch == '.')
                {
                    wholeNumber += Ch;
                }
                else
                {
                    RPN.Add(wholeNumber);
                    wholeNumber = "";
                    if (containsPriorityOperation || containsNormalOperation && !PriorityOperation.Contains(Ch))
                    {
                        if (!PriorityOperation.Contains(Ch))
                        {
                            containsPriorityOperation = false;
                        }
                        char tempOp;

                        tempOp = operations.Peek();
                        operations.Pop();

                        operations.Push(Ch);

                        containsNormalOperation = true;

                        RPN.Add(tempOp.ToString());

                        operations.Push(Ch);
                    }
                    else
                    {
                        operations.Push(Ch);
                        if (PriorityOperation.Contains(Ch))
                        {
                            containsPriorityOperation = true;
                        }
                        else
                        {
                            containsNormalOperation = true;
                        }
                    }
                }

            }

            RPN.Add(wholeNumber);

            foreach (char OP in operations)
            {
                RPN.Add(OP.ToString());
            }
            operations.Clear();
            containsNormalOperation = false;


            foreach (string X in RPN)
            {
                
                if (double.TryParse(X, out _))
                {
                    outPut.Push(X.ToString());
                }
                else
                {
                    if(outPut.Count() > 1)
                    {
                        double tempNum1;
                        double tempNum2;

                        tempNum1 = double.Parse(outPut.Peek());
                        outPut.Pop();

                        tempNum2 = double.Parse(outPut.Peek());
                        outPut.Pop();

                        switch (X)
                        {
                            case "+":
                                tempNum2 += tempNum1;
                                break;
                            case "-":
                                tempNum2 -= tempNum1;
                                break;
                            case "X":
                                tempNum2 *= tempNum1;
                                break;
                            case "/":
                                if (tempNum1 == 0)
                                {
                                    textBox.Text = "error";
                                }
                                else
                                {
                                    tempNum2 /= tempNum1;
                                }
                                break;
                            case "^":
                                tempNum2 = Math.Pow(tempNum2, tempNum1);
                                break;
                            case "√":
                                tempNum2 = Math.Pow(tempNum1, 1.0 / tempNum2);
                                break;
                        }

                        outPut.Push(tempNum2.ToString());
                    }
                }
            }
            RPN.Clear();
            
        }
    }
}