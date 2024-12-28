using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Participant
{
    public int Id { get; set; } 
    [Required]
    public string Name { get; set; } 
    [Required,EmailAddress]
    public string Email { get; set; }
    [Required,Phone]
    public string PhoneNumber { get; set; } 
    [ForeignKey("Team")]
    public int TeamId { get; set; }
    [Required]
    public string Role { get; set; }
    [Required]
    public string Skills { get; set; }
    [Required]
    public string ExperienceLevel { get; set; } 
    public DateTime JoinedDate { get; set; }

    public Team Team { get; set; }
}