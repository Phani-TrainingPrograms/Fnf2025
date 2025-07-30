using SampleConApp.CustomCollections;
using System;
using System.IO; //namespace for File IO operations. 

namespace SampleConApp
{
    internal class Ex21FileIOExample
    {
        const string filePath = "CustomerData.csv";
        static void Main(string[] args)
        {
            //displayFileInfo();
            //displayDirInfo();
            //creatingCsvFile();
            var data = readingCsvFile();//Get the data
            foreach(var item in data)//iterate thru the list
            {
                Console.WriteLine(item.CustomerName);//display the data. 
            }
        }

        private static List<Customer> readingCsvFile()
        {
            var list = new List<Customer>();//create a blank List
            var lines = File.ReadAllLines(filePath);//Get all the lines of the file and store it in a String[]
            foreach(var line in lines)//iterate thru the lines
            {
                var words = line.Split(',');//split each line into words
                //extract the required data into a Customer object
                var cst = new Customer
                {
                    CustomerId = Convert.ToInt32(words[0]),
                    CustomerName = words[1],
                    BillAmount = Convert.ToDouble(words[2])
                };
                list.Add(cst);//Add the Customer object to the list
            }
            return list;//return the completed list. 
        }

        private static void creatingCsvFile()
        {
            var customer = new Customer
            {
                CustomerId = 123, CustomerName = "Joe", BillAmount = 5000
            };
            
            var content = $"{customer.CustomerId},{customer.CustomerName},{customer.BillAmount}\n";
            File.WriteAllText(filePath, content);//Writes to the file, if the file does not exist, it shall create the file and write to it, if the file exists, it shall overwrite the contents.
        }

        private static void displayDirInfo()
        {
            Console.WriteLine("Displaying Directories and its Info");
            var directorys = Directory.GetDirectories("C:\\Users\\phani\\OneDrive\\Documents");
            foreach(var dirPath in directorys)
            {
                var dir = new DirectoryInfo(dirPath);
                Console.WriteLine(dir.Name);
            }

            var newDir = "C:\\TestDir";
            var dirInfo = Directory.CreateDirectory(newDir);
            var parent = dirInfo.Parent;
            foreach(var dir_path in directorys)
            {
                var info = new DirectoryInfo(dir_path);
                foreach(var file in info.GetFiles())
                {
                    Console.WriteLine(file.Name);
                }
            }
        }

        private static void displayFileInfo()
        {
            var files = Directory.GetFiles("C:\\Users\\phani\\OneDrive\\Documents\\LTTS Docs");
            foreach(var file in files)
            {
                var selected_file = new FileInfo(file);
                Console.WriteLine($"The Name: {selected_file.Name}, Created on {selected_file.CreationTime}");

            }
        }
    }
}
