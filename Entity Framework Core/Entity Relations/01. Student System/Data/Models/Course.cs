namespace P01_StudentSystem.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Course
{
    public Course()
    {
        this.Students = new HashSet<Student>();
        this.Resources = new HashSet<Resource>();
        this.Homeworks = new HashSet<Homework>();
        this.StudentsCourses = new HashSet<StudentCourse>();
    }
    public int CourseId { get; set; }
    [Required]
    [MaxLength(80)]
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Price { get; set; }
    public ICollection<Student> Students { get; set; }
    public ICollection<Resource> Resources { get; set; }
    public ICollection<Homework> Homeworks { get; set; }
    public ICollection<StudentCourse> StudentsCourses { get; set; }
}