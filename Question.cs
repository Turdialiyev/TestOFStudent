// using MultipleChoiceQuizApp;
using System.Runtime.CompilerServices;
public class Question
{
    public string? Content { get; set; }
    public Dictionary<EOption,string>? Options {get;set;}
    private EOption Answer ;
    public Question(String content,Dictionary<EOption,string> options, EOption answer)
    {
        Content = content;
        Options = options;
        Answer  = answer;
    }
    public bool IsCorrect(EOption option)
    {
     return option == Answer;  
    }
    public override string ToString()
    {
        string temp = @"";
        foreach (var value in Options)
        {
            temp += $"\n{value.Key}  {value.Value} ";
        }
        string result = $@"{Content} {temp}";
        return result;
    }
}