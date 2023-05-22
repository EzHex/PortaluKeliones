using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class Portal : IEntityTypeConfiguration<Portal>
{
    [DisplayName("ID")] public int Id { get; set; }

    [DisplayName("Ilguma")]
    [Range(-180, 180)]
    public double Longitude { get; set; }

    [DisplayName("Platuma")]
    [Range(-90, 90)]
    public double Latitude { get; set; }

    [DisplayName("Skysčio talpa")] public double LiquidCapacity { get; set; }

    [DisplayName("Esamas skysčio kiekis")] public double CurrentLiquidLevel { get; set; }

    [DisplayName("Teleportacijos kaina")] public double TeleportPrice { get; set; }

    [DisplayName("Teleportacijų skaičius")]
    public double TeleportCount { get; set; }

    [DisplayName("Būsena")] public PortalStatus Status { get; set; }

    public PortalJunction? PortalJunction { get; set; }

    [DisplayName("Besijungiančio portalo ID")]
    [NotMapped]
    public int JunctionPortalId { get; set; }

    public List<Complaint>? Complaints { get; set; }


    public void Configure(EntityTypeBuilder<Portal> builder)
    {
        // 0 to 1 relation
        builder.HasOne(p => p.PortalJunction)
            .WithMany(p => p.Portals)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);
    }
}