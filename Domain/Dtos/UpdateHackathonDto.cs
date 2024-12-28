namespace Domain.Dtos;

public class UpdateHackathonDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public string Theme { get; set; } 
    public string Location { get; set; } 
    public int MaxTeams { get; set; } 
    public string Description { get; set; }
}