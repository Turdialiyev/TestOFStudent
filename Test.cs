using System.Runtime.CompilerServices;
public class Test : ITest
{

    public string Name { get; set; }
    public List<Question> Questions { get; set; }
    public int PassingPercentage { get; set; }
    public Test(string name, List<Question> questions, int passingPercentage)
    {
        Name = name;
        Questions = questions;
        PassingPercentage = passingPercentage;
    }


    public void PrintQuestions()
    {
        Console.WriteLine($"Assalomu alekum {Name} testiga xush kelibsiz");
        Console.WriteLine($"Ushbu testdan o'tish foizi minimum {PassingPercentage}%");

        foreach (var item in Questions)
        {
            Console.WriteLine(item.ToString());
        }
    }

    public void TakeTest()
    {
        PrintQuestions();

        int percentOfAnswer = 0;

        for (int i = 0; i < Questions.Count; i++)
        {
            Console.WriteLine($"{i + 1} - entering your answer (olny latter) :");
            var answer = Console.ReadLine();
            var arrEnums = Enum.GetValues<EOption>();
            foreach (var item in arrEnums)
            {
                if (answer == item.ToString())
                {
                    EOption option = item;
                    if (Questions[i].IsCorrect(option))
                    {
                        percentOfAnswer += (100 / Questions.Count);
                        Console.WriteLine("anwer only D");
                    }
                    else
                    {
                        Console.WriteLine($"False");
                    }
                }
            }

           
        }

        if (percentOfAnswer > PassingPercentage)
        {
            Console.WriteLine($@"Testdan muvafaqqiyatli o'tdingiz,
            sizda to'g'ri javoblar foizi {percentOfAnswer}%");
        }
        else
        {
            Console.WriteLine($@"Afsuski testdan o'ta olmadingiz, olgan 
             sizda to'g'ri javoblar foizi {percentOfAnswer}");
        }

    }


}