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

    [HttpPost]
    public async Task<ActionResult> PostAnswers(Survey survey)
    {
        var form = Request.Form;
        
        var surveyQuestions = await context.SurveyQuestions.Where(x => x.Survey.Id == survey.Id).ToListAsync();
        var surveyQuestionOptions = await context.SurveyQuestionOptions.Where(x => x.SurveyQuestion.Survey.Id == survey.Id).ToListAsync();

        survey.SurveyQuestions = surveyQuestions;
        survey.SurveyQuestions.ForEach(x => x.SurveyQuestionOptions = surveyQuestionOptions.Where(y => y.SurveyQuestion.Id == x.Id).ToList());

        foreach (var question in survey.SurveyQuestions)
        {
            var isOptionSelected = false;
            foreach (var option in question.SurveyQuestionOptions)
            {
                if (!form.ContainsKey(option.Id.ToString())) 
                    continue;
                
                isOptionSelected = true;
                    
                var answer = new QuestionAnswer();
                answer.SurveyQuestion = question;
                answer.SurveyQuestionOptions.Add(option);
                answer.Answer = form[option.Id.ToString()];
                
                var surveyAnswer = new SurveyAnswer();
                surveyAnswer.AnswerDate = DateTime.Now;
                surveyAnswer.SurveyId = survey.Id;
                survey.SurveyAnswers.Add(surveyAnswer);
                await context.SurveyAnswers.AddAsync(surveyAnswer);

                answer.SurveyAnswer = surveyAnswer;
                await context.QuestionAnswers.AddAsync(answer);
            }
            
            if (!isOptionSelected)
            {
                ModelState.AddModelError("", $"Bent vienas atsakymas turi būti pasirinktas klausimui: '{question.Question}'.");
            }
        }

        if (!ModelState.IsValid) 
            return View("Survey", survey);
        
        await context.SaveChangesAsync();
        return RedirectToAction("ShowSurveyList");

    }
}