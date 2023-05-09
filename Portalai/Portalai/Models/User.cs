using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portalai.Models;

public class User : IEntityTypeConfiguration<User>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public Roles Role { get; set; }
    public List<Ticket> Tickets { get; set; }

    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(t => t.Tickets)
            .WithOne(u => u.User)
            .OnDelete(DeleteBehavior.NoAction);
    }
}