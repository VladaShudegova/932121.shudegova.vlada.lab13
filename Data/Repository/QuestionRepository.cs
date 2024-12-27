using LabWeb13.Generator;
using LabWeb13.Services;

namespace LabWeb13.Data.Repository;

public class QuestionRepository(CalculationService _calculationService)
{
    private Dictionary<Question, int> _answers = new();
    private int _rightAnswersCounter = 0;

    public IEnumerable<KeyValuePair<Question, int>> GetData => _answers;

    public int RightAnswers
    {
        get => _rightAnswersCounter;
        private set => _rightAnswersCounter = value;
    }

    public void InsertUserAnswer(Question question, int userAnswer)
    {
        int rightAnswer =
                _calculationService.Calculate(question.FirstNumber, question.SecondNumber, question.Operation);
        if (rightAnswer == userAnswer)
        {
            _rightAnswersCounter++;
        }

        _answers.Add(question, userAnswer);
    }
}