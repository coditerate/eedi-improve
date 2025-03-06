namespace EediImprove.Repository.Models;

public class Topic
{
    public int TopicId { get; set; }

    public string? TopicName { get; set; }

    public List<SubTopic>? SubTopics { get; set; }
                                                                                                                                        }
