namespace SampleMvcApp.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpEmail { get; set; }
        public double EmpSalary { get; set; }

        public override string ToString()
        {
            return $"ID: {EmpId}, Name: {EmpName}, Email: {EmpEmail}, Salary: {EmpSalary}";
        }
    }
}
