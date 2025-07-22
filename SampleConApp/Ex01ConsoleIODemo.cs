using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Console is a .NET Class that represents the Console IO of the OS. 
 * It has static methods and properties that can be called to perform IO operations on the Console. 
 * User inputs are captured using a method ReadLine and it returns string. 
 * User outputs are displayed in the Console using WriteLine.
 * Main class can be selected from the Properties Dialog. 
 * U can have multiple Mains in UR project but U should set at the compile time Ur entry point class.
 */
namespace SampleConApp
{
    internal class Ex01ConsoleIODemo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the Address");
            string address = Console.ReadLine();

            Console.WriteLine($"The Inputs are as follows: \nThe Name entered is {name}\nThe Address is {address}");
        }
    }
}
