using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class QuestionAnswer : IEntityTypeConfiguration<QuestionAnswer>
{
    public int Id { get; set; }
    
    [DisplayName("Answer")]
    public string Answer { get; set; }
    
    public SurveyQuestion SurveyQuestion { get; set; }
    
    public List<SurveyQuestionOption> SurveyQuestionOptions { get; set; }
    
    public void Configure(EntityTypeBuilder<QuestionAnswer> builder)
    {
        throw new NotImplementedException();
    }
}