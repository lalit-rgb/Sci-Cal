using System;
using System.Text;
using ArithemicOperator;
using ExponentOperator;
using TrigonometryOperations;

namespace Namespace
{
    public class Class3
    {
        public static (double, int) getno(string eq, int i)
        {
            string temporaryString = "";
            bool number = false;
            int index = i;
            while (!number && index < eq.Length)
            {
                if (eq[index] == '+' || eq[index] == '*' || (int)eq[index] == '-' || eq[index] == '/' || eq[index] == '(' || eq[index] == ')' || eq[index] == '^'|| eq[index] == 's' || eq[index] == 'c' || eq[index] == 't' || eq[index] == 'u' || eq[index] == 'i' || eq[index] == 'j')
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

        public static double Execution(ref int OperandsIndex, ref int OperatorsIndex, double[] operands, char[] operators)
        {
            for(int i = OperatorsIndex-1; i>=0;i--)
            {
                Arithemic obj = new Arithemic();
                if (operators[i] == '*')
                {
                    operands[OperandsIndex - 2] = obj.GetMultiplicationValue(operands[OperandsIndex - 2], operands[OperandsIndex - 1]);
                    OperandsIndex--;
                    operators[i] = ' ';
                }
                else if (operators[i] == '/')
                {
                    operands[OperandsIndex - 2] = obj.GetDivisionValue(operands[OperandsIndex - 2], operands[OperandsIndex - 1]);
                    OperandsIndex--;
                    operators[i] = ' ';
                }
                else if (operators[i] == '+')
                {
                    operands[OperandsIndex - 2] = obj.GetAdditionValue(operands[OperandsIndex - 2], operands[OperandsIndex - 1]);
                    OperandsIndex--;
                    operators[i] = ' ';
                }
                else if (operators[i] == '-')
                {
                    operands[OperandsIndex - 2] = obj.GetSubstractionvalue(operands[OperandsIndex - 2], operands[OperandsIndex - 1]);
                    OperandsIndex--;
                    operators[i] = ' ';
                }
                else if (operators[i] == '(')
                {
                    OperatorsIndex = i;
                    operators[i] = ' ';
                    return operands[OperandsIndex - 1];
                }
                else if (operators[i] == '^')
                {
                    Exponent eobj = new Exponent();
                    operands[OperandsIndex - 2] = eobj.Power(operands[OperandsIndex - 2], operands[OperandsIndex - 1]);
                    OperandsIndex--;
                    operators[i] = ' ';
                }
                OperatorsIndex = i;
            }
            return operands[0];
        }

        public delegate void KeyPressedEventHandler(ConsoleKeyInfo keyInfo, ref StringBuilder strings, ref int j);
        public static event KeyPressedEventHandler KeyPressed;
        //Main

        public static void Main(string[] args)
        {
            
            ConsoleKeyInfo cki;
            string[] history = new string[100];
            int historyIndex = 0;
            double result=0;
            bool addToPrevHistory = false;
            KeyPressed += HandleKeys;
            while (true)
            {
                if (historyIndex > 0)
                {
                    Console.Clear();
                    Console.WriteLine("History");
                    for (int inj = historyIndex - 1; inj >= 0; inj--)
                    {
                        Console.WriteLine(history[inj]);
                    }
                }
                Console.WriteLine("enter your equation to compute: ");
                StringBuilder demo = new StringBuilder("");
                int i = 0;
                Console.TreatControlCAsInput = true;
                while (true)
                {
                    cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.OemPlus) break;
                    KeyPressed?.Invoke(cki, ref demo, ref i);
                }
                Console.WriteLine();
                string eq = demo.ToString();
                //Console.WriteLine(eq);
                int capacity = (eq.Length / 2) + 3;
                int operandsIndex = 0, operatorsIndex = 0;
                double[] operands = new double[capacity];
                char[] operators = new char[capacity];
                bool operatorSet = false, prevCharIsAnOperator = false;
                double tempOperand = 0;
                //Console.WriteLine("History Index "+historyIndex+" first element ofthe equation " + eq[0]);
                if (historyIndex > 0 && eq[0] == '+' || historyIndex > 0 && eq[0] == '-' || historyIndex > 0 && eq[0] == '*' || historyIndex > 0 && eq[0] == '/' || historyIndex > 0 && eq[0] == '^')
                {
                    //Console.WriteLine("previous result is" + result);
                    operands[operandsIndex] = result;
                    operandsIndex = operandsIndex + 1;
                    historyIndex = historyIndex - 1;
                    addToPrevHistory = true;
                }

                for (int j = 0; j < eq.Length; j++)
                {
                    /*Console.WriteLine("Operands:");
                    foreach (double x in operands)
                    {
                        Console.Write(x);
                    }
                    Console.WriteLine("operators:");
                    foreach(char x in operators)
                    {
                        Console.Write(x);
                    }*/
                    if (eq[j] == '-')
                    {
                        if (j == 0 && addToPrevHistory)
                        {
                            operators[operatorsIndex] = eq[j];
                            operatorsIndex++;
                            prevCharIsAnOperator = true;
                        }
                        else if (j == 0 || operatorSet == true)
                        {
                            (tempOperand, j) = getno(eq, j + 1);
                            tempOperand = -1 * tempOperand;
                            operands[operandsIndex] = tempOperand;
                            operandsIndex++;
                            prevCharIsAnOperator = false;
                        }
                        else
                        {
                            if (operatorsIndex == 0)
                            {
                                operators[operatorsIndex] = eq[j];
                                operatorsIndex++;
                                prevCharIsAnOperator = true;
                            }
                            else if (operators[operatorsIndex - 1] == '(')
                            {
                                operators[operatorsIndex] = eq[j];
                                operatorsIndex++;
                                prevCharIsAnOperator = true;
                            }
                            else
                            {
                                Arithemic obj = new Arithemic();
                                switch (operators[operatorsIndex - 1])
                                {
                                    case '+':
                                        operands[operandsIndex - 2] = obj.GetAdditionValue(operands[operandsIndex - 2], operands[operandsIndex - 1]);
                                        operandsIndex = operandsIndex - 1;
                                        operators[operatorsIndex - 1] = '-';
                                        prevCharIsAnOperator = true;
                                        break;

                                    case '-':
                                        operands[operandsIndex - 2] = obj.GetSubstractionvalue(operands[operandsIndex - 2], operands[operandsIndex - 1]);
                                        operandsIndex = operandsIndex - 1;
                                        operators[operatorsIndex - 1] = '-';
                                        prevCharIsAnOperator = true;
                                        break;
                                    case '*':
                                        operands[operandsIndex - 2] = obj.GetMultiplicationValue(operands[operandsIndex - 2], operands[operandsIndex - 1]);
                                        operandsIndex = operandsIndex - 1;
                                        operators[operatorsIndex - 1] = '-';
                                        prevCharIsAnOperator = true;
                                        break;
                                    case '/':
                                        operands[operandsIndex - 2] = obj.GetDivisionValue(operands[operandsIndex - 2], operands[operandsIndex - 1]);
                                        operandsIndex = operandsIndex - 1;
                                        operators[operatorsIndex - 1] = '-';
                                        prevCharIsAnOperator = true;
                                        break;
                                }
                            }

                        }
                    }
                    else if (eq[j] == '(')
                    {
                        operators[operatorsIndex] = '(';
                        operatorsIndex = operatorsIndex + 1;

                    }
                    else if (eq[j] == ')')
                    {


                        double res = Execution(ref operandsIndex, ref operatorsIndex, operands, operators);
                        operands[operandsIndex - 1] = res;

                        //Console.WriteLine("operandsIndex, operatorsIndex, operands, operators {0} {1} {2} {3} B", operandsIndex, operatorsIndex, operands, operators);
                    }
                    else if (eq[j] == '+')
                    {
                        if (j == 0 && addToPrevHistory)
                        {
                            operators[operatorsIndex] = eq[j];
                            operatorsIndex++;
                            prevCharIsAnOperator = true;
                        }
                        else if (j == 0 || operatorSet == true)
                        {
                            (tempOperand, j) = getno(eq, j + 1);
                            operands[operandsIndex] = tempOperand;
                            operandsIndex++;
                            prevCharIsAnOperator = false;
                        }
                        else
                        {
                            if (operatorsIndex == 0)
                            {
                                operators[operatorsIndex] = eq[j];
                                operatorsIndex++;
                                prevCharIsAnOperator = true;
                            }
                            else if (operators[operatorsIndex - 1] == '(')
                            {
                                operators[operatorsIndex] = eq[j];
                                operatorsIndex++;
                                prevCharIsAnOperator = true;
                            }
                            else
                            {
                                Arithemic obj = new Arithemic();
                                switch (operators[operatorsIndex - 1])
                                {
                                    case '+':
                                        operands[operandsIndex - 2] = obj.GetAdditionValue(operands[operandsIndex - 2], operands[operandsIndex - 1]);
                                        operandsIndex = operandsIndex - 1;
                                        operators[operatorsIndex - 1] = '+';
                                        prevCharIsAnOperator = true;
                                        break;

                                    case '-':
                                        operands[operandsIndex - 2] = obj.GetSubstractionvalue(operands[operandsIndex - 2], operands[operandsIndex - 1]);
                                        operandsIndex = operandsIndex - 1;
                                        operators[operatorsIndex - 1] = '+';
                                        prevCharIsAnOperator = true;
                                        break;
                                    case '*':
                                        operands[operandsIndex - 2] = obj.GetMultiplicationValue(operands[operandsIndex - 2], operands[operandsIndex - 1]);
                                        operandsIndex = operandsIndex - 1;
                                        operators[operatorsIndex - 1] = '+';
                                        prevCharIsAnOperator = true;
                                        break;
                                    case '/':
                                        operands[operandsIndex - 2] = obj.GetDivisionValue(operands[operandsIndex - 2], operands[operandsIndex - 1]);
                                        operandsIndex = operandsIndex - 1;
                                        operators[operatorsIndex - 1] = '+';
                                        prevCharIsAnOperator = true;
                                        break;
                                }
                            }

                        }
                    }
                    else if (eq[j] == '^')
                    {
                        if (eq[j + 1] == '(')
                        {
                            operators[operatorsIndex] = '^';
                            operatorsIndex++;
                        }
                        else
                        {
                           // Console.WriteLine(operandsIndex + " operandindex and operand at one below index " + operands[operandsIndex]);
                            Exponent eobj = new Exponent();
                            (tempOperand, j) = getno(eq, j + 1);
                            operands[operandsIndex - 1] = eobj.Power(operands[operandsIndex - 1], tempOperand);
                        }
                    }
                    else if (eq[j] == '*')
                    {
                        prevCharIsAnOperator = false;
                        Arithemic obj = new Arithemic();
                        if (j == 0 && !addToPrevHistory)
                        {
                            (tempOperand, j) = getno(eq, j + 1);
                            operands[0] = obj.GetMultiplicationValue(0.0d, tempOperand);
                            operandsIndex++;
                        }
                        else
                        {
                            if (operatorsIndex == 0)
                            {
                                operators[operatorsIndex] = '*';
                                operatorsIndex++;
                            }
                            else
                            {
                                switch (operators[operatorsIndex - 1])
                                {
                                    case '*':
                                        operands[operandsIndex - 2] = obj.GetMultiplicationValue(operands[operandsIndex - 2], operands[operandsIndex - 1]);
                                        operandsIndex = operandsIndex - 1;
                                        operators[operatorsIndex - 1] = '*';
                                        prevCharIsAnOperator = true;
                                        break;
                                    case '/':
                                        operands[operandsIndex - 2] = obj.GetDivisionValue(operands[operandsIndex - 2], operands[operandsIndex - 1]);
                                        operandsIndex = operandsIndex - 1;
                                        operators[operatorsIndex - 1] = '*';
                                        prevCharIsAnOperator = true;
                                        break;
                                    case '^':
                                        Exponent eobj = new Exponent();
                                        operands[operandsIndex - 2] = eobj.Power(operands[operandsIndex - 2], operands[operandsIndex - 1]);
                                        operandsIndex = operandsIndex - 1;
                                        operators[operatorsIndex - 1] = '*';
                                        prevCharIsAnOperator = true;
                                        break;
                                    default:
                                        operators[operatorsIndex] = '*';
                                        operatorsIndex++;
                                        break;
                                }
                            }
                        }
                    }
                    else if (eq[j] == 's')
                    {
                        Trigonometry tobj = new Trigonometry();
                        if(operandsIndex == 0)
                        {
                            operands[operandsIndex - 1] = 0;
                        }
                        else
                        {
                            operands[operandsIndex-1]= tobj.sin(operands[operandsIndex - 1]);
                        }
                    }
                    else if (eq[j] == 'c')
                    {
                        Trigonometry tobj = new Trigonometry();
                        if (operandsIndex == 0)
                        {
                            operands[operandsIndex - 1] = 1;
                        }
                        else
                        {
                            operands[operandsIndex - 1] = tobj.cos(operands[operandsIndex - 1]);
                        }
                    }
                    else if (eq[j] == 't')
                    {
                        Trigonometry tobj = new Trigonometry();
                        if (operandsIndex == 0)
                        {
                            operands[operandsIndex - 1] = 0;
                        }
                        else
                        {
                            operands[operandsIndex - 1] = tobj.tan(operands[operandsIndex - 1]);
                        }
                    }
                    else if (eq[j] == 'u')
                    {
                        Trigonometry tobj = new Trigonometry();
                        if (operandsIndex == 0)
                        {
                            operands[operandsIndex - 1] = 1;
                        }
                        else
                        {
                            operands[operandsIndex - 1] = tobj.sec(operands[operandsIndex - 1]);
                        }
                    }
                    else if (eq[j] == 'i')
                    {
                        Trigonometry tobj = new Trigonometry();
                        if (operandsIndex == 0)
                        {
                            operands[operandsIndex - 1] = 0;
                        }
                        else
                        {
                            operands[operandsIndex - 1] = tobj.cosec(operands[operandsIndex - 1]);
                        }
                    }
                    else if (eq[j] == 'j')
                    {
                        Trigonometry tobj = new Trigonometry();
                        if (operandsIndex == 0)
                        {
                            operands[operandsIndex - 1] = 0;
                        }
                        else
                        {
                            operands[operandsIndex - 1] = tobj.cot(operands[operandsIndex - 1]);
                        }
                    }
                    else if (eq[j] == '/')
                    {
                        prevCharIsAnOperator = false;
                        Arithemic obj = new Arithemic();
                        if (j == 0 && !addToPrevHistory)
                        {
                            (tempOperand, j) = getno(eq, j + 1);
                            operands[0] = obj.GetDivisionValue(0.0d, tempOperand);
                            operandsIndex++;
                        }
                        else
                        {
                            if (operatorsIndex == 0)
                            {
                                operators[operatorsIndex] = '/';
                                operatorsIndex++;
                            }
                            else
                            {
                                switch (operators[operatorsIndex - 1])
                                {
                                    case '*':
                                        operands[operandsIndex - 2] = obj.GetMultiplicationValue(operands[operandsIndex - 2], operands[operandsIndex - 1]);
                                        operandsIndex = operandsIndex - 1;
                                        operators[operatorsIndex - 1] = '/';
                                        prevCharIsAnOperator = true;
                                        break;
                                    case '/':
                                        operands[operandsIndex - 2] = obj.GetDivisionValue(operands[operandsIndex - 2], operands[operandsIndex - 1]);
                                        operandsIndex = operandsIndex - 1;
                                        operators[operatorsIndex - 1] = '/';
                                        prevCharIsAnOperator = true;
                                        break;
                                    case '^':
                                        Exponent eobj = new Exponent();
                                        operands[operandsIndex - 2] = eobj.Power(operands[operandsIndex - 2], operands[operandsIndex - 1]);
                                        operandsIndex = operandsIndex - 1;
                                        operators[operatorsIndex - 1] = '/';
                                        prevCharIsAnOperator = true;
                                        break;
                                    default:
                                        operators[operatorsIndex] = '/';
                                        operatorsIndex++;
                                        break;
                                }
                            }
                        }
                    }
                    else
                    {
                        (tempOperand, j) = getno(eq, j);
                        operands[operandsIndex] = tempOperand;
                        operandsIndex++;
                        prevCharIsAnOperator = false;
                    }

                }
                result = Execution(ref operandsIndex, ref operatorsIndex, operands, operators);
                Console.WriteLine("result is: " + result);
                if (addToPrevHistory)
                {
                    string tempHist = (history[historyIndex]+ eq + " " + result.ToString());
                    history[historyIndex] = tempHist;
                    historyIndex = historyIndex+ 1;
                    addToPrevHistory = false;
                }
                else
                {
                    string tempHist = (eq + " " + result.ToString());
                    history[historyIndex] = tempHist;
                    historyIndex = historyIndex + 1;
                }
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Escape) break;
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
                        Console.Write(" <=sin-1");
                        s.Insert(j, "S");
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
                        Console.Write(" <=sin");
                        s.Insert(j, "s");
                        j = j + 1;
                        break;
                    case ConsoleKey.T:
                        Console.Write(" <=tan");
                        s.Insert(j, "t");
                        j = j + 1;
                        break;
                    case ConsoleKey.O:
                        Console.Write(" <=cos");
                        s.Insert(j, "c");
                        j = j + 1;
                        break;
                    case ConsoleKey.U:
                        Console.Write(" <=sec");
                        s.Insert(j, "u");
                        j = j + 1;
                        break;
                    case ConsoleKey.I:
                        Console.Write(" <=cosec");
                        s.Insert(j, "i");
                        j = j + 1;
                        break;
                    case ConsoleKey.J:
                        Console.Write(" <=cot");
                        s.Insert(j, "j");
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
                        if (j != 0)
                        {
                            if (s[j - 1] == '-' || s[j - 1] == '*' || s[j - 1] == '/' || s[j - 1] == '+')
                            {
                                s.Remove(j - 1, 1);
                                j = j - 1;
                                Console.Write("\b \b");
                                Console.Write("*");
                                s.Insert(j, "*");
                                j = j + 1;
                            }
                            else
                            {
                                Console.Write("*");
                                s.Insert(j, "*");
                                j = j + 1;
                            }
                        }
                        else
                        {
                            Console.Write("*");
                            s.Insert(j, "*");
                            j = j + 1;
                        }
                        break;
                    case ConsoleKey.Divide:
                        if (j != 0)
                        {
                            if (s[j - 1] == '-' || s[j - 1] == '*' || s[j - 1] == '/' || s[j - 1] == '+')
                            {
                                s.Remove(j - 1, 1);
                                j = j - 1;
                                Console.Write("\b \b");
                                Console.Write("/");
                                s.Insert(j, "/");
                                j = j + 1;
                            }
                            else
                            {
                                Console.Write("/");
                                s.Insert(j, "/");
                                j = j + 1;
                            }
                        }
                        else
                        {
                            Console.Write("/");
                            s.Insert(j, "/");
                            j = j + 1;
                        }
                        break;
                    case ConsoleKey.Add:

                        //Console.WriteLine("entered");
                        if (j != 0)
                        {
                            if (s[j - 1] == '-' || s[j - 1] == '*' || s[j - 1] == '/' || s[j - 1] == '+')
                            {
                                s.Remove(j - 1, 1);
                                j = j - 1;
                                Console.Write("\b \b");
                                Console.Write("+");
                                s.Insert(j, "+");
                                j = j + 1;
                            }
                            else
                            {
                                Console.Write("+");
                                s.Insert(j, "+");
                                j = j + 1;
                            }
                        }
                        else
                        {
                            Console.Write("+");
                            s.Insert(j, "+");
                            j = j + 1;
                        }
                        break;
                    case ConsoleKey.Subtract:

                        if (j != 0)
                        {
                            if (s[j - 1] == '-' || s[j - 1] == '*' || s[j - 1] == '/' || s[j - 1] == '+')
                            {
                                s.Remove(j - 1, 1);
                                j = j - 1;
                                Console.Write("\b \b");
                                Console.Write("-");
                                s.Insert(j, "-");
                                j = j + 1;
                            }
                            else
                            {
                                Console.Write("-");
                                s.Insert(j, "-");
                                j = j + 1;
                            }
                        }
                        else
                        {
                            Console.Write("-");
                            s.Insert(j, "-");
                            j = j + 1;
                        }
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