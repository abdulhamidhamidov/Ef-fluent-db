﻿using Domain.Entities;

namespace Domain.Dtos;

public class AddParticipantDto
{
    public string Name { get; set; } 
    public string Email { get; set; }
    public string PhoneNumber { get; set; } 
    public int TeamId { get; set; }
    public string Role { get; set; }
    public string Skills { get; set; }
    public string ExperienceLevel { get; set; } 
    public DateTime JoinedDate { get; set; }

    public Team Team { get; set; }
}