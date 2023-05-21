using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class SurveyQuestion : IEntityTypeConfiguration<SurveyQuestion>
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Klausimas yra privalomas")]
    [DisplayName("Klausimas")]
    public string Question { get; set; }

    [DisplayName("Tipas")]
    [Required(ErrorMessage = "Klausimo tipas yra privalomas")]
    public QuestionType Type { get; set; }

    [DisplayName("Privalomumas")]
    [Required(ErrorMessage = "Būtina nūrodyti klausimo būtinumą")]
    public bool IsRequired { get; set; }

    [DisplayName("Eilės numeris")]
    [Required(ErrorMessage = "Eilės numeris yra privalomas")]
    [Range(1, 100, ErrorMessage = "Eilės numeris turi būti tarp 1 ir 100")]
    public int Order { get; set; }


    public List<QuestionAnswer>? QuestionAnswers { get; set; } = new();
    public List<SurveyQuestionOption> SurveyQuestionOptions { get; set; } = new();
    public Survey Survey { get; set; } = null!;
    public int SurveyId { get; set; }

    public void Configure(EntityTypeBuilder<SurveyQuestion> builder)
    {
        // SurveyQuestion 1 -> 0...* QuestionAnswer
        builder.HasMany(p => p.QuestionAnswers)
            .WithOne(p => p.SurveyQuestion)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        // SurveyQuestion 1...* -> 1 Survey
        builder.HasOne(m => m.Survey)
            .WithMany(m => m.SurveyQuestions)
            .HasForeignKey(m => m.SurveyId)
            .IsRequired()
            .OnDelete(DeleteBehavior.ClientCascade);

        // SurveyQuestion 1 -> 0...* SurveyQuestionOption
        builder.HasMany(m => m.SurveyQuestionOptions)
            .WithOne(m => m.SurveyQuestion)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);
    }
}