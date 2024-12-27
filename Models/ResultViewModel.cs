using LabWeb13.Generator;

namespace LabWeb13.Models;

public class ResultViewModel
{
    public int CorrectAnswersAmount { get; set; }
    public IEnumerable<KeyValuePair<Question, int>> Data { get; set; }
    public int AnswersAmount => Data.Count();
}