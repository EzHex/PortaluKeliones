using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class SurveyQuestionOption : IEntityTypeConfiguration<SurveyQuestionOption>
{
    public int Id { get; set; }

    [DisplayName("Tekstas")]
    [Required(ErrorMessage = "Pasirinkimo variantas yra privalomas")]
    public string Text { get; set; } = null!;

    public List<QuestionAnswer>? QuestionAnswers { get; set; }
    public SurveyQuestion SurveyQuestion { get; set; } = null!;
    public int SurveyQuestionId { get; set; }

    public void Configure(EntityTypeBuilder<SurveyQuestionOption> builder)
    {
        // SurveyQuestionOption 1 -> 0...* QuestionAnswer
        builder.HasMany(p => p.QuestionAnswers)
            .WithMany(p => p.SurveyQuestionOptions);

        // SurveyQuestionOption 0...* -> 1 SurveyQuestion
        builder.HasOne(m => m.SurveyQuestion)
            .WithMany(m => m.SurveyQuestionOptions)
            .OnDelete(DeleteBehavior.ClientCascade);
    }
}