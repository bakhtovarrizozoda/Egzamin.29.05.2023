using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class JobsService
{
    private DapperContext _context;
    public JobsService()
    {
        _context = new DapperContext();
    }

    // List
    public List<JobsDto> ListJobs()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select job_id as JobId, job_title  as JobTitle, min_salary as MinSalary, max_salary  as MaxSalary from jobs";
            var result = conn.Query<JobsDto>(sql).ToList();
            return result.ToList();
        }
    }

    // Get BY Id
    public JobsDto GetJobsById(int Id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select job_id as JobId, job_title  as JobTitle, min_salary as MinSalary, max_salary  as MaxSalary from jobs where job_id = {Id}";
            var result = conn.QuerySingle<JobsDto>(sql);
            return result;
        }
    }

    // Insert 
    public JobsDto AddJobs(JobsDto jobs)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"insert into jobs(job_title, min_salary, max_salary) values (@JobTitle, @MinSalary, @MaxSalary)";
            var result = conn.Execute(sql, jobs);
            return jobs;
        }
    }

    // Update
    public JobsDto UpdateJobs(JobsDto jobs)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Update jobs set job_title = @JobTitle, min_salary = @MinSalary, max_salary = @MaxSalary where job_id = @JobId";
            var result = conn.Execute(sql, jobs);
            return jobs;
        }
    }

    // Delete
    public JobsDto DeleteJobs(JobsDto jobs)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Delete from jobs where job_id = @JobId";
            var result = conn.Execute(sql, jobs);
            return jobs;
        }
    }
}
