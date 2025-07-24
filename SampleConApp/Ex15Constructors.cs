namespace SampleConApp.ConsuctorsExample    
{
    //Constructors are sp functions that are invoked when an object is created from a class. They have the same name as the class and do not have a return type, not even void. It can be parameterized. Constructors with no parameters are called default constructors.
    //If a class does not have any constructor defined, the compiler provides a default constructor that initializes all fields to their default values (0 for numeric types, null for reference types, etc.).
    //If a class has any constructor defined, the compiler does not provide a default constructor.
    //U can have static constructos, Instance constructors and Private constructors.
    //Private constructors are used to prevent the instantiation of a class from outside the class. They are often used in singleton patterns or static classes.
    //Static constructors are used to initialize static members of a class. They are called once per type, before any instance of the class is created or any static members are accessed.
    //Instance constructors are used to initialize instance members of a class. They are called when an instance of the class is created.
    //If a class has a base class, then the base class constructor shall be invoked before the current constructor is called. 
    class SuperClass
    {
        //public SuperClass()
        //{
        //    Console.WriteLine("Super class constructor is called");
        //}
        public SuperClass(string value) 
        {
            Console.WriteLine($"Super class constructor with {value} as parameter");
        }
    }
    class BaseClass : SuperClass
    {
        public BaseClass(string msg) : base(msg) // Invoking the base class constructor
        {
            Console.WriteLine("Base class constructor is called");
        }
    }
    class DerivedClass : BaseClass
    {
        public DerivedClass(string msg) :base (msg) // Invoking the base class constructor
        {
            Console.WriteLine("Derived class constructor is called");
        }
    }
    internal class Ex15Constructors
    {

        static void Main(string[] args)
        {
            //SuperClass superClass = new SuperClass();  //using new operator to create an instance of the SuperClass and () shall invoke the constructor of the SuperClass. 
            //BaseClass baseClass = new BaseClass();
            Console.WriteLine("Etner the value to pass to the construtor");
            string value = Console.ReadLine();
            DerivedClass derivedClass = new DerivedClass(value);
        }
    }
}
