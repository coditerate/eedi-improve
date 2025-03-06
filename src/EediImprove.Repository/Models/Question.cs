namespace EediImprove.Repository.Models;

public class Question
{
    public int QuestionId { get; set; }

    public string? QuestionDescription { get; set; }

    public Answer? AnswerA { get; set; }

    public Answer? AnswerB { get; set; }

    public Answer? AnswerC { get; set; }

    public Answer? AnswerD { get; set; }

    public int CorrectAnswerId { get; set; }

    public int? SelectedAnswerId { get; set; }
}
