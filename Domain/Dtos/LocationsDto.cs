namespace Domain.Dtos;

public class LocationsDto
{
    public int LocationId { get; set; }
    public string? StreetAddress { get; set; }
    public int PostalCode { get; set; }
    public string? City { get; set; }
    public string? StateProvine { get; set; }
    public int CountryId { get; set; }
}
