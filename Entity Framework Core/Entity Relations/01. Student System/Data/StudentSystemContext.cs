namespace P01_StudentSystem.Data;

using Microsoft.EntityFrameworkCore;
using Models;

public class StudentSystemContext : DbContext
{
    public StudentSystemContext() { }

    public StudentSystemContext(DbContextOptions options)
        : base(options) { }
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Resource> Resources { get; set; }
    public DbSet<Homework> Homeworks { get; set; }
    public DbSet<StudentCourse> StudentsCourses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=EFCRelations;User Id=sa;Password=yourStrong(!)Password;TrustServerCertificate=True");
        }
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentCourse>(x =>
        {
            x.HasKey(k => new { k.StudentId, k.CourseId });
        });
        base.OnModelCreating(modelBuilder);
    }
}