using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CountriesController
{
    private CountriesService _countriesService;
    public CountriesController()
    {
        _countriesService = new CountriesService();
    }

    [HttpGet("ListCountries")]
    public List<CountriesDto> ListCountries()
    {
        return _countriesService.ListCountries();
    }

    [HttpGet("GetById")]
    public CountriesDto GetCountriesById(int Id)
    {
        return _countriesService.GetCountriesById(Id);
    }


    [HttpPost("AddCountries")]
    public CountriesDto AddCountries(CountriesDto countries)
    {
        return _countriesService.AddCountries(countries);
    }

    [HttpPut("DeleteCountries")]
    public CountriesDto DeleteCountries(CountriesDto countries)
    {
        return _countriesService.DeleteCountries(countries);
    }

    [HttpDelete("UpdateCountries")]
    public CountriesDto UpdateCountries(CountriesDto countries)
    {
        return _countriesService.UpdateCountries(countries);
    }
}
