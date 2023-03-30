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
    public string Role { get; set; }

    public void Configure(EntityTypeBuilder<User> builder)
    {
        throw new NotImplementedException();
    }
}