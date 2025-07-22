using System;
//Todo: Create a Arithematic Calc Program taking inputs from the User:
//2 Values to add, subtract, multiply or divide.
//Option to select add, subtract, multiply or divide
//Display the result on the Console. 

namespace SampleConApp
{
    internal class Ex03CalcProgram
    {
        static string GetStringValue(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
        static double GetDoubleValue(string question)
        {
            Console.WriteLine(question);
            string result = Console.ReadLine();
            return double.Parse(result);//Converted from string to double.   
        }

        static double GetResult(double val1, double val2, string operand)
        {
            switch(operand)
            {
                case "+": return val1 + val2;
                case "-": return val1 - val2;
                case "X": return val1 * val2;
                case "/": return val1 / val2;
                default:
                    Console.WriteLine("Invalid Choice");
                    return 0;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Calc Program");
            bool processing = false;
            do
            {
                Console.Clear();
                double val1 = GetDoubleValue("Enter the First Value");
                
                double val2 = GetDoubleValue("Enter the second Value");

                string operand = GetStringValue("Enter the Operands as + or - or X or /").ToUpper();

                double result = GetResult(val1, val2, operand);
                
                Console.WriteLine("The result: {0}", result);

                string choice = GetStringValue("Press Y to continue or N to quit");
                processing = choice.ToUpper() == "Y" ? true : false;
            } while(processing);
        }
    }
}
