using ExamSystem.Consts;
using ExamSystem.Enums;
using ExamSystem.Models;
using System.Text.Json;

namespace ExamSystem;
public  class Helper
{

    public static Dictionary<Question, Answer> SeedExamQuestAns(List<Question> questions)
    {
        Dictionary<Question, Answer> examBank = new();



        examBank[questions[0]] = questions[0].Answers[0];

        examBank[questions[1]] = questions[1].Answers[1];

        examBank[questions[2]] = questions[2].Answers[2];

        examBank[questions[3]] = questions[3].Answers[0];

        examBank[questions[4]] = questions[4].Answers[0];

        examBank[questions[5]] = questions[5].Answers[0];

        examBank[questions[6]] = questions[6].Answers[2];

        examBank[questions[7]] = questions[7].Answers[0];

        examBank[questions[8]] = questions[8].Answers[3];

        examBank[questions[9]] = questions[9].Answers[1];

        return examBank;
    }

    public static List<Question> SeedQuestion()
    {

        List<Question> questions = new List<Question>
            {
                new McqQuestion
                {
                    QuestBody = "Which keyword is used to create an object in C#?",
                    QusetType = QuestType.Mcq,
                    Answers = new()
                    {
                        new Answer { AnswerBody = "new" }, //1 
                        new Answer { AnswerBody = "create" },//2
                        new Answer { AnswerBody = "object" },//3
                        new Answer { AnswerBody = "class" }//4
                    }
                },
                new TFQuestion
                {
                    QuestBody = "C# supports multiple inheritance using classes",
                    QusetType = QuestType.TF,
                    Answers = new()
                    {
                        new Answer { AnswerBody = "True" },
                        new Answer { AnswerBody = "False" }
                    }
                },
                new McqQuestion
                {
                    QuestBody = "Which of the following is a value type?",
                    QusetType = QuestType.Mcq,
                    Answers = new()
                    {
                        new Answer { AnswerBody = "String" },
                        new Answer { AnswerBody = "Array" },
                        new Answer { AnswerBody = "Int32" },
                        new Answer { AnswerBody = "Class" }
                    }
                },
                new TFQuestion
                {
                    QuestBody = "The Main method is the entry point of a C# program",
                    QusetType = QuestType.TF,
                    Answers = new()
                    {
                        new Answer { AnswerBody = "True" },
                        new Answer { AnswerBody = "False" }
                    }
                },
                new McqQuestion
                {
                    QuestBody = "Which keyword is used to prevent inheritance?",
                    QusetType = QuestType.Mcq,
                    Answers = new()
                    {
                        new Answer { AnswerBody = "sealed" },
                        new Answer { AnswerBody = "static" },
                        new Answer { AnswerBody = "const" },
                        new Answer { AnswerBody = "readonly" }
                    }
                },
                new TFQuestion
                {
                    QuestBody = "An interface can contain method implementations",
                    QusetType = QuestType.TF,
                    Answers = new()
                    {
                        new Answer { AnswerBody = "True" },
                        new Answer { AnswerBody = "False" }
                    }
                },
                new McqQuestion
                {
                    QuestBody = "Which collection does NOT allow duplicate values?",
                    QusetType = QuestType.Mcq,
                    Answers = new()
                    {
                        new Answer { AnswerBody = "List" },
                        new Answer { AnswerBody = "Array" },
                        new Answer { AnswerBody = "HashSet" },
                        new Answer { AnswerBody = "Dictionary" }
                    }
                },
                new TFQuestion
                {
                    QuestBody = "Garbage Collector manages memory automatically in C#",
                    QusetType = QuestType.TF,
                    Answers = new()
                    {
                        new Answer { AnswerBody = "True" },
                        new Answer { AnswerBody = "False" }
                    }
                },
                new McqQuestion
                {
                    QuestBody = "Which keyword is used to handle exceptions?",
                    QusetType = QuestType.Mcq,
                    Answers = new()
                    {
                        new Answer { AnswerBody = "try" },
                        new Answer { AnswerBody = "catch" },
                        new Answer { AnswerBody = "finally" },
                        new Answer { AnswerBody = "All of the above" }
                    }
                },
                new TFQuestion
                {
                    QuestBody = "Structs are reference types in C#",
                    QusetType = QuestType.TF,
                    Answers = new()
                    {
                        new Answer { AnswerBody = "True" },
                        new Answer { AnswerBody = "False" }
                    }
                }
            };


        string json = JsonSerializer.Serialize(questions, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(DataPath.questionPath, json);

        return questions;
    }

    public static List<Question> GetAllQuestions()
    {
        string jsonFromFile = File.ReadAllText(DataPath.questionPath);
        var examQuestions = JsonSerializer.Deserialize<List<Question>>(jsonFromFile)!;   
        return examQuestions;
    }

    public static void GetExamTypes()
    {
        Console.WriteLine("============================================================");
        Console.WriteLine("============================================================");

        Console.WriteLine("choose Exam Type: ");
        Console.WriteLine("1- Practical Exam");
        Console.WriteLine("2- Final Exam");

        Console.WriteLine("============================================================");
        Console.WriteLine("============================================================");

        Console.Write("Choose ExamType [1-2]: ");
    }

    public static int ValidateExamType()
    {
        var isExamNumValid = false;
        var examtype = 0;

        while (!isExamNumValid)
        {
            isExamNumValid = int.TryParse(Console.ReadLine(), out examtype);
            if (!isExamNumValid)
            {
                Console.Write("Please enter Valid exam number [1-2] : ");
            }
            else if (examtype != 1 && examtype != 2)
            {
                Console.Write("Please enter Valid exam number [1-2] : ");
                isExamNumValid = false;
            }

        }
        return examtype;
    }

    public static int ValidateAnswers(Question q)
    {
        var isValid = false;
        var stdAns = 0;


        while (!isValid)
        {
            isValid = int.TryParse(Console.ReadLine(), out stdAns);

            if (!isValid)
            {
                Console.Write($"Please enter Valid Answer Number [1-{q.Answers.Count}] : ");
            }
            else if (!(0 < stdAns && stdAns <= q.Answers.Count))
            {
                Console.Write($"Please enter Valid  Answer Number [1-{q.Answers.Count}] : ");
                isValid = false;
            }

        }

        return stdAns;
    }

    public static void ClearConsole()
    {

        Console.Clear();

    }
}
