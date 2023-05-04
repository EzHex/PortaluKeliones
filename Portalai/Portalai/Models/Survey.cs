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
    
    public List<SurveyQuestion> SurveyQuestions { get; set; }
    
    public List<SurveyAnswer> SurveyAnswers { get; set; }
    
    public void Configure(EntityTypeBuilder<Survey> builder)
    {
        builder.HasMany(p => p.SurveyQuestions)
            .WithOne(p => p.Survey)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.SurveyAnswers)
            .WithOne(p => p.Survey)
            .OnDelete(DeleteBehavior.Cascade);
    }
}