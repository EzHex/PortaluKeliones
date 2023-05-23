using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class Portal : IEntityTypeConfiguration<Portal>
{
    [DisplayName("ID")] public int Id { get; set; }
    
    [DisplayName("Pavadinimas")]
    [Required(ErrorMessage = "Pavadinimas privalomas")]
    [StringLength(50, ErrorMessage = "Pavadinimas negali būti ilgesnis nei 50 simbolių")]
    public string Name { get; set; }

    [DisplayName("Ilguma")]
    [Range(-180, 180)]
    public double Longitude { get; set; }

    [DisplayName("Platuma")]
    [Range(-90, 90)]
    public double Latitude { get; set; }
    
    [Range(1, double.MaxValue, ErrorMessage = "Skysčio talpa privalo būti didesnė už 1."), ]
    [DisplayName("Skysčio talpa")] public double LiquidCapacity { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Dabartinis skysčio kiekis privalo būti didesnis arba lygus 0.")]
    [DisplayName("Esamas skysčio kiekis")] public double CurrentLiquidLevel { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Kaina turi būti didėsne  už 0")]
    [DisplayName("Teleportacijos kaina")] public double TeleportPrice { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Teleportacijų skaičus turi būti didesnis arba lygus 0")]
    [DisplayName("Teleportacijų skaičius")]
    public double TeleportCount { get; set; }

    [DisplayName("Būsena")] public PortalStatus Status { get; set; }

    public PortalJunction? PortalJunction { get; set; }

    [DisplayName("Besijungiančio portalo ID")]
    [NotMapped]
    public int? JunctionPortalId { get; set; }

    public List<Complaint>? Complaints { get; set; }


    public void Configure(EntityTypeBuilder<Portal> builder)
    {
        // 0 to 1 relation
        builder.HasOne(p => p.PortalJunction)
            .WithMany(p => p.Portals)
            .HasForeignKey(p => p.PortalJunction)
            .OnDelete(DeleteBehavior.SetNull)
            .IsRequired(false);
    }
}