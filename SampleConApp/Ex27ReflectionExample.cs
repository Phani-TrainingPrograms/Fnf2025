using System;
using System.Reflection;
//Reflection is a feature in .NET that allows you to inspect the metadata of types at runtime. It provides information about the types, methods, properties, and events defined in an assembly.
//Reflection is useful for scenarios where you need to dynamically discover and interact with types without knowing them at compile time.
namespace SampleConApp
{
    internal class Ex27ReflectionExample
    {
        static void Main(string[] args)
        {
            //U should know the location of the DLL or the assembly that you want to inspect.
            var dllLoc = @"C:\Trainings\FnfTraining\FnFTraining-2025\CSharpBasics\SampleCoreLib\bin\Debug\net8.0\SampleCoreLib.dll";
            //Load the assembly into the current application domain.
            Assembly assembly = Assembly.LoadFile(dllLoc);
            if(assembly == null)
            {
                Console.WriteLine("Assembly not found.");
                return;
            }
            //Get all the Types in the assembly
            Type[] types = assembly.GetTypes();//Gets an array of Types(Classes, enums, structs, interfaces, etc.) defined in the assembly.
            foreach(Type type in types)
                Console.WriteLine(type.FullName);
            //Select the type you want to inspect/use.
            Console.WriteLine("Enter the Fullname of the Type from the List above");
            string typeName = Console.ReadLine();
            Type selectedType = assembly.GetType(typeName, false, true); 
            if(selectedType == null)
            {
                Console.WriteLine("Type selected is wrong, exiting");
                return;
            }
            //Get the methods, properties, and events of the type.
            MemberInfo[] members = selectedType.GetMembers(BindingFlags.Public | BindingFlags.Instance);
            foreach(MemberInfo member in members)
            {
                Console.WriteLine($"Member: {member.Name}, Type: {member.MemberType}");
            }
            Console.WriteLine("Enter the member name to invoke");
            string memberName = Console.ReadLine();
            //Select the method you want to invoke.
            MethodInfo method = selectedType.GetMethod(memberName);
            if(method == null)
            {
                Console.WriteLine("Method not found.");
                return;
            }
            //Get the parameters of the method.
            ParameterInfo[] parameters = method.GetParameters(); //Get the parameters of the method.
            if(parameters.Length == 0)
            {
                //If the method has no parameters, invoke it directly.
                object result = method.Invoke(Activator.CreateInstance(selectedType), null);
                Console.WriteLine($"Result: {result}");
                return;
            }
            else //this is the expected execution path for methods with parameters
            {
                List<object> parameterValues = new List<object>();
                foreach(ParameterInfo parameter in parameters)
                {
                    Console.WriteLine($"Enter the Value for the Parameter: {parameter.Name}, whose Data type is {parameter.ParameterType}");
                    string input = Console.ReadLine();
                    //Convert the input to the parameter type and add to the parameterValues list. 
                    object value = Convert.ChangeType(input, parameter.ParameterType);
                    parameterValues.Add(value);
                }
                Console.WriteLine("All parameters are set, now time to invoke");
            //Pass the parameters to the method and invoke it.
            //Create the instance of the object
                object instance = Activator.CreateInstance(selectedType);

                if(instance == null)
                {
                    Console.WriteLine("object could not be created");
                    return;
                }
                object result = method.Invoke(instance, parameterValues.ToArray());
                Console.WriteLine("The result: " + result);
            }
        }
    }
}

