using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SeminarHub.Data
{
    using Configurations;
    using Extensions.ModelBuilderExtensions;
    using Models;

    public class SeminarHubDbContext : IdentityDbContext
    {
        public SeminarHubDbContext(DbContextOptions<SeminarHubDbContext> options)
            : base(options)
        {
        }

        public DbSet<Seminar> Seminars { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<SeminarParticipant> SeminarsParticipants { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new SeminarParticipantConfiguration());

            builder.Seed();

            base.OnModelCreating(builder);
        }
    }
}