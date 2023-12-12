using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithemicOperator
{
    public class Arithemic
    {
        public double GetAdditionValue(double i1, double i2)
        {
            return Math.Round(i1 + i2 , 5);
        }
        public double GetDivisionValue(double i1, double i2)
        {
            return Math.Round(i1 / i2, 5);
            
        } 
        public double GetMultiplicationValue(double i1, double i2)
        {
            return Math.Round(i1 * i2, 5);
        }
        public double GetSubstractionvalue(double i1, double i2)
        {
            return Math.Round(i1 - i2, 5);
        }
        public double GetModValue(double i1, double i2)
        {
            return Math.Round(i1 % i2, 5);
        }
    }
}
