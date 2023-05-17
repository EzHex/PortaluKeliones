using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        
        if (TempData["status"] != null)
        {
            ViewBag.Status = TempData["status"];
            TempData.Remove("status");
        }

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
    public async Task<ActionResult> ChangeState(Survey model)
    {
        if (model.Status == SurveyStatus.Created)
        {
            model.Status = SurveyStatus.Active;
        }
        else if (model.Status == SurveyStatus.Active)
        {
            model.Status = SurveyStatus.Closed;
        }
        
        context.Surveys.Update(model);
        await context.SaveChangesAsync();
        
        return RedirectToAction("ShowSurvey", new {id = model.Id});
    }
    
    
    public async Task<ActionResult> ShowEditForm(int id)
    {
        var survey = await context.Surveys.SingleAsync(x => x.Id == id);
        return View("SurveyEdit", survey);
    }
    
    public async Task<ActionResult> ShowDeleteConfirmForm(int id)
    {
        var survey = await context.Surveys.SingleAsync(x => x.Id == id);
        return View("SurveyDelete", survey);
    }
    
    public async Task<ActionResult> ShowCreateForm()
    {
        Survey survey = new Survey();
        return View("SurveyCreate", survey);
    }
    
    [HttpPost]
    public async Task<ActionResult> postCreate(int? save, int? add, int? remove, Survey survey)
    {
        if( add != null )
        {
            int id = survey.SurveyQuestions.Count > 0 ? survey.SurveyQuestions.Max(it => it.Id) + 1 : 0;
            //add entry for the new record
            var up =
                new SurveyQuestion(id, null, 0, false, 0);
            survey.SurveyQuestions.Add(up);

            //make sure @Html helper is not reusing old model state containing the old list
            ModelState.Clear();
            
            //go back to the form
            return View("SurveyCreate", survey);
        }

        //removal of existing 'UzsakytosPaslaugos' record was requested?
        if( remove != null )
        {
            //filter out 'UzsakytosPaslaugos' record having in-list-id the same as the given one
            survey.SurveyQuestions =
                survey.SurveyQuestions
                    .Where(it => it.Id != remove.Value)
                    .ToList();

            //make sure @Html helper is not reusing old model state containing the old list
            ModelState.Clear();

            //go back to the form
            return View("SurveyCreate", survey);
        }

        /*//save of the form data was requested?
        if( save != null )
        {
            //form field validation passed?
            if( ModelState.IsValid )
            {
                //create new 'Sutartis'
                sutartisEvm.Sutartis.Nr = SutartisRepo.Insert(sutartisEvm);

                //create new 'UzsakytosPaslaugos' records
                foreach( var upVm in sutartisEvm.UzsakytosPaslaugos )
                    UzsakytaPaslaugaRepo.Insert(sutartisEvm.Sutartis.Nr, upVm);

                //save success, go back to the entity list
                return RedirectToAction("ShowSurveyList");
            }
            //form field validation failed, go back to the form
            else
            {
                return View("SurveyCreate", survey);
            }
        }*/

        //should not reach here
        throw new Exception("Should not reach here.");
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