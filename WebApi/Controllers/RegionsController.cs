using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RegionsController
{
    private RegionsService _regionsService;
    public RegionsController()
    {
        _regionsService = new RegionsService();
    }

    [HttpGet("ListRegions")]
    public List<RegionsDto> ListRegions()
    {
        return _regionsService.ListRegions();
    }

    [HttpGet("GetById")]
    public RegionsDto GetRegionsById(int Id)
    {
        return _regionsService.GetRegionsById(Id);
    }

    [HttpPost("AddRegion")]
    public RegionsDto AddRegions(RegionsDto regions)
    {
        return _regionsService.AddRegions(regions);
    }

    [HttpPut("UpdateRegion")]
    public RegionsDto UpdateRegions(RegionsDto regions)
    {
        return _regionsService.UpdateRegions(regions);
    }

    [HttpDelete("DeleteRegion")]
    public RegionsDto DeleteRegion(RegionsDto regions)
    {
        return _regionsService.DeleteRegion(regions);
    }
}
