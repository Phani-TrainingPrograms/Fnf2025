using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
/*
 * Exceptions are scenarios that occur during the execution of a program that disrupt the normal flow of instructions.
 * Possible causes of exceptions include: File not found, network issues, invalid user input, access issues etc.
 * C# provides exception handling to manage these scenarios gracefully in the form of try-catch blocks.
 * try block contains code that may create an exception. catch block contains code that handles the specified exception. U can have multiple catch blocks to handle different types of exceptions.
 * U can have nested try-catch blocks to handle exceptions at different levels of the code.
 * finally block is optional and contains code that will always execute after the try-catch blocks, regardless of whether an exception occurred or not.
 * Every try block must have at least one catch block or a finally block.
 * Keywords: try, catch, finally, throw.
 * throw keyword is used to explicitly throw an exception. It can be used to create custom exceptions or rethrow existing exceptions.
 * All Exceptions are derived from System.Exception. U can create a Custom Exception to meet UR Business rules and reject the flow by raising UR Exceptions. 
 * All Exception classes must be suffixed with Exception.
 * As a programmer, U can anticipate exceptions that may occur in UR code and handle them gracefully. For unknown scenarios, U can use a general catch block to catch all exceptions by catching the base Exception class. System.Exception is the base class for all exceptions in .NET.
 */
namespace SampleConApp
{

    [Serializable]
    public class DbFailureException : Exception
    {
        public DbFailureException() { }
        public DbFailureException(string message) : base(message) { }
        public DbFailureException(string message, Exception inner) : base(message, inner) { }
    }
    internal class Ex14ExceptionHandling
    {
        static void Main(string[] args)
        {
            //firstExample();
            //secondExample();
            try
            {
                thirdExample();
            }
            catch(DbFailureException ex)
            {
                Console.WriteLine($"Custom Exception Caught: {ex.Message}");
                // Handle the exception or log it
            }
            catch(Exception ex)
            {
                Console.WriteLine($"General Exception Caught: {ex.Message}");
                // Handle the exception or log it
            }
            finally
            {
                Console.WriteLine("Execution completed. Thank you for trying our example.");
            }
        }

        private static void thirdExample()
        {
            bool isConnected = true;
            Console.WriteLine("Code to connect to the database");
            isConnected = false; // Simulating a failure in database connection
            if(!isConnected)
            {
                //throwing an exception explicitly
                throw new DbFailureException("Failed to connect to the database");
            }
            Console.WriteLine("DB Connected Successfully");
        }



        //Example of handling Exception raised by ThrowingExceptionExample Function
        static void secondExample()
        {
        RETRY:
            try
            {
                ThrowingExceptionExample();
            }
            catch(UnauthorizedAccessException)
            {
                Console.WriteLine("Invalid Username or Password\nPlease try again");
                goto RETRY;
            }
        }
        /// <summary>
        /// Validates user input for username and password.
        /// </summary>
        /// <exception cref="UnauthorizedAccessException">Username and Password wrong Entry</exception>
        private static void ThrowingExceptionExample()
        {
            string uname = ConsoleUtil.GetInputString("Enter the username");
            string pwd = ConsoleUtil.GetInputString("Enter the Password");
            if(uname == "admin" && pwd == "admin")
            {
                Console.WriteLine("Welcome to the system");
            }
            else
            {
                //throwing an exception explicitly
                throw new UnauthorizedAccessException("Invalid username or password");
            }
        }

        static void firstExample()
        {
        RETRY:
            try
            {
                Console.WriteLine("Enter the age");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("The age is " + age);
            }
            catch(OverflowException ex1)
            {
                Console.WriteLine($"The System generated the message: {ex1.Message}");
                Console.WriteLine($"Input must be within {int.MinValue} and {int.MaxValue}");
                goto RETRY; // Using goto to repeat the input prompt
            }
            catch(FormatException ex2)
            {
                Console.WriteLine($"The System generated the message: {ex2.Message}");
                Console.WriteLine("Input should be a valid no");
                goto RETRY; // Using goto to repeat the input prompt
            }
            finally
            {
                //finally is more like a cleanup code that will always run. 
                //It is used to release resources, close files, or perform any necessary cleanup.
                //U cannot have jump statements like goto, break, continue, or return in finally block.
                Console.WriteLine("Finally block executed. This will always run.");
                Console.WriteLine("Thanks for trying our example");
            }
        }
    }
}
