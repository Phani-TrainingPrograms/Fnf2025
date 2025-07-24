using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    //In C#, U can have multiple interfaces implemented at the same level.
    interface IExample
    {
        void ShowExample(); 
    }

    interface IExample2
    {
        void ShowExample();
    }
    interface ISimple
    {

        void ShowSimple();  
    }

    //class SimpleExample : IExample, ISimple//Multiple interface implementation
    //{
    //    public void ShowExample()
    //    {
    //        Console.WriteLine("This is an example of implementing multiple interfaces.");
    //    }
    //    public void ShowSimple()
    //    {
    //        Console.WriteLine("This is a simple implementation of an interface.");
    //    }
    //}

    class ExampleSquare : IExample, IExample2
    {
        public void ShowExample()
        {
            Console.WriteLine("This is an std implementation of ShowExample Method");
        }
        //We shall implement the interface methods Explicitly to avoid ambiguity. 
        void IExample2.ShowExample()
        {
            Console.WriteLine("This is an explicit implementation of ShowExample Method for IExample2");
        }

        void IExample.ShowExample()
        {
            Console.WriteLine("This is an explicit implementation of ShowExample Method for IExample");
        }
    }
    internal class Ex13AdvancedInterfaceConcepts
    {
        static void Main(string[] args)
        {
            /*******************First Example of Interface Implementation*******************/
            //IExample obj = new SimpleExample(); //Using interface reference to hold the object of the class implementing the interface
            //obj.ShowExample(); //Calling the method defined in the interface

            //ISimple simpleObj = new SimpleExample(); //Using another interface reference
            //simpleObj.ShowSimple(); //Calling the method defined in the second interface

            /*******************Second Example of Interface Implementation*******************/
            IExample obj = new ExampleSquare(); //Using interface reference to hold the object of the class implementing the interface
            obj.ShowExample(); //Calling the method defined in the interface

            IExample2 example2 = (IExample2)obj; //Upcasting to IExample2 interface
            example2.ShowExample(); //Calling the method defined in the IExample2 interface

            ExampleSquare exampleSquare = new ExampleSquare();
            exampleSquare.ShowExample(); //Calling the method defined in the IExample interface



        }
    }
}
