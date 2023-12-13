using System;

namespace TrigonometryOperations
{
    public class Trigonometry
    {
        public double sin(double x)
        {
            return Math.Sin(x);
        }
        public double cos(double x)
        {
            return Math.Cos(x);
        }
        public double tan(double x)
        {
            return Math.Tan(x);
        }
        public double cosec(double x)
        {
            return 1.0d/Math.Sin(x);
        }
        public double sec(double x) {
            return 1.0d/Math.Cos(x);
        }
        public double cot(double x)
        {
            return 1.0d / Math.Tan(x);
        }
    }
}