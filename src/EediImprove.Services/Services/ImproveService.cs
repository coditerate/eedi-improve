using EediImprove.Repository.Models;
using EediImprove.Repository.Services;
using Microsoft.Extensions.Logging;

namespace EediImprove.Services.Services;

public class ImproveService(IDataService dataService, ILogger<ImproveService> logger) : IImproveService
{
    public async Task<StudentTopics?> Get(string studentId, CancellationToken cancellationToken)
    {
        return await dataService.GetStudentTopics(studentId);
    }

    public async Task<SubTopic?> Get(string studentId, int topicId, int subTopicId, CancellationToken cancellationToken)
    {
        return await dataService.GetSubTopic(studentId, topicId, subTopicId);
    }

    public async Task<StudentTopics?> Patch(string studentId, int topicId, int subTopicId, SubTopic subTopic, CancellationToken cancellationToken)
    {
        return await dataService.UpdateSubTopic(studentId, topicId, subTopicId, subTopic);
    }
}
