using System.Net;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Datas;
using Infrastructure.Interfaces;
using Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class HackathonService(Context context): IHackathonService
{
    public async Task<Response<string>> CreateHackathon(AddHackathonDto data)
    {
        Hackathon hackathon = new Hackathon();
        hackathon.Name = data.Name;
        hackathon.MaxTeams = data.MaxTeams;
        hackathon.Date = data.Date;
        hackathon.Description = data.Description;
        hackathon.Location = data.Location;
        hackathon.Theme = data.Theme;
        await context.Hackathons.AddAsync(hackathon);
        var res = context.SaveChanges();
        if (res == 0) return new Response<string>(HttpStatusCode.InternalServerError, "Internal Server Error ");
        return new Response<string>("Created");
    }
    public async Task<Response<List<GetHackathonDto>>> GetHackathons()
    {
        var list = await context.Hackathons.Include(h=>h.Teams).ToListAsync();
        var res = list.Select(h => new GetHackathonDto()
        {
            Id = h.Id,
            Name = h.Name,
            Date = h.Date,
            Theme=h.Theme,
            Location=h.Location,
            MaxTeams=h.MaxTeams,
            Description=h.Description,
            Teams = h.Teams.Select(t=> new GetTeamDto()
            {
                Id=t.Id,
                Name = t.Name,
                CreatedDate = t.CreatedDate,
                Leader = t.Leader,
                TotalMembers=t.TotalMembers,
                Score = t.Score,
                Status = t.Status,
                Participants = t.Participants.Select(p=>new GetParticipantDto()
                {
                    Id = p.Id,
                    Name= p.Name,
                    Email=p.Email,
                    PhoneNumber=p.PhoneNumber,
                    TeamId= p.TeamId,
                    Role=p.Role,
                    Skills=p.Skills,
                    ExperienceLevel=p.ExperienceLevel,
                    JoinedDate=p.JoinedDate
                }).ToList()
            }).ToList()
            
        });
        
        return new Response<List<GetHackathonDto>>(res.ToList());
        
    }

    public async Task<Response<Hackathon>> GetByHackathon(int id)
    {
        var res = await context.Hackathons.FirstOrDefaultAsync(x=>x.Id==id);
        if (res == null) return new Response<Hackathon>(HttpStatusCode.NotFound,"Not Found");
        return new Response<Hackathon>(res);
    }

    public async Task<Response<string>> UpdateHackathon(UpdateHackathonDto data)
    {
        var res = await context.Hackathons.FirstOrDefaultAsync(x=>x.Id==data.Id);
        if (res == null) return new Response<string>(HttpStatusCode.NotFound,"Not Found");
        res.Name = data.Name;
    res.Date = data.Date;
    res.Theme = data.Theme;
    res.Location = data.Location;
    res.MaxTeams = data.MaxTeams;
    res.Description = data.Description;
    var request = context.SaveChanges();
    if(request==0)return new Response<string>(HttpStatusCode.InternalServerError, "Internal Server Error ");
    return new Response<string>("Updated");
    } 
    public async Task<Response<string>> DeleteHackathon(int id)
    {
        var res = await context.Hackathons.FirstOrDefaultAsync(x=>x.Id==id);
        if (res == null) return new Response<string>(HttpStatusCode.NotFound,"Not Found");
        context.Hackathons.Remove(res);
        var request = context.SaveChanges();
        if(request==0)return new Response<string>(HttpStatusCode.InternalServerError, "Internal Server Error ");
        return new Response<string>("Deleted");

    }
}