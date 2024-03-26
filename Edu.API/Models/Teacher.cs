using System.ComponentModel.DataAnnotations;

namespace Edu.API.Models;

public class Teacher
{
    [Key]
    public long Id { get; set; }
    [Required, MaxLength(60)]
    public string Fullname { get; set; }
    [Required]
    public string Skills { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    public DateTime Birthdate { get; set; }
}
