using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

namespace Infrastructure.Services;

public class JobHistoryService
{
    private DapperContext _context;
    public JobHistoryService()
    {
        _context = new DapperContext();
    }

    // List
    public List<JobHistoryDto> ListJobHistory()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select employee_id as EmployeeId, start_date as StartDate, end_date as EndDate, job_id as JobId, department_id as DepartmentId from job_history";
            var result = conn.Query<JobHistoryDto>(sql).ToList();
            return result.ToList();
        }
    }

    // Get By Id
    public JobHistoryDto GetJobHistoryById(int Id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select employee_id as EmployeeId, start_date as StartDate, end_date as EndDate, job_id as JobId, department_id as DepartmentId from job_history where  employee_id ={Id}";
            var result = conn.QuerySingle<JobHistoryDto>(sql);
            return result;
        }
    }

    // insert 
    public JobHistoryDto AddJobHistory(JobHistoryDto jobHistory)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"insert into job_history(start_date, end_date, job_id, department_id) values (@StartDate, @EndDate, @JobId, @DepartmentId)";
            var result = conn.Execute(sql, jobHistory);
            return jobHistory;
        }
    }

    // Update
    public JobHistoryDto UpdateJobHistory(JobHistoryDto jobHistory)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"update job_history set start_date = @StartDate, end_date = @EndDate, job_id = @JobId, department_id =@DepartmentId where employee_id = @EmployeeId";
            var result = conn.Execute(sql, jobHistory);
            return jobHistory;
        }
    }

    // Delete
    public JobHistoryDto DeleteJobHistory(JobHistoryDto jobHistory)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"Delete from job_history where employee_id = @EmployeeId";
            var result = conn.Execute(sql,jobHistory);
            return jobHistory;
        }
    }
}
