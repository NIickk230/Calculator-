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
    //mostly done could be add more little changes

    public partial class Form1 : Form
    {
        double result = 0;
        public Form1()
        {
            InitializeComponent();
        }

        char lastChar = ' ';

        private void numberButtons(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.Text == "." && (string.IsNullOrEmpty(textBox.Text) || lastChar == '.'))
            {
                MessageBox.Show("you can only add dot after number and you only can use dot once in a number", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                textBox.Text += button.Text;
                lastChar = char.Parse(button.Text);
            }

        }

        HashSet<char> operationChars = new HashSet<char> { '+', '-', 'X', '/', '^', '√' };
        private void operationsButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (!string.IsNullOrEmpty(textBox.Text) && !operationChars.Contains(textBox.Text[textBox.TextLength - 1]))
            {
                textBox.Text += button.Text;
            }
            else
            {
                MessageBox.Show("you should first add number and then operation sign", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
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

        private void EqBtn_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox.Text) && !operations.Contains(textBox.Text[textBox.TextLength - 1]))
            {
                Calculate();

                textBox2.Text = textBox.Text;
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
            else
            {
                MessageBox.Show("you cant end equation by any operation sign and you cant use equal button when text box is empty", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                    if (!containsPriorityOperation)
                    {
                        if (PriorityOperation.Contains(Ch))
                        {
                            containsPriorityOperation = true;
                        }

                        operations.Push(Ch);
                    }
                    else
                    {
                        foreach (char OP in operations)
                        {
                            RPN.Add(OP.ToString());
                        }

                        operations.Clear();
                        operations.Push(Ch);

                        if (!PriorityOperation.Contains(Ch))
                        {
                            containsPriorityOperation = false;
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
                                    MessageBox.Show("you cant divide number by 0", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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