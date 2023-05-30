using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class DepartmentsService
{
    private DapperContext _context;
    public DepartmentsService()
    {
        _context = new DapperContext();
    }

    // List 
    public List<DepartmentsDto> ListDepartments()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select department_id as DepartmentId, department_name as DepartmentName, manager_id as ManagerId, location_id as LocationId from departments";
            var result = conn.Query<DepartmentsDto>(sql).ToList();
            return result.ToList();
        }
    }

    // Get By Id
    public DepartmentsDto GetDepartmentsById(int Id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select department_id as DepartmentId, department_name as DepartmentName, manager_id as ManagerId, location_id as LocationId from departments where  department_id ={Id}";
            var result = conn.QuerySingle<DepartmentsDto>(sql);
            return result;
        }
    }

    // Insert 
    public DepartmentsDto AddDepartments(DepartmentsDto departments)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"insert into departments(department_id, department_name, manager_id, location_id) values (@DepartmentId, @DepartmentName, @ManagerId, @LocationId)";
            var result = conn.Execute(sql, departments);
            return departments;
        }
    }

        // Delete
    public DepartmentsDto DeleteDepartments(DepartmentsDto departments)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Delete from departments where location_id = @LocationId";
            var result = conn.Execute(sql, departments);
            return departments;
        }
    }

    // Update 
    public DepartmentsDto UpdateDepartments(DepartmentsDto departments)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Update departments set department_id = @DepartmentId, department_name = @DepartmentName, manager_id = @ManagerId where location_id = @.LocationId";
            var result = conn.Execute(sql, departments);
            return departments;
        }
    }
}
