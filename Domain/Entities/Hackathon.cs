using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Hackathon
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public DateTime Date { get; set; }
    [Required]
    public string Theme { get; set; } 
    [Required]
    public string Location { get; set; } 
    [Required]
    public int MaxTeams { get; set; } 
    [Required]
    public string Description { get; set; }

    public List<Team> Teams { get; set; }
}