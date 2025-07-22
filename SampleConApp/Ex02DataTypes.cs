using System;//Root namespace for all the data types and basic coding of C#. 
namespace SampleConApp
{
    /*
     * All data types in C# are based on Common Type System(CTS) of .NET Framework. 
     * CTS provides a common set of data types for all languages of .NET.
     * They are broadly classified as primitive types(Structs) and reference types(classes). 
     * Primitive types or known types are data types that are common among all languages: They are also called as VALUE TYPES.
     * Integral Types: byte(2 Bit), short(16), int(32), long(64) 
     * Floating Types: float(Single), double(Double), decimal(128Bit)
     * Other Types: Char(2 Bytes), Bool(1 Byte). Tuples.  
     * User Defined Types: Enums, Structs... 
     * Reference types are classes: Arrays, Delegates, Normal Classes that U create and are available in .NET framework. 
     * Value type variables directly store the value in them. Reference types store the location of the value as the value shall be created in the heap managed by the .NET Runtime.
     * Classes are available to convert one type to another. Some types cannot be converted at compile time. 
     * Larger types can hold smaller type values, but its reverse needs explicit or forceful conversions(CASTING).
     * Due to CTS, the data type conversions among the languages of the .NET is possible. All data types of all the programming languages are from CTS only. 
     */
	class Ex02DataTypes
	{
        static void Main()
        {
            int iVal = 123;
            long lVal = 234324343;
            float fValue = 234.45f;
            double dValue = 23434.2344;
            char strText = 'a';//Use single quotes. 
            bool bValue = true;

            Console.WriteLine("The Value of iVal is {0}\nThe Value of lVal is {1}\nThe Value of fVal is {2}\nThe Value of dVal is {3}\nThe Value of strText is {4}\nThe Value of bVal is {5}\n{0} is smallerrange compared to {1}", iVal, lVal, fValue, dValue, strText, bValue);
        }

        static void DisplayUserDetails()
        {
            Console.WriteLine("Enter the Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the Age");
            //get the string and later convert it to int. 
            int iAge = int.Parse(Console.ReadLine());//Parse method is found in every Value type. The function converts the string to its Type. 

            Console.WriteLine("Enter UR mobile no");
            long lMobile = long.Parse(Console.ReadLine());

            //Display the data on the Console..
        }

        
        static void TypecastingExample() 
        {
            //Convert from int to long. 
            int iVal = 123;
            long lVal = iVal; //Implicit conversion from int to long.
            double dVal = 123.45; //Implicit conversion from int to double.
            lVal = (long)dVal; //Explicit conversion from double to long.
            //U can use Convert class to convert from one type to another. This is more safe than casting. If the casting is not possible, it throws an exception.
            lVal = Convert.ToInt64(dVal); //Convert class is available in System namespace. It has methods to convert from one type to another.
        }
    }
}