using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Portalai.Models;

namespace Portalai.Controllers;

public class SurveyController : Controller
{
    private readonly PortalsDbContext context;

    public SurveyController(PortalsDbContext context)
    {
        this.context = context;
    }

    public async Task<ActionResult> ShowSurveyList()
    {
        var surveys = await context.Surveys.ToListAsync();

        return View("SurveyList", surveys);
    }
    
    public async Task<ActionResult> ShowSurvey(int id)
    {
        var survey = await context.Surveys.SingleAsync(x => x.Id == id);
        var surveyQuestions = await context.SurveyQuestions.Where(x => x.Survey.Id == id).ToListAsync();
        var surveyQuestionOptions = await context.SurveyQuestionOptions.Where(x => x.SurveyQuestion.Survey.Id == id).ToListAsync();

        survey.SurveyQuestions = surveyQuestions;
        survey.SurveyQuestions.ForEach(x => x.SurveyQuestionOptions = surveyQuestionOptions.Where(y => y.SurveyQuestion.Id == x.Id).ToList());
        
        return View("Survey", survey);
    }
}