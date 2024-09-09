using Domain.Features.Players;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    internal sealed class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable(nameof(Player) + "s");

            builder.OwnsOne(x => x.FirstName);
            builder.OwnsOne(x => x.LastName);
        }
    }
}
