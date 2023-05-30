using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class JobHistoryController
{
    private JobHistoryService _jobHistoryService;
    public JobHistoryController()
    {
        _jobHistoryService = new JobHistoryService();
    } 

    [HttpGet("ListJobHistory")]
    public List<JobHistoryDto> ListJobHistory()
    {
        return _jobHistoryService.ListJobHistory();
    }

    [HttpGet("GetById")]
    public JobHistoryDto GetJobHistoryById(int Id)
    {
        return _jobHistoryService.GetJobHistoryById(Id);
    }

    [HttpPost("AddJobHistory")]
    public JobHistoryDto AddJobHistory(JobHistoryDto jobHistory)
    {
        return _jobHistoryService.AddJobHistory(jobHistory);
    }

    [HttpPut("UpdateJobHistory")]
    public JobHistoryDto UpdateJobHistory(JobHistoryDto jobHistory)
    {
        return _jobHistoryService.UpdateJobHistory(jobHistory);
    }

    [HttpDelete("DeleteJobHistory")]
    public JobHistoryDto DeleteJobHistory(JobHistoryDto jobHistory)
    {
        return _jobHistoryService.DeleteJobHistory(jobHistory);
    }
}
