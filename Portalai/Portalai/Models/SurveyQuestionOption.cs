using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class SurveyQuestionOption : IEntityTypeConfiguration<SurveyQuestionOption>
{
    public int Id { get; set; }
    [DisplayName("Varianto numeris")]
    public int Number { get; set; }
    [DisplayName("Tekstas")]
    public string Text { get; set; }
    
    public SurveyQuestion SurveyQuestion { get; set; }
    
    public List<QuestionAnswer> QuestionAnswers { get; set; }
    
    public void Configure(EntityTypeBuilder<SurveyQuestionOption> builder)
    {
        builder.HasMany(p => p.QuestionAnswers)
            .WithMany(p => p.SurveyQuestionOptions);
    }
}