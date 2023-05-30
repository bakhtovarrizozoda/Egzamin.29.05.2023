using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationsController
{
    private LocationsService _locationsService;
    public LocationsController()
    {
        _locationsService = new LocationsService();
    }

    [HttpGet("ListLocation")]
    public List<LocationsDto> ListLocations()
    {
        return _locationsService.ListLocations();
    }

    [HttpGet("GetById")]
    public LocationsDto GetLocationsById(int Id)
    {
        return _locationsService.GetLocationsById(Id);
    }

    [HttpPost("AddLocation")]
    public LocationsDto AddLocations(LocationsDto locations)
    {
        return _locationsService.AddLocations(locations);
    }

    [HttpPut("UpdateLocation")]
    public LocationsDto UpdateLocations(LocationsDto locations)
    {
        return _locationsService.UpdateLocations(locations);
    }

    [HttpDelete("DeleteLocation")]
    public LocationsDto DeleteLocations(LocationsDto locations)
    {
        return _locationsService.DeleteLocations(locations);
    }
}
