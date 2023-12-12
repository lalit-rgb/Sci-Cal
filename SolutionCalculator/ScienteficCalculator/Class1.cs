using System;
using System.Text;
using System.Text.RegularExpressions;
using ArithemicOperator;
using ExponentOperator;

namespace ScienteficCalculator
{
    internal class Class1
    {
        public static (double, int) getno(string eq, int i)
        {
            string temporaryString = "";
            bool number = false;
            int index = i;
            while (!number && index < eq.Length)
            {
                if (eq[index] == '+' || eq[index] == '*' || (int)eq[index] == '-' || eq[index] == '/' || eq[index] == '(' || eq[index] == ')')
                {
                    number = true;
                    continue;
                }
                else
                {
                    temporaryString += eq[index];
                }
                index++;
            }
            double finalOperand = Convert.ToDouble(temporaryString);
            return (finalOperand, index - 1);
        }

        public delegate void KeyPressedEventHandler(ConsoleKeyInfo keyInfo, ref StringBuilder strings, ref int j);
        public static event KeyPressedEventHandler KeyPressed;


        // Main Method
        public static void Main(string[] args)
        {
            
            StringBuilder demo = new StringBuilder("");
            int i = 0;
            Console.TreatControlCAsInput = true;
            ConsoleKeyInfo cki;
            Console.TreatControlCAsInput = true;
            Console.Write("Press any key, or 'ESC' to quit, or ");
            KeyPressed += HandleKeys;
            while (true)
            {
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.OemPlus || cki.Key == ConsoleKey.Enter) break;
                KeyPressed?.Invoke(cki, ref demo, ref i);
            }
            Console.WriteLine();
            Console.WriteLine(demo);
            string eq = demo.ToString();
            int capacity = (eq.Length / 2) + 3;
            int operandsIndex = 0, operatorsIndex = 0;
            string[] operands = new string[capacity];
            char[] operators = new char[capacity];
            bool operatorSet = false, prevCharIsAnOperator=false;
            double tempOperand = 0;

            for(int j=0; j<eq.Length; j++)
            {
                if (eq[j] == '-')
                {
                    if(j ==0 || operatorSet == true)
                    {
                        (tempOperand,j) = getno(eq,j+1);
                        tempOperand = -1 * tempOperand;
                        operands[operandsIndex] = tempOperand.ToString();
                        operandsIndex++;
                        prevCharIsAnOperator = false;
                    }
                    else
                    {
                        if(operatorsIndex == 0)
                        {
                            operators[operatorsIndex] = eq[j];
                            operatorsIndex++;
                        }
                        else if (operators[operatorsIndex-1] == '(')
                        {
                            operators[operatorsIndex] = eq[j];
                            operatorsIndex++;
                        }
                        else
                        {
                            switch(operators[operatorsIndex - 1])
                            {
                                case '+':
                                    //ArithemicOperator obj = new ArithemicOperator();
                                case '-':
                                    break;
                            }
                        }

                    }
                }
            }
        }


