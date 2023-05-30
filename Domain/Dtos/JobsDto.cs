namespace Domain.Dtos;

public class JobsDto
{
    public int JobId { get; set; }
    public string? JobTitle { get; set; }
    public decimal MinSalary { get; set; }
    public decimal MaxSalary { get; set; }
}
