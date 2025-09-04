using Application.Common.Interfaces;
using Domain.Features.Players;
using Domain.Features.Teams;
using Domain.Features.Users;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { }

        public DbSet<User> User { get; set; }

        public DbSet<Player> Player { get; set; }

        public DbSet<Team> Team { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
