namespace SampleConApp
{
    class BaseClass//This class is internal. internal classes are accessible only within the same assembly/project. If you want to make it accessible outside the assembly, you can change it to public.
    {
        public void Display()
        {
            Console.WriteLine("Base Class Display Method");
        }
    }

    //A derived class that inherits from BaseClass is required if U want to add new functionality or override existing functionality of the base class. A Class is immutable by default, meaning you cannot change its functionality unless you inherit from it. (Open-Closed Principle of SOLID)
    //C# does not support multiple inheritance, meaning a class cannot inherit from more than one base class at the same level. However, it can implement multiple interfaces. C# supports multi level inheritance, meaning a class can inherit from another derived class, creating a chain of inheritance.
    class DerivedClass : BaseClass
    {
        public void Show()
        {
            Console.WriteLine("Show method is implemented");
        }
    }

    class InheritanceExample
    {
        static void Main(string[] args)
        {
            DerivedClass derived = new DerivedClass(); //Creating an instance of the derived class
            derived.Display(); //Calling the method from the base class
            derived.Show(); //Calling the method from the derived class
        }
    }
}