using Lab13.Models;
using LabWeb13.Generator;
using LabWeb13.Models;
using Microsoft.AspNetCore.Mvc;
using LabWeb13.Data.Repository;

namespace LabWeb13.Controllers;

public class QuizController(QuestionGenerator _generator, QuestionRepository _questionRepository) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        Question question = _generator.GenerateQuestion();
        var questionModel = new QuestionViewModel { Question = question };
        return View(questionModel);
    }

    [HttpPost]
    public IActionResult Index(QuestionViewModel viewModel)
    {
        _questionRepository.InsertUserAnswer(viewModel.Question, viewModel.Answer);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Result()
    {
        var model = new ResultViewModel
        {
                CorrectAnswersAmount = _questionRepository.RightAnswers,
                Data = _questionRepository.GetData
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Result(QuestionViewModel viewModel)
    {
        _questionRepository.InsertUserAnswer(viewModel.Question, viewModel.Answer);
        return RedirectToAction("Result");
    }
}