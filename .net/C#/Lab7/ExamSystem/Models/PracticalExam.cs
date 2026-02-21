namespace ExamSystem.Models;
public class PracticalExam:Exam
{
    public override void Display(List<Question> examQuestions)
    {
        
        var answerOrderNum = 1;
        var stdAns = 0;

        Console.WriteLine("========================================");
        Console.WriteLine($"ExamType:{ExamType}");
        Console.WriteLine($"ExamName:{ExamName}");
        Console.WriteLine($"ExamDateTime:{ExamDate}");
        Console.WriteLine("========================================");


        foreach (var q in examQuestions)
        {
            answerOrderNum = 1;
            Console.WriteLine($" {q.QusetType}--->>>{q.QuestBody}");

            foreach (var a in q.Answers)
            {
                Console.WriteLine($"{answerOrderNum}- {a.AnswerBody}");
                answerOrderNum++;
            }

            Console.Write($"Enter Your Answer [1-{q.Answers.Count}]:");

            stdAns= Helper.ValidateAnswers(q);

            Console.WriteLine($"Your Answer is :{q.Answers[stdAns-1].AnswerBody}");
            Console.WriteLine($"Correct Answer is :{ExamBank[q].AnswerBody}");
            Console.WriteLine("======================================================================");
            Console.WriteLine("======================================================================");

        }

    }

  
}
