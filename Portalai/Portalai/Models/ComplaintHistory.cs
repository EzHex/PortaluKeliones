using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class ComplaintHistory : IEntityTypeConfiguration<ComplaintHistory>
{
    public int Id { get; set; }
    [DisplayName("Data")]
    public DateTime Date { get; set; }
    [DisplayName("Būsena")]
    public ComplaintStatus Status { get; set; }
    [DisplayName("Komentaras")]
    public string Comment { get; set; }
    
    public Complaint Complaint { get; set; }

    public void Configure(EntityTypeBuilder<ComplaintHistory> builder)
    {
        builder.HasOne(t => t.Complaint)
            .WithMany(t => t.ComplaintHistories)
            .OnDelete(DeleteBehavior.NoAction);
    }
}