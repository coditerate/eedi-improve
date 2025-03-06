using EediImprove.Repository.Models;

namespace EediImprove.Repository.Services;

public interface IDataService
{
    Task<StudentTopics?> GetStudentTopics(string studentId);
    Task<SubTopic?> GetSubTopic(string studentId, int topicId, int subTopicId);
    Task<StudentTopics?> UpdateSubTopic(string studentId, int topicId, int subTopicId, SubTopic updatedSubTopic);
}