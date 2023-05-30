using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentsController
{
    private DepartmentsService _departmentsService;
    public DepartmentsController()
    {
        _departmentsService = new DepartmentsService();
    }

    [HttpGet("ListDepartment")]
    public List<DepartmentsDto> ListDepartments()
    {
        return _departmentsService.ListDepartments();
    }

    [HttpGet("GetById")]
    public DepartmentsDto GetDepartmentsById(int Id)
    {
        return _departmentsService.GetDepartmentsById(Id);
    }

    [HttpPost("AddDepartments")]
    public DepartmentsDto AddDepartments(DepartmentsDto departments)
    {
        return _departmentsService.AddDepartments(departments);
    }

    [HttpPut("DeleteDepartment")]
    public DepartmentsDto DeleteDepartment(DepartmentsDto departments)
    {
        return _departmentsService.DeleteDepartments(departments);
    }

    [HttpDelete("UpdateDepartment")]
    public DepartmentsDto UpdateDepartment(DepartmentsDto departments)
    {
        return _departmentsService.UpdateDepartments(departments);
    }
}
