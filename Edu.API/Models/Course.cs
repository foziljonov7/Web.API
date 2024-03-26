using System.ComponentModel.DataAnnotations;

namespace Edu.API.Models;

public class Course
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime Duration { get; set; }
    [Required]
    public long TeacherId { get; set; }
    public virtual Teacher Teacher { get; set; }
}
