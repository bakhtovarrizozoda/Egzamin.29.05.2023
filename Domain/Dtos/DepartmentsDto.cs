namespace Domain.Dtos;

public class DepartmentsDto
{
    public int DepartmentId { get; set; }
    public string? DepartmentName { get; set; }
    public int ManagerId { get; set; }
    public int LocationId { get; set; }
}
