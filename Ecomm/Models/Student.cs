using System;
using System.ComponentModel.DataAnnotations;

public class Student
{
    [Key]
    public int StdId { get; set; }
    [Required]
    public string StdFirstName { get; set; }
    [Required]
    public string StdLastName { get; set; }
    [Required]
    public int StdAge { get; set; }
    [Required]
    public DateTime StdBirthDate { get; set; }
    [Required]
    public string StdEmail { get; set; }
    [Required]
    public string StdPassword { get; set; }
    [Required]
    public string StdContact { get; set; }
    [Required]
    public string StdAddress { get; set; }
    public string? ImageFile { get; set; }
}
