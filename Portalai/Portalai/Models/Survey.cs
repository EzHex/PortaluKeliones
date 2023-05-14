using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class Survey : IEntityTypeConfiguration<Survey>
{
    public int Id { get; set; }
    
    [DisplayName("Aprašymas")]
    public string Description { get; set; }
    [DisplayName("Pradžios data")]
    public DateTime StartDate { get; set; }
    [DisplayName("Pabaigos data")]
    public DateTime EndDate { get; set; }
    [DisplayName("Pavadinimas")]
    public string Title { get; set; }
    [DisplayName("Būsena")]
    public SurveyStatus Status { get; set; }
    
    public List<SurveyQuestion> SurveyQuestions { get; set; } = new List<SurveyQuestion>();
    
    public List<SurveyAnswer> SurveyAnswers { get; set; } = new List<SurveyAnswer>();
    
    public void Configure(EntityTypeBuilder<Survey> builder)
    {
        builder.HasMany(p => p.SurveyQuestions)
            .WithOne(p => p.Survey)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(p => p.SurveyAnswers)
            .WithOne(p => p.Survey)
            .OnDelete(DeleteBehavior.NoAction);
    }
}