using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class SurveyQuestion : IEntityTypeConfiguration<SurveyQuestion>
{
    public int Id { get; set; }
    
    [DisplayName("Klausimas")]
    public string Question { get; set; }
    [DisplayName("Tipas")]
    public QuestionType Type { get; set; }
    [DisplayName("Privalomumas")]
    public bool IsRequired { get; set; }
    [DisplayName("Eilės numeris")]
    public int Order { get; set; }
    
    public Survey Survey { get; set; }
    
    public List<QuestionAnswer> QuestionAnswers { get; set; }
    
    public List<SurveyQuestionOption> SurveyQuestionOptions { get; set; }

    public SurveyQuestion(int id, string question, QuestionType type, bool isRequired, int order)
    {
        Id = id;
        Question = question;
        Type = type;
        IsRequired = isRequired;
        Order = order;
    }

    public void Configure(EntityTypeBuilder<SurveyQuestion> builder)
    {
        builder.HasMany(p=> p.QuestionAnswers)
            .WithOne(p=> p.SurveyQuestion);

        builder.HasMany(p => p.SurveyQuestionOptions)
            .WithOne(p => p.SurveyQuestion)
            .OnDelete(DeleteBehavior.NoAction);
    }
}