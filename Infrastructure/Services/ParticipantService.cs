using System.Net;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Datas;
using Infrastructure.Interfaces;
using Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ParticipantService(Context context): IParticipantService
{
    public async Task<Response<string>> CreateParticipant(AddParticipantDto data)
    {
        Participant participant = new Participant();
        participant.Name = data.Name;
        participant.Email = data.Email;
        participant.PhoneNumber = data.PhoneNumber;
        participant.TeamId = data.TeamId;
        participant.Role = data.Role;
        participant.Skills = data.Skills;
        participant.ExperienceLevel = data.ExperienceLevel;
        participant.JoinedDate = data.JoinedDate;
        await context.Participants.AddAsync(participant);
        var res = context.SaveChanges();
        if (res == 0) return new Response<string>(HttpStatusCode.InternalServerError, "Internal Server Error ");
        return new Response<string>("Created");
    }
    public async Task<Response<List<GetParticipantDto>>> GetParticipants()
    {
        var list = await context.Participants.ToListAsync();
        var res = list.Select(p => new GetParticipantDto()
        {
            Id = p.Id,
            Name = p.Name,
            Email = p.Email,
            PhoneNumber = p.PhoneNumber,
            TeamId = p.TeamId,
            Role = p.Role,
            Skills = p.Skills,
            ExperienceLevel = p.ExperienceLevel,
            JoinedDate = p.JoinedDate
        }).ToList();
        
        return new Response<List<GetParticipantDto>>(res.ToList());
        
    }

    public async Task<Response<Participant>> GetByParticipant(int id)
    {
        var res = await context.Participants.FirstOrDefaultAsync(x=>x.Id==id);
        if (res == null) return new Response<Participant>(HttpStatusCode.NotFound,"Not Found");
        return new Response<Participant>(res);
    }
    
    public async Task<Response<string>> UpdateParticipant(UpdateParticipantDto data)
    {
        var res = await context.Participants.FirstOrDefaultAsync(x=>x.Id==data.Id);
        if (res == null) return new Response<string>(HttpStatusCode.NotFound,"Not Found");
        res.Name = data.Name;
        res.Email = data.Email;
        res.PhoneNumber = data.PhoneNumber;
        res.TeamId = data.TeamId;
        res.Role = data.Role;
        res.Skills = data.Skills;
        res.ExperienceLevel = data.ExperienceLevel;
        res.JoinedDate = data.JoinedDate;
    var request = context.SaveChanges();
    if(request==0)return new Response<string>(HttpStatusCode.InternalServerError, "Internal Server Error ");
    return new Response<string>("Updated");
    } 
    public async Task<Response<string>> DeleteParticipant(int id)
    {
        var res = await context.Participants.FirstOrDefaultAsync(x=>x.Id==id);
        if (res == null) return new Response<string>(HttpStatusCode.NotFound,"Not Found");
        context.Participants.Remove(res);
        var request = context.SaveChanges();
        if(request==0)return new Response<string>(HttpStatusCode.InternalServerError, "Internal Server Error ");
        return new Response<string>("Deleted");

    }
}