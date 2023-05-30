using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class CountriesService
{
    private DapperContext _context;
    public CountriesService()
    {
        _context = new DapperContext();
    }

    // List 
    public List<CountriesDto> ListCountries()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select country_id as CountryId, country_name as CountryName, region_id as RegionId from countries";
            var result = conn.Query<CountriesDto>(sql).ToList();
            return result.ToList();
        }
    }

    // Get By Id
    public CountriesDto GetCountriesById(int Id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select country_id as CountryId, country_name as CountryName, region_id as RegionId from countries where  country_id ={Id}";
            var result = conn.QuerySingle<CountriesDto>(sql);
            return result;
        }
    }

    // Insert 
    public CountriesDto AddCountries(CountriesDto countries)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"insert into countries(country_id, country_name, region_id) values (@CountryId, @CountryName, @RegionId)";
            var result = conn.Execute(sql, countries);
            return countries;
        }
    }

    // Delete
    public CountriesDto DeleteCountries(CountriesDto countries)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Delete from countries where region_id = @RegionId";
            var result = conn.Execute(sql, countries);
            return countries;
        }
    }

    // Update 
    public CountriesDto UpdateCountries(CountriesDto countries)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Update countries set country_id = @CountryId, country_name = @CountryName where region_id = @RegionId";
            var result = conn.Execute(sql, countries);
            return countries;
        }
    }
}
