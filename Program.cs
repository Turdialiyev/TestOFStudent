

using System.Linq;
using System.Net.Mime;
using System.Collections.Generic;
using System;
using System.IO;

class Program
{
    public static void Main(string[] args)
    {

        var directionOfFile = Directory.GetCurrentDirectory();
        var textOfAnswers = Path.Combine(directionOfFile, "math.txt");
        using var sra = File.OpenText(textOfAnswers);
        var CopyOfTxt = new List<string>();
        var answersOfTxt = new List<string>();
        var directoryOfOptions = new Dictionary<EOption,string>();
        string? txt ="";
        while ((txt = sra.ReadLine()) != null)
        {
            CopyOfTxt.Add(txt);
        }
        
        List<Question> questionOfTxt = new List<Question>();
        int indexOfAnswer = 0;

        for (int i = 0; i < CopyOfTxt.Count; i++)
        {
            string questionContent = CopyOfTxt[i];
            var arrEnums = Enum.GetValues<EOption>();
           if(char.IsDigit(CopyOfTxt[i][0]))
           {
                Dictionary<EOption, string> dictionaryOpstions = new Dictionary<EOption, string>();
                string questionOfContent = CopyOfTxt[i];
                int numberEnum = 0;
                for (int j = i + 1; j <= CopyOfTxt.Count-1 ; j++)
                {
                    if (!char.IsDigit(CopyOfTxt[j][0]))
                    {
                        string? option = CopyOfTxt[j];
                        // int count = ;
                        if( option[option.Length-1] == '*')
                        { 
                            answersOfTxt.Add(option.Substring(0,1));
                            option = (option.Remove(option.Length-1,1));
                        }
                        option = option.Substring(2);
                        dictionaryOpstions.Add(arrEnums[numberEnum], option);
                        numberEnum++;
                    }
                    else
                    {
                        break;
    
                    }
                }
                var charListAnswer = answersOfTxt[indexOfAnswer].First(x => char.IsLetter(x));
                foreach (var item in arrEnums)
                {
                    if (charListAnswer == item.ToString()[0])
                    {
                      EOption rightAnswer = item;
                      Question question = new Question(questionOfContent, dictionaryOpstions, rightAnswer);
                      questionOfTxt.Add(question); 
                    }
                }
           }

                        
        }

        Test test = new Test("Matem", questionOfTxt, 60);
        test.TakeTest();

    }
}


