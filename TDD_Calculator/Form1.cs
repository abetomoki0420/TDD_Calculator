using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TDD_Calculator
{
    public partial class CalculatorApp : Form
    {
        private Calculator calculator;
        private bool isInputting;
        public CalculatorApp()
        {
            InitializeComponent();

            calculator = new Calculator();
            isInputting = false;
        }

        private double inputedValue()
        {
            return double.Parse(calcDisplay.Text);
        }

        private void CalculatorApp_Load(object sender, EventArgs e)
        {
            foreach (Control control in Controls)
            {
                Button btn = control as Button;
                if (btn != null)
                {
                    if (int.TryParse(btn.Text, out int value))
                    {
                        //Numeric
                        btn.Click += new EventHandler(inputValue);
                    }
                    else
                    {
                        //Operator
                        btn.Click += new EventHandler(inputOperator);
                    }
                }
            }

            btnClear.Click += (cs, ce) => {
                calculator.Clear();
                calcDisplay.Text = "0";
                isInputting = false;
            };
        }


        private void inputValue(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (int.TryParse(btn.Text, out int value))
            {
                if (isInputting)
                {
                    if(calcDisplay.Text == "0" && value.ToString() == "0")
                    {
                        return;
                    }
                    calcDisplay.Text += value.ToString();
                }
                else
                {
                    calcDisplay.Text = value.ToString();
                    isInputting = true;
                }
            }
        }

        private void inputOperator(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string btnName = btn.Name.Replace("btn", "");
            calculator.setValue(inputedValue());

            double result = 0;
            switch (btnName)
            {
                case "Add":
                    result = calculator.Calculate(Operator.Add);
                    break;
                case "Subtract":
                    result = calculator.Calculate(Operator.Subtract);
                    break;
                case "Multiply":
                    result = calculator.Calculate(Operator.Multiply);
                    break;
                case "Divide":
                    result = calculator.Calculate(Operator.Divide);
                    break;
                case "Equal":
                    result = calculator.Equal();
                    break;
                default:
                    break;
            }

            calcDisplay.Text = result.ToString();
            isInputting = false;
        }
    }
}
