namespace EediImprove.Repository.Models;

public class SubTopic
{
    public new int SubTopicId { get; set; }

    public new string? SubTopicName { get; set; }

    public new int? TotalMisconceptions { get; set; }

    public List<Question>? Questions { get; set; } = null;
}
