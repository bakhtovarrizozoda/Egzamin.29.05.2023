using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class LocationsService
{
    private DapperContext _context;
    public LocationsService()
    {
        _context = new DapperContext();        
    }

    // List 
    public List<LocationsDto> ListLocations()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select location_id as LocationId, street_address as StreetAddress, postal_code as PostalCode, city as City, state_provine as StateProvine, country_id as CountryId from locations";
            var result = conn.Query<LocationsDto>(sql).ToList();
            return result.ToList();
        }
    }

    // Get By Id
    public LocationsDto GetLocationsById(int Id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select location_id as LocationId, street_address as StreetAddress, postal_code as PostalCode, city as City, state_provine as StateProvine, country_id as CountryId from locations where location_id = {Id}";
            var result = conn.QuerySingle<LocationsDto>(sql);
            return result;
        }
    }

    // Insert
    public LocationsDto AddLocations(LocationsDto locations)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"insert into locations(street_address, postal_code, city, state_provine, country_id) values (@StreetAddress, @PostalCode, @City, @StateProvine, @CountryId)";
            var result = conn.Execute(sql, locations);
            return locations;
        }
    }

    // Update
    public LocationsDto UpdateLocations(LocationsDto locations)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Update locations set street_address = @StreetAddress, postal_code = @PostalCode, city = @City, state_provine = @StateProvine, country_id = @CountryId where location_id = @LocationId";
            var result = conn.Execute(sql, locations);
            return locations;
        }
    }

    // Delete
    public LocationsDto DeleteLocations(LocationsDto locations)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Delete from locations where location_id = @LocationId";
            var result = conn.Execute(sql, locations);
            return locations;
        }
    }
}
