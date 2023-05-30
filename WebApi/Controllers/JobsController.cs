using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class JobsController
{
    private JobsService _jobsService;
    public JobsController()
    {
        _jobsService = new JobsService();
    }

    [HttpGet("ListJobs")]
    public List<JobsDto> ListJobs()
    {
        return _jobsService.ListJobs();
    }

    [HttpGet("GetById")]
    public JobsDto GetJobsById(int Id)
    {
        return _jobsService.GetJobsById(Id);
    }

    [HttpPost("AddJobs")]
    public JobsDto AddJobs(JobsDto jobs)
    {
        return _jobsService.AddJobs(jobs);
    }

    [HttpPut("UpdateJobs")]
    public JobsDto UpdateJobs(JobsDto jobs)
    {
        return _jobsService.UpdateJobs(jobs);
    }

    [HttpDelete("DeleteJobs")]
    public JobsDto DeleteJobs(JobsDto jobs)
    {
        return _jobsService.DeleteJobs(jobs);
    }
}
