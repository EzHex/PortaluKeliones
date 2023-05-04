using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class Complaint : IEntityTypeConfiguration<Complaint>
{
    public int Id { get; set; }
    [DisplayName("Pateikimo data")]
    public DateTime SubmisionDate { get; set; }
    [DisplayName("Aprašymas")]
    public string Description { get; set; }
    [DisplayName("Būsena")]
    public ComplaintStatus Status { get; set; }
    
    public Portal Portal { get; set; }
    
    public List<ComplaintHistory> ComplaintHistories { get; set; }

    public Complaint(DateTime submisionDate, string description, ComplaintStatus status)
    {
        SubmisionDate = submisionDate;
        Description = description;
        Status = status;
    }

    public void Configure(EntityTypeBuilder<Complaint> builder)
    {
        builder.HasOne(p => p.Portal)
            .WithMany(c => c.Complaints)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(p=> p.ComplaintHistories)
            .WithOne(c => c.Complaint)
            .OnDelete(DeleteBehavior.Cascade);
    }
}