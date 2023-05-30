using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeesController
{
    private EmployeesService _employeesService;
    public EmployeesController()
    {
        _employeesService = new EmployeesService();
    } 

    [HttpGet("ListEmployees")]
    public List<EmployeesDto> ListEmployees()
    {
        return _employeesService.ListEmployees();
    }

    [HttpGet("GetById")]
    public EmployeesDto GetEmployeesById(int Id)
    {
        return _employeesService.GetEmployeesById(Id);
    }

    [HttpPost("AddEmployees")]
    public EmployeesDto AddEmployees([FromQuery]EmployeesDto employees)
    {
        return _employeesService.AddEmployees(employees);
    }

    [HttpPut("UpdateEmployees")]
    public EmployeesDto UpdateEmployees([FromQuery]EmployeesDto employees)
    {
        return _employeesService.UpdateEmployees(employees);
    }

    [HttpDelete("DeleteEmployees")]
    public EmployeesDto DeleteEmployees([FromQuery]EmployeesDto employees)
    {
        return _employeesService.DeleteEmployees(employees);
    }
}
