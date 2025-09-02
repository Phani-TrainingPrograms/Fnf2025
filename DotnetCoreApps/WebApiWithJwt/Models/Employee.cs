using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiWithJwt.Models
{
    //dotnet add package packagename
    [Table("EmpTable")]
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        [Required]public string EmpName { get; set; }
        [Required] public string EmpDept { get; set; }
        [Required] public double EmpSalary { get; set; }
        [Required] public DateTime DateOfBirth { get; set; }
    }
}
