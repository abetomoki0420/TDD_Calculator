using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDD_Calculator
{
    public class Calculator
    {
        private double sum = 0;
        private double memmoryValue = 0;
        private string typeOfCalc;

        public Calculator()
        {
        }

        public void setValue( double value) {
            memmoryValue = value;
        }

        public double Calculate(string type)
        {
            if (string.IsNullOrEmpty(typeOfCalc))
            {
                sum = memmoryValue;
            }
            else
            {
                sum = Equal();
            }
            typeOfCalc = type;
            return sum;
        }

        public double Equal()
        {
            switch (typeOfCalc)
            {
                case "Add":
                    sum += memmoryValue;
                    break;
                case "Subtract":
                    sum -= memmoryValue;
                    break;
                case "Multiply":
                    sum *= memmoryValue;
                    break;
                case "Divide":
                    sum /= memmoryValue;
                    break;
                default:
                    break;
            }

            typeOfCalc = string.Empty;
            return sum;
        }

        public void Clear()
        {
            sum = 0;
            memmoryValue = 0;
            typeOfCalc = string.Empty;
        }
    }

    public static class Operator
    {
        public static string Add = "Add";
        public static string Subtract = "Subtract";
        public static string Multiply = "Multiply";
        public static string Divide = "Divide";

    }
}
