namespace Medicines.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class MedicinesContext : DbContext
    {
        public MedicinesContext()
        {
        }

        public MedicinesContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Medicine> Medicines { get; set; } = null!;

        public DbSet<Patient> Patients { get; set; } = null!;

        public DbSet<PatientMedicine> PatientsMedicines { get; set; } = null!;

        public DbSet<Pharmacy> Pharmacies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientMedicine>(opt => opt.HasKey(pm => new { pm.MedicineId, pm.PatientId }));
        }
    }
}
