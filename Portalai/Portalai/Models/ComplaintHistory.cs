using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class ComplaintHistory : IEntityTypeConfiguration<ComplaintHistory>
{
    public int Id { get; set; }
    [DisplayName("Data")]
    public DateTime Date { get; set; }
    [DisplayName("Būsena")]
    public ComplaintStatus Status { get; set; }
    
    [Required(ErrorMessage = "Komentaras yra privalomas")]
    [DisplayName("Komentaras")]
    public string Comment { get; set; }
    
    public int ComplaintId { get; set; }
    public Complaint Complaint { get; set; }

    public ComplaintHistory(DateTime date, ComplaintStatus status, string comment, Complaint complaint)
    {
        Date = date;
        Status = status;
        Comment = comment;
        Complaint = complaint;
    }
    
    public ComplaintHistory()
    {
    }

    public void Configure(EntityTypeBuilder<ComplaintHistory> builder)
    {
        builder.HasOne(t => t.Complaint)
            .WithMany(t => t.ComplaintHistories)
            .OnDelete(DeleteBehavior.NoAction);
    }
}