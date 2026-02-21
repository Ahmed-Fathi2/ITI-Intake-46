using ExamSystem.Consts;
using ExamSystem.Enums;
using ExamSystem.Models;
using System.Text.Json;

namespace ExamSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var questions = Helper.SeedQuestion();

            var examBank = Helper.SeedExamQuestAns(questions);

            var examQuestions = Helper.GetAllQuestions();

            Helper.GetExamTypes();
            var examtype = Helper.ValidateExamType();

            Helper.ClearConsole();

            //PracticalExam 
            if (examtype == 1)
            {
                var practicalExam = new PracticalExam()
                {
                    ExamType = ExamType.PracticalExam,
                    ExamName = "C#",
                    ExamBank = examBank

                };
                practicalExam.Display(examQuestions);
                //practicalExam.DisplayModelAnswer();
            }
            //FinalExam
            else
            {
                var finalExam = new FinalExam()
                {
                    ExamType = ExamType.FinalExam,
                    ExamName = "C#",
                    ExamBank = examBank

                };
                finalExam.Display(examQuestions);
                //finalExam.DisplayModelAnswer();
            }



        }














        //foreach (var q in examQuestions)
        //{
        //    isValid = false;
        //    Console.WriteLine($" {q.QusetType}--->>>{q.QuestBody}");


        //    foreach (var a in q.Answers)
        //    {
        //        Console.WriteLine($"- {a.AnswerBody}");
        //    }

        //    Console.WriteLine("Enter your Correct Answer:");

        //    while (!isValid)
        //    {
        //     isValid=int.TryParse(Console.ReadLine(), out var stdAns);

        //        Console.WriteLine(isValid);
        //        if(!isValid)
        //            Console.WriteLine("Please enter Valid #ans");
        //        else
        //        {
        //            answers.Add(stdAns);
        //            //isValid = true;

        //        }

        //    }

        //    //Console.WriteLine("=============================================");
        //    //Console.WriteLine(stdAns);
        //    //Console.WriteLine("=============================================");




        //}

        //string stdAnswersJson = JsonSerializer.Serialize(answers, new JsonSerializerOptions
        //{
        //    WriteIndented = true
        //});

        //File.WriteAllText(DataPath.studentAnsPath, stdAnswersJson);


        //foreach (var answer in answers)
        //{
        //    Console.WriteLine(answer);
        //}







        //var s = new FinalExam()
        //{
        //    ExamName = "scm",
        //    ExamType = ExamType.FinalExam,
        //    ExamBank = examBank


        //};

        //Console.WriteLine("----------------------------------");
        //Console.WriteLine(s.ExamBank[9]);

        //int score = 0;

        //for (int i = 0; i < answers.Count; i++)
        //{
        //    if (answers[i] == s.ExamBank[i+1])
        //        score++;

        //}

        //Console.WriteLine("==============  Score  =================");

        //Console.WriteLine($"my score is {score}");














    }
    }

