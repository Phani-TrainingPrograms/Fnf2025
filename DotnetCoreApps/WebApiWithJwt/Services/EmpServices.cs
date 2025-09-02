using Microsoft.EntityFrameworkCore;
using WebApiWithJwt.Data;
using WebApiWithJwt.Models;

public interface IEmpService
{
    Task<Employee> GetById(int id);
    Task<Employee> AddNewEmployee(Employee employee);
    Task<IEnumerable<Employee>> GetAllEmployees();
    Task<Employee> UpdateEmployee(Employee employee);
    Task DeleteEmployee(int id);
}

public class EmpService : IEmpService
{
    private readonly AppDbContext _context;
    public EmpService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Employee> AddNewEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task DeleteEmployee(int id)
    {
        var rec = _context.Employees.Find(id);
        if(rec != null)
        {
            _context.Employees.Remove(rec);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new Exception("Record found to delete");
        }
    }

    public async Task<IEnumerable<Employee>> GetAllEmployees() => await _context.Employees.ToListAsync<Employee>();
    

    public async Task<Employee> GetById(int id) => await _context.Employees.FindAsync(id);
    

    public async Task<Employee> UpdateEmployee(Employee employee)
    {
        var rec = await _context.Employees.FindAsync(employee.EmpId);
        if(rec != null)
        {
            rec.EmpDept = employee.EmpDept;
            rec.EmpName = employee.EmpName; 
            rec.EmpSalary = employee.EmpSalary;
            rec.DateOfBirth = employee.DateOfBirth;
            await _context.SaveChangesAsync();
        }
        return employee;
    }
}