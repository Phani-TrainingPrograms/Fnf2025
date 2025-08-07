using System;

//Garbage Collection is an internal memory management system of .NET framework. It is used to manage the memory of the application and ensures that unused objects/memory is removed behind the scenes as and when its required. 
//Garbage collection is recommended not to be touched unless U R working with unmanaged code. Code developed with traditional C/C++ and outside the world of .NET is called as Unmanaged code. Code that is executed in .NET is managed by CLR and GC, hense its called as Managed Code/Environment. 
//Traditional C/C++ does not have automatic memory management as far as dynamic memory allocation is concerned. 
//Destructors are sp function called when the object is destroyed in the memory. It is opposite of Constructor which is called when the object is created. objects can be created using new operator in C#, however, we dont have any deletion operator in C# as it is expected to be done internally by GC thru .NET CLR.  
//To explicitly call destructors of unmanaged code, .NET recommends to implement an interface called IDisposable which has a function called Dispose and call the unmanaged destructors in it. The programmers must called the Dispose method if the object is no longer needed and avoid memory leaks. 
//IDisposable interface is used to implement Dispose method that shall be called explicitly by the programmers after the usage of an object. 
//using block helps in calling the Dispose method implicitly after the object goes out of scope. 
namespace SampleConApp
{
    class SimpleObject : IDisposable
    {
        private int _id;
        public SimpleObject(int id)
        {
            _id = id;
            Console.WriteLine($"{_id} object is created");
        }

        //Destructors dont have access specifiers, no args or return values, not even void. They cannot be invoked from anywhere. It is called internally by the GC when the object is destroyed. 
        ~SimpleObject()
        {
            Console.WriteLine($"{_id} object is Destroyed");
        }

        public void Dispose()
        {
            //U R expected to call statements that would release memory of unmanaged code
            Console.WriteLine($"{_id} object is Destroyed");
            GC.SuppressFinalize( this );//Tell the GC that it must not call the current object's destructor when the object is destroyed.
        }
    }
    internal class Ex26GarbageCollection
    {
        static void CreateAndDestroyObjects()
        {
            for(int i = 0; i < 10; i++)
            {
               GC.Collect();//Runs the GC as background thread which clears unused objects from the memory. 
                GC.WaitForPendingFinalizers();//When the GC is in action, the main thread shall pause till all the objects that are to be destroyed are done with.
                using(SimpleObject obj = new SimpleObject(i))
                {

                }
                //obj.Dispose();
            }
        }
        static void Main(string[] args)
        {
            CreateAndDestroyObjects();
        }
    }
}
