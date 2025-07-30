using System.Collections;

//Collections are a group of classes created to perform data structure based functionalities in .NET. Collections can be of 2 kinds: Generic and Non-Generic.
//Generic is new and typesafe, NonGeneric is more based on objects. (System.objects). 
//Collections resolve the issues of Arrays and can store data in different ways into a collection. 
//Collections store as objects and U may have to UNBOX them when U want to perform any data type specific operations like equals, checks, adding, removing etc. 
namespace SampleConApp
{
    internal class Ex18Collections
    {
        static Hashtable users = new Hashtable();
        static void Main(string[] args)
        {
            //ArrayListExample();
            //HashtableExample();
            UserLoginApp();
        }

        private static void UserLoginApp()
        {
            do
            {
                string choice = ConsoleUtil.GetInputString("Press R for Register and L for Login");
                if(choice.ToUpper() == "R")
                {
                    registerUser();
                }
                else
                {
                    validateUser();
                }
            } while(true);
        }

        private static void validateUser()
        {
            Console.WriteLine("Welcome to Login Page");
            string username = ConsoleUtil.GetInputString("Enter the Username");
            string password = ConsoleUtil.GetInputString("Enter the Password");
            if(!users.ContainsKey(username))
            {
                Console.WriteLine("Invalid Username");
                return;
            }
            else if(users[username].ToString() != password)
            {
                Console.WriteLine("Invalid Password");
                return;
            }
            else if(users[username].ToString() == password)
            {
                Console.WriteLine($"Welcome to the user {username}");
            }
        }

        private static void registerUser()
        {
            Console.WriteLine("Welcome to Registration Page");
            string username = ConsoleUtil.GetInputString("Enter the Username");
            string password = ConsoleUtil.GetInputString("Enter the Password");
            if(users.ContainsKey(username))
            {
                Console.WriteLine("User is already registered");
                return;
            }
            users[username] = password;//Adds a key and assigns a value to that key. If the Key exists, it would replace the value. 
            Console.WriteLine("User registered Successfully");

        }

        //HashTable stores the data in the form of key-value pairs. 
        private static void HashtableExample()
        {
            //Key should be unique. Value can be same. 
            Hashtable table = new Hashtable();
            table.Add("obj1", "Sample1");
            table.Add("obj2", "Sample2");
            table.Add("obj3", "Sample3");
            table.Add("obj4", "Sample4");
            table.Add("obj5", "Sample5");
            foreach(string key in table.Keys)
            {
                Console.WriteLine($"Key: {key}, Value: {table[key]}");
            }
        }

        static void ArrayListExample()
        {
            ArrayList list = new ArrayList();
            list.Add(234);//Adds the element to the bottom of the collection. 
            list.Add(123);
            list.Add(354);
            list.Add(7645);
            list.Add(55);
            list.Remove(354);
            Console.WriteLine("The total: " + list.Count);
            foreach(int item in list)
            {
                Console.WriteLine(item);
            }
            for(int i = 0; i < list.Count; i++)
            {
                if((int) list[i] == 55)
                {
                    Console.WriteLine("Item found");
                }
                else
                    continue;
            }
        }
    }
}
