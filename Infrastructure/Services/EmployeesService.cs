using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class EmployeesService
{
    private DapperContext _context;
    public EmployeesService()
    {
        _context = new DapperContext();
    }

    // ListEmployee
    public List<EmployeesDto> ListEmployees()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select employee_id as EmployeeId, first_name as FirstName, last_name as LastName, email as Email, phone_number as PhoneNumber, department_id as DepartmentId, manager_id as ManagerId, commission as Commission, salary as Salary, job_id as JobId, hire_date as HireDate  from employees";
            var result = conn.Query<EmployeesDto>(sql).ToList();
            return result.ToList();
        }
    }

    // Get By Id
    public EmployeesDto GetEmployeesById(int Id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select employee_id as EmployeeId, first_name as FirstName, last_name as LastName, email as Email, phone_number as PhoneNumber, department_id as DepartmentId, manager_id as ManagerId, commission as Commission, salary as Salary, job_id as JobId, hire_date as HireDate  from employees where employee_id = {Id}";
            var result = conn.QuerySingle<EmployeesDto>(sql);
            return result;
        }
    }

    // Insert 
    public EmployeesDto AddEmployees(EmployeesDto employees)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"insert into employees (first_name, last_name, email, phone_number, department_id, manager_id, commission, salary, job_id, hire_date) values (@FirstName, @LastName, @Email, @PhoneNumber, @DepartmentId, @ManagerId, @Commission, @Salary, @JobId, @HireDate)";
            var result = conn.Execute(sql, employees);
            return employees;
        }
    }

    // Update
    public EmployeesDto UpdateEmployees(EmployeesDto employees)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Update employees set first_name = @FirstName, last_name = @LastName, email = @Email, phone_number = @PhoneNumber, department_id = @DepartmentId, manager_id = @ManagerId, commission = @Commission, salary = @Salary, job_id = @JobId, hire_date = @HireDate where employee_id = @EmployeeId";
            var result = conn.Execute(sql, employees);
            return employees;
        }
    }

    // Delete
    public EmployeesDto DeleteEmployees(EmployeesDto employees)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Delete from employees where employee_id = @EmployeeId";
            var result = conn.Execute(sql, employees);
            return employees;
        }
    }
}
