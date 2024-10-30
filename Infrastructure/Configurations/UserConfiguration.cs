using Domain.Features.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User) + "s");

            builder.OwnsOne(x => x.Email);
            builder.OwnsOne(x => x.FirstName);
            builder.OwnsOne(x => x.LastName);
        }
    }
}
