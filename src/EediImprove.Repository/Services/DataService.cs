﻿using EediImprove.Repository.Models;
using System.Text.Json;

namespace EediImprove.Repository.Services;

public class DataService : IDataService
{
    public async Task<StudentTopics?> GetStudentTopics(string studentId)
    {
        var studentTopics = await Get(studentId);
        
        // TODO: remove sub-topics which have zero total misconceptions.
        // TODO: following the above removal, possibly also then remove the topics where no sub-topics remain.
        
        // Ideally, the below can be avoided, depending on how the data is stored in the DB.
        // Because I've used a blob of json, this will need to be done in order to remove the questions when a list of topics/sub-topics is requested.
        foreach (var subTopic in (studentTopics?.AllocatedTopics!).SelectMany(topic => topic.SubTopics!))
        {
            subTopic.Questions = null;
        }

        return studentTopics;
    }

    public async Task<SubTopic?> GetSubTopic(string studentId, int topicId, int subTopicId)
    {
        var studentTopics = await Get(studentId);
        var topic = studentTopics!.AllocatedTopics!.Find(i => i.TopicId == topicId);
        var subTopic = topic!.SubTopics!.Find(i => i.SubTopicId == subTopicId);

        return subTopic;
    }

    public async Task<StudentTopics?> UpdateSubTopic(string studentId, int topicId, int subTopicId, SubTopic updatedSubTopic)
    {
        var studentTopics = await Get(studentId);
        var savedTopic = studentTopics!.AllocatedTopics!.Find(i => i.TopicId == topicId);
        var savedSubTopic = savedTopic!.SubTopics!.Find(i => i.SubTopicId == subTopicId);

        foreach (var question in updatedSubTopic!.Questions!)
        {
            var savedQuestion = savedSubTopic!.Questions!.Find(i => i.QuestionId == question.QuestionId);
            savedQuestion!.SelectedAnswerId = question.SelectedAnswerId;
        }

        savedSubTopic!.TotalMisconceptions = updatedSubTopic!.Questions!.Where(i => i.SelectedAnswerId != i.CorrectAnswerId)!.Count();

        var jsonString = JsonSerializer.Serialize(studentTopics, new JsonSerializerOptions { WriteIndented = true });

        // Write the JSON string to a file
        await File.WriteAllTextAsync($"./DataFiles/{studentId}.json", jsonString);

        return await GetStudentTopics(studentId);
    }

    private static async Task<StudentTopics?> Get(string studentId)
    {
        try
        {
            using StreamReader reader = new($"./DataFiles/{studentId}.json");
            var text = await reader.ReadToEndAsync();
            var studentTopics = JsonSerializer.Deserialize<StudentTopics>(text);

            return studentTopics;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}
