namespace Domain.Dtos;

public class AddTeamDto
{
    public int Id { get; set; } 
    public string Name { get; set; } 
    public int HackathonId { get; set; } 
    public DateTime CreatedDate { get; set; } 
    public string Leader { get; set; } 
    public int TotalMembers { get; set; } 
    public int Score { get; set; } 
    public string Status { get; set; } 
}