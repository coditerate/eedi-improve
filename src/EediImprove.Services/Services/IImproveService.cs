using EediImprove.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace EediImprove.Services.Services;

public interface IImproveService
{
    Task<StudentTopics?> Get(string studentId, CancellationToken cancellationToken);

    Task<SubTopic?> Get(string studentId, int topicId, int subTopicId, CancellationToken cancellationToken);

    Task<StudentTopics?> Patch(string studentId, int topicId, int subTopicId, [FromBody] SubTopic subTopic, CancellationToken cancellationToken);
}
