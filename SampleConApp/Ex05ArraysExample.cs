using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Arrays in C# are used to store multiple values in a single variable, instead of declaring separate variables for each value. They are fixed in size and can hold elements of the same data type. Arrays are reference types in C#. They are objects of a class called System.Array, which provides methods and properties to work with arrays.
 * U can have Single Dimensional Arrays, Multi Dimensional Arrays and Jagged Arrays.
 * Jagged Arrays are arrays of arrays, where each element can have a different size. They are useful when U need to store data in a non-rectangular format. Here U shall have fixed no of rows but each row can have different no of columns.
 */
namespace SampleConApp
{
    internal class Ex05ArraysExample
    {
        static void Main(string[] args)
        {
            //SingleDimensionalArrayExample();
            //MultiDimensionalArrayExample();
            JaggedArrayExample();
        }

        private static void JaggedArrayExample()
        {
            int[][] school = new int[3][]; // Declare a jagged array with 3 rows
            school[0] = new int[5] { 90, 85, 80, 75, 70 }; // Row 0 with 5 columns
            school[1] = new int[4] { 88, 82, 78, 74 }; // Row 1 with 4 columns
            school[2] = new int[3] { 92, 89, 84 }; // Row 2 with 3 columns

            for(int i =0; i < school.Length; i++)
            {
                Console.Write($"Row {i}: ");
                foreach(int no in school[i]) // Iterate through each row
                {
                    Console.Write($"{no} ");
                }
                Console.WriteLine();
            }
        }


        private static void MultiDimensionalArrayExample()
        {
            //Syntax:
            int[,] Marks = new int[4, 5];//4x5 array, 4 rows and 5 columns
            //Assigning values to the array elements
            Marks= new int[,]
            {
                { 90, 85, 80, 75, 70 }, //Row 0
                { 88, 82, 78, 74, 68 }, //Row 1
                { 92, 89, 84, 79, 73 }, //Row 2
                { 95, 90, 85, 80, 75 } //Row 3
            };

            //Display the elements in a Matrix format
            for (int i = 0; i <Marks.GetLength(0); i++)
            {
                for(int j =0; j < Marks.GetLength(1); j++)
                {
                    Console.Write($"{Marks[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        private static void SingleDimensionalArrayExample()
        {
            string[] names = new string[5]; // Declare an array of strings with a size of 5. Index starts from 0 to 4.
            names[0] = "John"; // Assign values to the array elements
            names[1] = "Jane";
            names[2] = "Alice";
            names[3] = "Bob";
            names[4] = "Charlie";

            for(int index = 0; index < names.Length; index++)
            {
                Console.WriteLine(names[index]);
            }

            //Using foreach loop to iterate through the array
            foreach(string name in names) //for.. of of JS
            {
                Console.WriteLine(name);
            }
        }
    }
}
/*
 * Create a Function that creates an array of elements based on the inputs taken from the user.User shall give inputs like size, datatype and elements.
 * The function should return the array and the caller of this function shall display the elements in a formatted way.
 * Find out how to copy the array from one array to another. There are 3 functions to do it. Clone, Copy, CopyTo Find it out and get the differences between them.
 */