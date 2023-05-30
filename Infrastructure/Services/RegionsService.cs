using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class RegionsService
{
    private DapperContext _context;
    public RegionsService()
    {
        _context = new DapperContext();
    }

    // List
    public List<RegionsDto> ListRegions()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select region_id as RegionId, region_name  as RegionName from regions";
            var result = conn.Query<RegionsDto>(sql).ToList();
            return result.ToList();
        }
    }

    // Get By Id
    public RegionsDto GetRegionsById(int Id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select region_id as RegionId, region_name  as RegionName from regions where region_id = {Id}";
            var result = conn.QuerySingle<RegionsDto>(sql);
            return result;
        }
    }
    // Insert
    public RegionsDto AddRegions(RegionsDto regions)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"insert into regions(region_name) values (@RegionName)";
            var result = conn.Execute(sql, regions);
            return regions;
        }
    }

    // Update
    public RegionsDto UpdateRegions(RegionsDto regions)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Update regions set region_name = @RegionName where region_id = @RegionId";
            var result = conn.Execute(sql, regions);
            return regions;
        }
    }

    // Delete
    public RegionsDto DeleteRegion(RegionsDto regions)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Delete from regions where region_id = @RegionId";
            var result = conn.Execute(sql, regions);
            return regions;
        }
    }
}
