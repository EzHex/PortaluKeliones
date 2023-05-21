using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class Survey : IEntityTypeConfiguration<Survey>
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Aprašymas yra privalomas")]
    [DisplayName("Aprašymas")]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = "Pradžios data yra privaloma")]
    [DisplayName("Pradžios data")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "Pabaigos data yra privaloma")]
    [DisplayName("Pabaigos data")]
    public DateTime EndDate { get; set; }

    [Required(ErrorMessage = "Pavadinimas yra privalomas")]
    [DisplayName("Pavadinimas")]
    public string Title { get; set; } = null!;

    [DisplayName("Būsena")] public SurveyStatus Status { get; set; }

    public List<SurveyQuestion> SurveyQuestions { get; set; } = new();

    public List<SurveyAnswer>? SurveyAnswers { get; set; } = new();

    public void Configure(EntityTypeBuilder<Survey> builder)
    {
        // Survey 1 -> 0...* SurveyAnswer
        builder.HasMany(p => p.SurveyAnswers)
            .WithOne(p => p.Survey)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        // Survey 1 -> 1...* SurveyQuestion
        builder.HasMany(p => p.SurveyQuestions)
            .WithOne(m => m.Survey)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}