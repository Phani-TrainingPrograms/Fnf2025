//Functions or methods allow to have parameters in them.
//C# supports different types of parameters: ref, out, params, and normal parameters.
//out parameter value is assigned inside the function and the ref parameter initialized before passing it to the function.
//params allows you to pass a variable number of arguments to a method. There can be only one params parameter in a method, and it must be the last parameter in the method signature. U cannot have both ref and params parameters in the same method signature.

namespace SampleConApp
{
    internal class Ex16ParametersDemo
    {
        //Lambda Methods are methods with a single expression that can be used to create delegates or expression tree types. They are often used for short, inline methods.
        public static void NormalParameter(int x)
        {
            Console.WriteLine($"Normal Parameter: {x}");
            x = 123;
            Console.WriteLine($"Normal Parameter inside this function after modification: {x}");
        }
        //params example
        public static long AddNumbers(params int[] numbers)
        {
            //params allows the user to pass any no of args while calling the method.
            long sum = 0;
            foreach(int num in numbers)
            {
                sum += num;
            }
            return sum;
        }

        public static void ArithematicFunction(int first , int second, ref double addedvalue, ref double subtractedvalue, ref double multipliedValue,ref double dividedValue)
        {
            addedvalue = first + second;
            subtractedvalue = first - second;
            multipliedValue = first * second;
            if(second != 0)
            {
                dividedValue = (double)first / second; // Cast to double to avoid integer division
            }
            else
            {
                Console.WriteLine("Divide by Zero is not allowed, not we are not modifying the value in the function");
            }
        }
        public static void AddFunc(int first, int second, out double result) => result = first + second;//When using out parameters, the method must assign a value to the out parameter before returning. The out parameter does not need to be initialized before being passed to the method.

        static void Main(string[] args)
        {
            ////////////////Normal Parameters////////////////
            int x = 10;
            NormalParameter(x);
            Console.WriteLine("X value after returning from the function: " + x);

            ////////////////Out Parameters////////////////
            double result;
            AddFunc(10, 20, out result);//retains the result in the out parameter. even after the method call, the out parameter retains the value assigned in the method.
            Console.WriteLine("the result: " + result);

            ////////////////Ref Parameters////////////////
            double addedValue = 0, subtractedValue = 0, multipliedValue = 0, dividedValue = 0;
            //U must initialize the ref parameters before passing them to the method.
            ArithematicFunction(20, 0, ref addedValue, ref subtractedValue, ref multipliedValue, ref dividedValue);
            Console.WriteLine($"The Added value: {addedValue}, SubtractedValue: {subtractedValue}, Multiplied Value: {multipliedValue}, divided Value: {dividedValue}");

            ////////////////Params Parameters////////////////
            long sum = AddNumbers(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            Console.WriteLine("Sum: " + sum);

        }
    }
}
