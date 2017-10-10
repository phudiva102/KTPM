using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BT_Calculator
{
    public class Caculation
    {
        private double a;
        private double b;
        public Caculation(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public double Execute(string symbol)
        {
            double Kq = 0;
            switch (symbol)
            {
                case "+": Kq = a + b; break;
                case "-": Kq = a - b; break;
                case "*": Kq = a * b; break;
                case "/":
                    if (b == 0)
                        throw new DivideByZeroException();
                    Kq = a / b; break;
                default:
                    throw new ArgumentException("Invalid Operator");
            }
            return Kq;
        }
    }
}