        public static void HandleKeys(ConsoleKeyInfo keyInfo, ref StringBuilder s, ref int j)
        {
            string specialCharecters = keyInfo.Modifiers.ToString();
            // Check for specific key combinations
            if (specialCharecters == "Control")
            {

                switch (keyInfo.Key)
                {
                    case ConsoleKey.M:
                        Console.Write($" Ctrl + {keyInfo.Key} ");
                        s.Insert(j, $" Ctrl + {keyInfo.Key} ");
                        j = j + 1;
                        break;
                    case ConsoleKey.P:
                        Console.Write($" Ctrl + {keyInfo.Key} ");
                        s.Insert(j, $" Ctrl + {keyInfo.Key} ");
                        j = j + 1;
                        break;
                    case ConsoleKey.Q:
                        Console.Write($" Ctrl + {keyInfo.Key} ");
                        s.Insert(j, $" Ctrl + {keyInfo.Key} ");
                        j = j + 1;
                        break;
                    case ConsoleKey.R:
                        Console.Write($" Ctrl + {keyInfo.Key} ");
                        s.Insert(j, $" Ctrl + {keyInfo.Key} ");
                        j = j + 1;
                        break;
                    case ConsoleKey.L:
                        Console.Write($" Ctrl + {keyInfo.Key} ");
                        s.Insert(j, $" Ctrl + {keyInfo.Key} ");
                        j = j + 1;
                        break;
                    case ConsoleKey.G:
                        Console.Write($" Ctrl + {keyInfo.Key} ");
                        s.Insert(j, $" Ctrl + {keyInfo.Key} ");
                        j = j + 1;
                        break;
                    case ConsoleKey.S:
                        Console.Write($" Ctrl + {keyInfo.Key} ");
                        s.Insert(j, $" Ctrl + {keyInfo.Key} ");
                        j = j + 1;
                        break;
                    case ConsoleKey.T:
                        Console.Write($" Ctrl + {keyInfo.Key} ");
                        s.Insert(j, $" Ctrl + {keyInfo.Key} ");
                        j = j + 1;
                        break;
                    case ConsoleKey.O:
                        Console.Write($" Ctrl + {keyInfo.Key} ");
                        s.Insert(j, $" Ctrl + {keyInfo.Key} ");
                        j = j + 1;
                        break;
                    case ConsoleKey.U:
                        Console.Write($" Ctrl + {keyInfo.Key} ");
                        s.Insert(j, $" Ctrl + {keyInfo.Key} ");
                        j = j + 1;
                        break;
                    case ConsoleKey.I:
                        Console.Write($" Ctrl + {keyInfo.Key} ");
                        s.Insert(j, $" Ctrl + {keyInfo.Key} ");
                        j = j + 1;
                        break;
                    case ConsoleKey.J:
                        Console.Write($" Ctrl + {keyInfo.Key} ");
                        s.Insert(j, $" Ctrl + {keyInfo.Key} ");
                        j = j + 1;
                        break;
                    case ConsoleKey.Y:
                        Console.Write($" Ctrl + {keyInfo.Key} ");
                        s.Insert(j, $" Ctrl + {keyInfo.Key} ");
                        j = j + 1;
                        break;
                    case ConsoleKey.N:
                        Console.Write($" Ctrl + {keyInfo.Key} ");
                        s.Insert(j, $" Ctrl + {keyInfo.Key} ");
                        j = j + 1;
                        break;
                }
            }
            else if (specialCharecters == "Shift")
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.S:
                        Console.Write($" Shift + {keyInfo.Key} ");
                        s.Insert(j, $" Shift + {keyInfo.Key} ");
                        j = j + 1;
                        break;
                    case ConsoleKey.T:
                        Console.Write($" Shift + {keyInfo.Key} ");
                        s.Insert(j, $" Shift + {keyInfo.Key} ");
                        j = j + 1;
                        break;
                    case ConsoleKey.O:
                        Console.Write($" Shift + {keyInfo.Key} ");
                        s.Insert(j, $" Shift + {keyInfo.Key} ");
                        j = j + 1;
                        break;
                    case ConsoleKey.U:
                        Console.Write($" Shift + {keyInfo.Key} ");
                        s.Insert(j, $" Shift + {keyInfo.Key} ");
                        j = j + 1;
                        break;
                    case ConsoleKey.I:
                        Console.Write($" Shift + {keyInfo.Key} ");
                        s.Insert(j, $" Shift + {keyInfo.Key} ");
                        j = j + 1;
                        break;
                    case ConsoleKey.J:
                        Console.Write($" Shift + {keyInfo.Key} ");
                        s.Insert(j, $" Shift + {keyInfo.Key} ");
                        j = j + 1;
                        break;
                    case ConsoleKey.L:
                        Console.Write($" Shift + {keyInfo.Key} ");
                        s.Insert(j, $" Shift + {keyInfo.Key} ");
                        j = j + 1;
                        break;
                }
            }
            else if (specialCharecters == "Shift, Control")
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.S:
                        Console.Write($" Control + Shift + {keyInfo.Key} ");
                        s.Insert(j, $" Control + Shift + {keyInfo.Key} ");
                        j = j + 1;
                        break;
                    case ConsoleKey.T:
                        Console.Write($" Control + Shift + {keyInfo.Key} ");
                        s.Insert(j, $" Control + Shift + {keyInfo.Key} ");
                        j = j + 1;
                        break;
                    case ConsoleKey.O:
                        Console.Write($" Control + Shift + {keyInfo.Key} ");
                        s.Insert(j, $" Control + Shift + {keyInfo.Key} ");
                        j = j + 1;
                        break;
                    case ConsoleKey.U:
                        Console.Write($" Control + Shift + {keyInfo.Key} ");
                        s.Insert(j, $" Control + Shift + {keyInfo.Key} ");
                        j = j + 1;
                        break;
                    case ConsoleKey.I:
                        Console.Write($" Control + Shift + {keyInfo.Key} ");
                        s.Insert(j, $" Control + Shift + {keyInfo.Key} ");
                        j = j + 1;
                        break;
                    case ConsoleKey.J:
                        Console.Write($" Control + Shift + {keyInfo.Key} ");
                        s.Insert(j, $" Control + Shift + {keyInfo.Key} ");
                        j = j + 1;
                        break;
                }
            }
            else
            {

                // Handle other special keys
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Delete:
                        s.Remove(j - 1, 1);
                        j = j - 1;
                        break;
                    case ConsoleKey.Backspace:
                        s.Remove(j - 1, 1);
                        j = j - 1;
                        Console.Write("\b \b");
                        break;
                    /*case ConsoleKey.Escape:
                        s.Insert(j, $"{keyInfo.Key}");
                        j = j + 1;
                        break;*/
                    case ConsoleKey.F9:
                        Console.Write($"{keyInfo.Key}");
                        s.Insert(j, $"{keyInfo.Key}");
                        j = j + 1;
                        break;
                    case ConsoleKey.R:
                        Console.Write($"{keyInfo.Key}");
                        s.Insert(j, $"{keyInfo.Key}");
                        j = j + 1;
                        break;
                    case ConsoleKey.D2:
                        Console.Write($"{keyInfo.Key}");
                        s.Insert(j, $"{keyInfo.Key}");
                        j = j + 1;
                        break;
                    case ConsoleKey.D5:
                        Console.Write($"{keyInfo.Key}");
                        s.Insert(j, $"{keyInfo.Key}");
                        j = j + 1;
                        break;
                    case ConsoleKey.DownArrow:
                        Console.Write($"{keyInfo.Key}");
                        s.Insert(j, $"{keyInfo.Key}");
                        j = j + 1;
                        break;
                    case ConsoleKey.UpArrow:
                        Console.Write($"{keyInfo.Key}");
                        s.Insert(j, $"{keyInfo.Key}");
                        j = j + 1;
                        break;
                    case ConsoleKey.F3:
                        Console.Write($"{keyInfo.Key}");
                        s.Insert(j, $"{keyInfo.Key}");
                        j = j + 1;
                        break;
                    case ConsoleKey.F4:
                        Console.Write($"{keyInfo.Key}");
                        s.Insert(j, $"{keyInfo.Key}");
                        j = j + 1;
                        break;
                    case ConsoleKey.F5:
                        Console.Write($"{keyInfo.Key}");
                        s.Insert(j, $"{keyInfo.Key}");
                        j = j + 1;
                        break;
                    case ConsoleKey.G:
                        Console.Write($"{keyInfo.Key}");
                        s.Insert(j, $"{keyInfo.Key}");
                        j = j + 1;
                        break;
                    case ConsoleKey.S:
                        Console.Write($"{keyInfo.Key}");
                        s.Insert(j, $"{keyInfo.Key}");
                        j = j + 1;
                        break;
                    case ConsoleKey.T:
                        Console.Write($"{keyInfo.Key}");
                        s.Insert(j, $"{keyInfo.Key}");
                        j = j + 1;
                        break;
                    case ConsoleKey.O:
                        Console.Write($"{keyInfo.Key}");
                        s.Insert(j, $"{keyInfo.Key}");
                        j = j + 1;
                        break;
                    case ConsoleKey.U:
                        Console.Write($"{keyInfo.Key}");
                        s.Insert(j, $"{keyInfo.Key}");
                        j = j + 1;
                        break;
                    case ConsoleKey.I:
                        Console.Write($"{keyInfo.Key}");
                        s.Insert(j, $"{keyInfo.Key}");
                        j = j + 1;
                        break;
                    case ConsoleKey.J:
                        Console.Write($"{keyInfo.Key}");
                        s.Insert(j, $"{keyInfo.Key}");
                        j = j + 1;
                        break;
                    case ConsoleKey.M:
                        Console.Write($"{keyInfo.Key}");
                        s.Insert(j, $"{keyInfo.Key}");
                        j = j + 1;
                        break;
                    case ConsoleKey.N:
                        Console.Write($"{keyInfo.Key}");
                        s.Insert(j, $"{keyInfo.Key}");
                        j = j + 1;
                        break;
                    case ConsoleKey.P:
                        Console.Write($"{keyInfo.Key}");
                        s.Insert(j, $"{keyInfo.Key}");
                        j = j + 1;
                        break;
                    case ConsoleKey.Q:
                        Console.Write($"{keyInfo.Key}");
                        s.Insert(j, $"{keyInfo.Key}");
                        j = j + 1;
                        break;
                    case ConsoleKey.V:
                        Console.Write($"{keyInfo.Key}");
                        s.Insert(j, $"{keyInfo.Key}");
                        j = j + 1;
                        break;
                    case ConsoleKey.X:
                        Console.Write($"{keyInfo.Key}");
                        s.Insert(j, $"{keyInfo.Key}");
                        j = j + 1;
                        break;
                    case ConsoleKey.D6:
                        Console.Write("^");
                        s.Insert(j, "^");
                        j = j + 1;
                        break;
                    case ConsoleKey.D3:
                        Console.Write($"{keyInfo.Key}");
                        s.Insert(j, $"{keyInfo.Key}");
                        j = j + 1;
                        break;
                    case ConsoleKey.D1:
                        Console.Write($"{keyInfo.Key}");
                        s.Insert(j, $"{keyInfo.Key}");
                        j = j + 1;
                        break;
                    case ConsoleKey.NumPad0:
                        Console.Write("0");
                        s.Insert(j, "0");
                        j = j + 1;
                        break;
                    case ConsoleKey.NumPad1:
                        Console.Write("1");
                        s.Insert(j, "1");
                        j = j + 1;
                        break;
                    case ConsoleKey.NumPad2:
                        Console.Write("2");
                        s.Insert(j, "2");
                        j = j + 1;
                        break;
                    case ConsoleKey.NumPad3:
                        Console.Write("3");
                        s.Insert(j, "3");
                        j = j + 1;
                        break;
                    case ConsoleKey.NumPad4:
                        Console.Write("4");
                        s.Insert(j, "4");
                        j = j + 1;
                        break;
                    case ConsoleKey.NumPad5:
                        Console.Write("5");
                        s.Insert(j, "5");
                        j = j + 1;
                        break;
                    case ConsoleKey.NumPad6:
                        Console.Write("6");
                        s.Insert(j, "6");
                        j = j + 1;
                        break;
                    case ConsoleKey.NumPad7:
                        Console.Write("7");
                        s.Insert(j, "7");
                        j = j + 1;
                        break;
                    case ConsoleKey.NumPad8:
                        Console.Write("8");
                        s.Insert(j, "8");
                        j = j + 1;
                        break;
                    case ConsoleKey.NumPad9:
                        Console.Write("9");
                        s.Insert(j, "9");
                        j = j + 1;
                        break;
                    case ConsoleKey.OemPeriod:
                        Console.Write(".");
                        s.Insert(j, ".");
                        j = j + 1;
                        break;
                    case ConsoleKey.Multiply:
                        Console.Write("x");
                        s.Insert(j, "x");
                        j = j + 1;
                        break;
                    case ConsoleKey.Divide:
                        Console.Write("/");
                        s.Insert(j, "/");
                        j = j + 1;
                        break;
                    case ConsoleKey.Add:
                        Console.Write("+");
                        //Console.WriteLine("entered");
                        s.Insert(j, "+");
                        j = j + 1;
                        break;
                    case ConsoleKey.Subtract:
                        Console.Write("-");
                        s.Insert(j, "-");
                        j = j + 1;
                        break;
                    case ConsoleKey.D9:
                        Console.Write("(");
                        s.Insert(j, "(");
                        j = j + 1;
                        break;
                    case ConsoleKey.D0:
                        Console.Write(")");
                        s.Insert(j, ")");
                        j = j + 1;
                        break;
                }
            }
        }


        }
}



