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
            Button btn = (Button)sender;
            operation = btn.Text;
            textBox.Text += operation;
            Calculate();
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
            currentInput = "";
            textBox.Text = result.ToString();
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
                        break;
                    case "-":
                        result -= input; 
                        break;
                    case "*":
                        result *= input; 
                        break;
                    case "/":
                        if(input == 0)
                        {
                            textBox.Text = "error";
                        }
                        else
                        {
                            result /= input;
                        }
                        break;
                }
                currentInput = "";
                operation = "";
            }
            else
            {
                textBox.Text = "error";
            }

        }

        private void CleareBtn_Click(object sender, EventArgs e)
        {
            currentInput = "";
            result = 0;
            operation = "";
            textBox.Text = "";
        }
    }
}