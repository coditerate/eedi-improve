using EediImprove.Repository.Models;
using EediImprove.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace EediImprove.Api.Controllers;

[ApiController]
[Route("{studentId}/[controller]")]
public class ImproveController(IImproveService improveService, ILogger<ImproveController> logger) : ControllerBase
{
    // GET: /{studentId}/improve
    [HttpGet]
    public async Task<StudentTopics?> Get(string studentId, CancellationToken cancellationToken)
    {
        return await improveService.Get(studentId, cancellationToken);
    }

    // GET: /{studentId}/improve/{topicId}/{subTopicId}
    [HttpGet("{topicId}/{subTopicId}")]
    public async Task<SubTopic?> Get(string studentId, int topicId, int subTopicId, CancellationToken cancellationToken)
    {
        return await improveService.Get(studentId, topicId, subTopicId, cancellationToken);
    }

    // PATCH: /{studentId}/improve/{topicId}/{subTopicId}
    [HttpPatch("{topicId}/{subTopicId}")]
    public async Task<StudentTopics?> Patch(string studentId, int topicId, int subTopicId, [FromBody] SubTopic subTopic, CancellationToken cancellationToken)
    {
        return await improveService.Patch(studentId, topicId, subTopicId, subTopic, cancellationToken);
    }
}
