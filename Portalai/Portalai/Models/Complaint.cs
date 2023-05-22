using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    
    [DisplayName("Portalo ID")]
    public Portal Portal { get; set; }
    
    [DisplayName("Kliento ID")]
    public User User { get; set; }
    
    public List<ComplaintHistory> ComplaintHistories { get; set; }

    [Required(ErrorMessage = "Komentaras yra privalomas")]
    [DisplayName("Komentaras")]
    [NotMapped] public string? Comment { get; set; }
    

    public void Configure(EntityTypeBuilder<Complaint> builder)
    {
        builder.HasOne(p => p.Portal)
            .WithMany(c => c.Complaints)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(p=> p.ComplaintHistories)
            .WithOne(c => c.Complaint)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(p => p.User)
            .WithMany(c => c.Complaints)
            .OnDelete(DeleteBehavior.Cascade);
    }
}