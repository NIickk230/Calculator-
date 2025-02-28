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

    //reccorect this currentInput = "0"; it should become just empthy string not 0 <3


    public partial class Form1 : Form
    {
        string currentInput = "";
        double result = 0;
        string operation = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            currentInput += btn.Text;
            textBox.Text += btn.Text;
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            currentInput += btn.Text;
            textBox.Text += btn.Text;
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            currentInput += btn.Text;
            textBox.Text += btn.Text;
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            currentInput += btn.Text;
            textBox.Text += btn.Text;
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            currentInput += btn.Text;
            textBox.Text += btn.Text;
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            currentInput += btn.Text;
            textBox.Text += btn.Text;
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            currentInput += btn.Text;
            textBox.Text += btn.Text;
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            currentInput += btn.Text;
            textBox.Text += btn.Text;
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            currentInput += btn.Text;
            textBox.Text += btn.Text;
        }

        private void Btn0_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            currentInput += btn.Text;
            textBox.Text += btn.Text;
        }

        private void PlusBtn_Click(object sender, EventArgs e)
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

        private void MinusBtn_Click(object sender, EventArgs e)
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

        private void MultBtn_Click(object sender, EventArgs e)
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

        private void DivBtn_Click(object sender, EventArgs e)
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

        private void EqBtn_Click(object sender, EventArgs e)
        {
            Calculate();
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Text += textBox.Text;
            }
            else
            {
                textBox2.Text = "";
                textBox2.Text += textBox.Text;
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

        private void Calculate()
        {
            if (!String.IsNullOrEmpty(currentInput))
            {
                
                double input = double.Parse(currentInput);

                switch (operation)
                {
                    case "+":
                        result += input;
                        currentInput = "0";
                        break;
                    case "-":
                        result -= input;
                        currentInput = "0";
                        break;
                    case "X":
                        result *= input;
                        currentInput = "0";
                        break;
                    case "/":
                        if(input == 0)
                        {
                            textBox.Text = "error";
                        }
                        else
                        {
                            currentInput = "0";
                            result /= input;
                        }
                        break;
                    default:
                        result = input;
                        break;
                }
               
            }
            else
            {
                textBox.Text = "error";
            }

        }

        private void CleareBtn_Click(object sender, EventArgs e)
        {
            currentInput = "0";
            result = 0;
            operation = "";
            textBox.Text = "";
            textBox2.Text = "";
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
            if(!textBox.Text.EndsWith("^2") || !textBox.Text.EndsWith("√2"))
            {
                currentInput = currentInput.Substring(0, currentInput.Length - 1);
            }
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
            double input =double.Parse(currentInput);
            currentInput = (input*input).ToString();
        }
    }
}