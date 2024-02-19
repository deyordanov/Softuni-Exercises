namespace SeminarHub.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

public class SeminarParticipantConfiguration : IEntityTypeConfiguration<SeminarParticipant>
{
    public void Configure(EntityTypeBuilder<SeminarParticipant> builder)
    {
        builder
            .HasKey(sp => new { sp.ParticipantId, sp.SeminarId });

        builder
            .HasOne(e => e.Seminar)
            .WithMany(e => e.SeminarsParticipants)
            .OnDelete(DeleteBehavior.Restrict);
    }
}