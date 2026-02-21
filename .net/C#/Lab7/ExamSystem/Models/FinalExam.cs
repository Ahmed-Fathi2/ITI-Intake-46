namespace ExamSystem.Models;
public class FinalExam:Exam
{
    public override void Display(List<Question> examQuestions)
    {
        var answerOrderNum = 1;
        var score = 0;
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


            Console.Write($"Enter Your  Answer [1-{q.Answers.Count}]: ");

            stdAns= Helper.ValidateAnswers(q);

            if (q.Answers[stdAns - 1].AnswerBody == ExamBank[q].AnswerBody)
            {
                score++;
            }

            Console.WriteLine("======================================================================");
            Console.WriteLine("======================================================================");
        }

        CalculateResult(score, examQuestions);
    }

    private void CalculateResult(int score, List<Question> examQuestions)
    {
        Console.WriteLine("======================================================================");
        Console.WriteLine("======================================================================");
        if (score >= examQuestions.Count / 2)
            Console.WriteLine($"Passed Sucsessfully , With Score : {score}/{examQuestions.Count}");

        else
            Console.WriteLine($" Failed !!!!\n Your Score : {score}/{examQuestions.Count}\n Try Again! ");
    }




}
