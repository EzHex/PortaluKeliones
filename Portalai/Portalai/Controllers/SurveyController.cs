using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portalai.Models;

namespace Portalai.Controllers;

public class SurveyController : Controller
{
    private readonly PortalsDbContext _context;

    public SurveyController(PortalsDbContext context)
    {
        this._context = context;
    }

    public async Task<ActionResult> ShowSurveyList()
    {
        var surveys = await _context.Surveys.ToListAsync();

        if (TempData["status"] != null)
        {
            ViewBag.Status = TempData["status"];
            TempData.Remove("status");
        }

        return View("SurveyList", surveys);
    }

    public async Task<ActionResult> ShowSurvey(int id)
    {
        //get survey with questions and options
        var survey = await _context.Surveys
            .Include(x => x.SurveyQuestions)
            .ThenInclude(x => x.SurveyQuestionOptions)
            .SingleAsync(x => x.Id == id);

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

        _context.Surveys.Update(model);
        await _context.SaveChangesAsync();

        return RedirectToAction("ShowSurvey", new { id = model.Id });
    }


    public async Task<ActionResult> ShowEditForm(int id)
    {
        
        var survey = await _context.Surveys
            .Include(x => x.SurveyQuestions)
            .ThenInclude(x => x.SurveyQuestionOptions)
            .SingleAsync(x => x.Id == id);
        
        return View("SurveyEdit", survey);
    }

    public async Task<ActionResult> ShowDeleteConfirmForm(int id)
    {
        var survey = await _context.Surveys.SingleAsync(x => x.Id == id);
        return View("SurveyDelete", survey);
    }

    public Task<ActionResult> ShowCreateForm()
    {
        Survey survey = new Survey();
        survey.StartDate = DateTime.Now;
        survey.EndDate = DateTime.Now.AddDays(14);
        return Task.FromResult<ActionResult>(View("SurveyCreate", survey));
    }

    [HttpPost]
    public Task<ActionResult> PostCreate(int? save, Survey survey)
    {
        //save of the form data was requested?
        if (save != null)
        {
            //check if the survey has question
            if (survey.SurveyQuestions.Count == 0)
            {
                ModelState.AddModelError("", "Apklausa turi turėti bent vieną klausimą");
            }
            
            //Remove errors for questions ids (they are not in the form), also check if the question has options
            for (int i = 0; i < survey.SurveyQuestions.Count; i++)
            {
                ModelState.Remove($"SurveyQuestions[{i}].Id");
                
                //check if it is multi select or one select
                if (survey.SurveyQuestions[i].Type == QuestionType.SingleChoice ||
                    survey.SurveyQuestions[i].Type == QuestionType.MultipleChoice)
                {
                    //check if the question has options
                    if (survey.SurveyQuestions[i].SurveyQuestionOptions.Count < 2)
                    {
                        // add error to specific question on text field
                        ModelState.AddModelError($"SurveyQuestions[{i}].Question",
                            "Klausimas turi turėti bent du pasirinkimus");
                    }
                }
                //check if it is text
                else if (survey.SurveyQuestions[i].Type == QuestionType.Open)
                {
                    //check if the question has options
                    if (survey.SurveyQuestions[i].SurveyQuestionOptions.Count > 0)
                    {
                        // add error to specific question on text field
                        ModelState.AddModelError($"SurveyQuestions[{i}].Question",
                            "Klausimas negali turėti pasirinkimų");
                    }
                }
                
                //Assign question to survey
                survey.SurveyQuestions[i].Survey = survey;
                
                //Remove errors for surveys
                ModelState.Remove($"SurveyQuestions[{i}].Survey");
                
                //Assing options to question
                for (int j = 0; j < survey.SurveyQuestions[i].SurveyQuestionOptions.Count; j++)
                {
                    survey.SurveyQuestions[i].SurveyQuestionOptions[j].SurveyQuestion = survey.SurveyQuestions[i];
                    //Remove errors :
                    ModelState.Remove($"SurveyQuestions[{i}].SurveyQuestionOptions[{j}].SurveyQuestion");
                }

            }

            //form field validation passed?
            if (ModelState.IsValid)
            {
                //save the survey
                _context.Surveys.Add(survey);
                _context.SaveChanges();

                //save success, go back to the entity list
                return Task.FromResult<ActionResult>(RedirectToAction("ShowSurveyList"));
            }
            //form field validation failed, go back to the form
            else
            {
                return Task.FromResult<ActionResult>(View("SurveyCreate", survey));
            }
        }

        //should not reach here
        throw new Exception("Should not reach here.");
    }


