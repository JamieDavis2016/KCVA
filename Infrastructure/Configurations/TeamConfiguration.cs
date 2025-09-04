using Domain.Features.Teams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    internal sealed class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable(nameof(Team) + "s");

            builder.OwnsOne(x => x.Name);
        }
    }
}
