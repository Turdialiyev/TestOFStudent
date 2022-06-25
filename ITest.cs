public interface ITest
{
    string Name { get; set; }
    List<Question> Questions { get; set; }
    int PassingPercentage { get; set; }

}