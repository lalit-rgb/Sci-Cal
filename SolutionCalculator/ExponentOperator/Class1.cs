using System;

namespace ExponentOperator
{
    public class Exponent
    {
        public double Power(double i1 , double i2)
        {
            double result = Math.Pow(i1,i2);
            return Math.Round(result, 5);
        }

        public double root(double i1, double i2)
        {
            double result = Math.Pow(i1, 1.0/i2);
            return Math.Round(result, 5);
        }
    }
}