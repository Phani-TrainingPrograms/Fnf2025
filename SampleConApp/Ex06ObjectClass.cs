using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Object is the Universal data type in C#. All data types in C# are derived from Object class. It is a reference type. Object is like void*(Reference) of C/C++.
 * BOXING and UNBOXING are the two important concepts in Object class. Boxing is implicit casting where every type is implicitly converted to Object type. Unboxing is explicit casting where Object type is explicitly converted to the original type. U cannot cast a reference type to a value type without unboxing.  
 */
namespace SampleConApp
{
    internal class Ex06ObjectClass
    {
        static void Main(string[] args)
        {
            object obj = 10; //Boxing - Implicit conversion of any type to object
            Console.WriteLine("The data type is " + obj.GetType().Name);
            obj = "Sample Text";
            Console.WriteLine("The data type is " + obj.GetType().Name);
            obj = 1234.4534f;
            Console.WriteLine("The data type is " + obj.GetType().Name);
            
            //U need to unbox the object to get the original type or perform any operations related to the original type. We unbox an object by explicitly casting it to the original type.
            float f = (float)obj; //Unboxing - Explicit conversion of object to float
            f++;//Now perform any operation on the unboxed value. 
            Console.WriteLine("The unboxed value is " + f);
        }
    }
}
