using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class SurveyAnswer : IEntityTypeConfiguration<SurveyAnswer>
{
    public int Id { get; set; }
    
    [DisplayName("Atsakymo data")]
    public DateTime AnswerDate { get; set; }
    
    public Survey Survey { get; set; }
    
    

    public void Configure(EntityTypeBuilder<SurveyAnswer> builder)
    {
        
    }
}