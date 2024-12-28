using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Team
{
    public int Id { get; set; } 
    [Required]
    public string Name { get; set; } 
    [ForeignKey("Hackathon")]
    public int HackathonId { get; set; } 
    public DateTime CreatedDate { get; set; } 
    [Required]
    public string Leader { get; set; } 
    public int TotalMembers { get; set; } 
    public int Score { get; set; } 
    [Required]
    public string Status { get; set; } 

    public ICollection<Participant> Participants { get; set; }

    public Hackathon Hackathon { get; set; }
}