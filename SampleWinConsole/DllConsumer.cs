using SampleLib;
using System;//Use the namespace
//When U want to consume a DLL, U must add the reference of the DLL into the Application. DLLs cannot run by themselves. They must be a part of the EXE.
//U can right click on the references and browse to the location of the dll and add it. 
namespace SampleWinConsole
{
    internal class DllConsumer
    {
        static void Main(string[] args)
        {
            var mathComponent = new MathClass { FirstValue = 123, SecondValue = 23 };
            var addedValue = mathComponent.AddFunc();
            Console.WriteLine($"The Added value is {addedValue}");
            Console.WriteLine($"The Subtracted value is {mathComponent.Subtract()}");
            Console.WriteLine($"The Multiplied value is {mathComponent.Multiply()}");
            Console.WriteLine($"The Divided value is {mathComponent.Divide()}");
            Console.WriteLine($"The Square value is {mathComponent.SquareOfNumber()}");
            Console.WriteLine($"The Square Root value is {mathComponent.SquareRoot()}");
        }
    }
}
