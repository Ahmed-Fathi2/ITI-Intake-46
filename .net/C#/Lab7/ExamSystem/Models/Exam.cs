using ExamSystem.Enums;
namespace ExamSystem.Models;
public abstract  class Exam
{
    public ExamType ExamType { get; set; }
    public string ExamName { get; set; }=string.Empty;
    public DateTime ExamDate { get; set; }=DateTime.UtcNow;

    public Dictionary<Question, Answer> ExamBank = new();

    public abstract void Display(List<Question> questions);

    public virtual void DisplayModelAnswer()
    { 
        Console.WriteLine("\n\n======================================  Model Answer ==========================================\n\n");
        foreach (var exam in ExamBank)
        {
            Console.WriteLine($"{exam.Key.QuestBody}=======>>{exam.Value.AnswerBody}\n");
        }
        Console.WriteLine("====================================================================================================");

    }




}

