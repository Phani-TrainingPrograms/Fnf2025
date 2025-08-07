using SampleLib.DataLayer;
using SampleLib.Entities;
using System;
using System.Linq;
using System.Xml.Linq;//Namespace for XLINQ


namespace SampleWinConsole
{
    //Using LINQ on XML is called XLINQ.
    internal class Ex05XLINQDemo
    {
        static void Main(string[] args)
        {
            //createXmlFromCollection();
            //var doc = XDocument.Load("EmpList.xml");
            //Console.WriteLine(doc);
            //readXmlToDoc();
            //insertingRecordIntoXml();
            //updateRecordIntoXml();
            deleteRecordFromXml();
        }

        private static void deleteRecordFromXml()
        {
            Console.WriteLine("Enter the Name to delete");
            var name = Console.ReadLine();
            var doc = XDocument.Load("EmpList.xml");
            var found = (from rec in doc.Descendants("Employee")
                         where rec.Element("Name").Value == name
                         select rec).FirstOrDefault();//Every LINQ query returns an IEnumerable<T> collection. So  from it, U should select the first record.
            if(found != null)
            {
                found.Remove();
                doc.Save("EmpList.xml");//It overwrites the existing file.
                Console.WriteLine($"Record with Name {name} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"No record found with Name {name}.");
            }
        }

        private static void updateRecordIntoXml()
        {
            var doc = XDocument.Load("EmpList.xml");
            var found = (from rec in doc.Descendants("Employee")
                      where rec.Element("Name").Value == "Phaniraj"
                      select rec).FirstOrDefault();
            if (found != null)
            {
                found.Element("Address").Value = "RR Nagar, Bangalore";
                found.Element("Salary").Value = "65000";
            }
            
            doc.Save("EmpList.xml");//It overwrites the existing file.
        }

        private static void insertingRecordIntoXml()
        {
            //Take inputs from the user on the newly creating record as well as existing record details where U need to insert.
            var emp = new Employee
            {
                EmpName = "Rancho",
                EmpAddress = "Nice",
                EmpSalary = 50000,
                DeptId = 5
            };
            //Create an Xml Element with Details.
            var element = new XElement("Employee",
                new XElement("Name", emp.EmpName, new XAttribute("Gender", "Female")),
                new XElement("Address", emp.EmpAddress),
                new XElement("Salary", emp.EmpSalary),
                new XElement("DeptId", emp.DeptId));
            //Select the Doc where U need to insert the element.
            var doc = XDocument.Load("EmpList.xml");            
            //Insert the element at the last.
            var found = (from rec in doc.Descendants("Employee")
                      where rec.Element("Name").Value == "Clint Bricklebank"
                      select rec).First();//Throws exception if not found.
            found.AddBeforeSelf(element);
            //Save the document.
            doc.Save("EmpList.xml");
        }

        private static void readXmlToDoc()
        {
            var doc = XDocument.Load("EmpList.xml");
            var empNames = from xelement in doc.Descendants("Employee")
                           select xelement.Element("Name");
            foreach(var name in empNames)
            {
                Console.WriteLine(name);
            }   
        }

        private static void createXmlFromCollection()
        {
            var data = new EmployeeDB().GetAllEmployees();
            XDocument xDoc = new XDocument(new XElement("EmpList", from emp in data
                                                        select new XElement("Employee", 
                                                        new XElement("Name", emp.EmpName),
                                                        new XElement("Gender", "Male"),
                                                        new XElement("Address", emp.EmpAddress),
                                                        new XElement("Salary", emp.EmpSalary),
                                                        new XElement("DeptId", emp.DeptId))));
            xDoc.Save("EmpList.xml");


        }
    }
}
