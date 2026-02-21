using ExamSystem.Enums;
using System.Text.Json.Serialization;

namespace ExamSystem.Models;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
[JsonDerivedType(typeof(McqQuestion), "Mcq")]
[JsonDerivedType(typeof(TFQuestion), "TF")]
public abstract class Question
{
    public QuestType QusetType { get; set; }
    public string QuestBody { get; set; } = string.Empty;
    public List<Answer> Answers { get; set; } = [];


    public override bool Equals(object? obj)
    {
        if (obj is not Question q) return false;
        return QuestBody == q.QuestBody;
    }

    public override int GetHashCode()
    {
        return QuestBody.GetHashCode();
    }

}



