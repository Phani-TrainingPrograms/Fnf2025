using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Enums are User Defined Data Types(UDTs) that are used to define Named Constants. If U have a set of related constants, you can use an enum to define them in a single type.
 * All Enum values are internally of type int, but you can specify a different underlying type if needed and it should be integral type only.
 * 
 */
namespace SampleConApp
{
    
    ///<summary>
    /// Represents the days of the week as an enumeration.
    /// The underlying type is <see cref="int"/>.
    /// </summary>
    enum Days //Default its int, U can make it long, byte, short etc.
    {
        /// <summary>
        /// Represents Sunday. Value = 1.
        /// </summary>
        Sunday = 1,
        /// <summary>
        /// Represents Monday. Value = 2.
        /// </summary>
        Monday,
        /// <summary>
        /// Represents Tuesday. Value = 3.
        /// </summary>
        Tuesday,
        /// <summary>
        /// Represents Wednesday. Value = 4.
        /// </summary>
        Wednesday,
        /// <summary>
        /// Represents Thursday. Value = 5.
        /// </summary>
        Thursday,
        /// <summary>
        /// Represents Friday. Value = 6.
        /// </summary>
        Friday,
        /// <summary>
        /// Represents Saturday. Value = 7.
        /// </summary>
        Saturday
    }
    /// <summary>
    /// Demonstrates the usage of the <see cref="Days"/> enum.
    /// </summary>
    internal class EnumsExample
    {
        /// <summary>
        /// The entry point of the application. Demonstrates enum usage, value retrieval, and parsing.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            Days d1 = Days.Wednesday;
            Console.WriteLine($"The selected date is {d1} and its integral value is {(int) d1}. Its internal data type is {d1.GetTypeCode()}");

            Console.WriteLine("Enter the day from the List below U want to start work");
            Array values = Enum.GetValues(typeof(Days));//Gets the values of the enum. The Enum reference is obtained using typeof operator.
            foreach(var value in values) //Iterate thru the values of the array
            {
                Console.WriteLine(value);//display each item 
            }
            string dayInput = Console.ReadLine();
            Days day = Enum.Parse<Days>(dayInput); // true for case-insensitive parsing
            Console.WriteLine("The selected day is " + day);
        }
    }
}