    [HttpPost]
    public async Task<ActionResult> PostAnswers(Survey survey)
    {
        var form = Request.Form;

        //get survery questions and its options
        var surveyGet = await _context.Surveys
            .Include(x => x.SurveyQuestions)
            .ThenInclude(x => x.SurveyQuestionOptions)
            .SingleAsync(x => x.Id == survey.Id);

        survey = surveyGet;

        foreach (var question in survey.SurveyQuestions)
        {
            var isOptionSelected = false;
            if (question.Type == QuestionType.MultipleChoice)
            {
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
                    await _context.SurveyAnswers.AddAsync(surveyAnswer);

                    answer.SurveyAnswer = surveyAnswer;
                    await _context.QuestionAnswers.AddAsync(answer);
                }
            }
            else if (question.Type == QuestionType.SingleChoice)
            {
                foreach (var option in question.SurveyQuestionOptions)
                {
                    if (!form.ContainsKey("question_"+option.Id.ToString()))
                        continue;

                    isOptionSelected = true;
                    
                    var answer = new QuestionAnswer();
                    answer.SurveyQuestion = question;
                    answer.SurveyQuestionOptions.Add(option);
                    answer.Answer = form["question_"+option.Id.ToString()];
                    
                    var surveyAnswer = new SurveyAnswer();
                    surveyAnswer.AnswerDate = DateTime.Now;
                    surveyAnswer.SurveyId = survey.Id;
                    survey.SurveyAnswers.Add(surveyAnswer);
                    await _context.SurveyAnswers.AddAsync(surveyAnswer);
                    
                    answer.SurveyAnswer = surveyAnswer;
                    await _context.QuestionAnswers.AddAsync(answer);
                }
            }
            else
            {
                if (!form.ContainsKey(question.Id.ToString()))
                    continue;
                
                isOptionSelected = true;
                
                var answer = new QuestionAnswer();
                answer.SurveyQuestion = question;
                answer.Answer = form[question.Id.ToString()];
                
                var surveyAnswer = new SurveyAnswer();
                surveyAnswer.AnswerDate = DateTime.Now;
                surveyAnswer.SurveyId = survey.Id;
                survey.SurveyAnswers.Add(surveyAnswer);
                await _context.SurveyAnswers.AddAsync(surveyAnswer);
                
                answer.SurveyAnswer = surveyAnswer;
                await _context.QuestionAnswers.AddAsync(answer);
            }
            
            if (!isOptionSelected)
            {
                ModelState.AddModelError("",
                    $"Bent vienas atsakymas turi būti pasirinktas klausimui: '{question.Question}'.");
            }
        }

        if (!ModelState.IsValid)
            return View("Survey", survey);

        await _context.SaveChangesAsync();
        return RedirectToAction("ShowSurveyList");
    }

    public IActionResult PostEdit(Survey survey)
    {
        //Set survey for each question
        for (var i = 0; i < survey.SurveyQuestions.Count; i++)
        {
            survey.SurveyQuestions[i].Survey = survey;
            
            //Remove error
            ModelState.Remove($"SurveyQuestions[{i}].Survey");
            
            //Remove error for ID
            ModelState.Remove($"SurveyQuestions[{i}].Id");
            
            //Set question for each option
            for (var j = 0; j < survey.SurveyQuestions[i].SurveyQuestionOptions.Count; j++)
            {
                survey.SurveyQuestions[i].SurveyQuestionOptions[j].SurveyQuestion = survey.SurveyQuestions[i];
                
                //Remove error
                ModelState.Remove($"SurveyQuestions[{i}].SurveyQuestionOptions[{j}].SurveyQuestion");
                
                //Remove error for ID
                ModelState.Remove($"SurveyQuestions[{i}].SurveyQuestionOptions[{j}].Id");
            }
        }

        //modelstate
        if (ModelState.IsValid)
        {
            //TODO handle changes because update doesn't remove old options @Vickyyy
            //save the survey
            _context.Surveys.Update(survey);
            _context.SaveChanges();

            //save success, go back to the entity list
            return RedirectToAction("ShowSurveyList");
        }
        //form field validation failed, go back to the form
        else
        {
            return View("SurveyEdit", survey);
        }
    }

    public IActionResult DeleteSurvey(int id)
    {
        //find the survey
        var survey = _context.Surveys.Find(id);
        
        //remove the survey
        if (survey != null) _context.Surveys.Remove(survey);
        _context.SaveChanges();
        
        //go back to the entity list
        return RedirectToAction("ShowSurveyList");
    }
}