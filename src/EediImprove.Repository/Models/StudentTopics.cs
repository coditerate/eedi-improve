namespace EediImprove.Repository.Models;

public class StudentTopics
{
    public string? StudentId { get; set; }

    public List<Topic>? AllocatedTopics { get; set; }
}
