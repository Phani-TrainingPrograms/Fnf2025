using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    internal class Ex07TuplesExample
    {
        static void Main(string[] args)
        {
            var myExample = (45, "MyName");
            Console.WriteLine($"First Item: {myExample.Item1}, Second Item: {myExample.Item2}");
            Console.WriteLine("The data type is " + myExample.GetType().Name);

            //U can have named tuples as well
            var person = (Name: "John", Age: 30, City: "New York");
            Console.WriteLine($"Name: {person.Name} from {person.City} and is aged {person.Age}");

            var (longit, latid) = GetCoordinates();
            Console.WriteLine($"The Coordinates are ({longit}, {latid})");
        }

        /// <summary>
        /// Implements a method that returns a tuple with two double values representing coordinates.
        /// </summary>
        /// <returns>A combined values of 2 double data.</returns>
        static (double, double) GetCoordinates()
        {
            // This method returns a tuple with two double values
            return (12.34, 56.78);
        }
    }
}
