using System.Net;
using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Datas;
using Infrastructure.Interfaces;
using Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class TeamService(Context context): ITeamService
{
    public async Task<Response<string>> CreateTeam(AddTeamDto data)
    {
        Team team = new Team();
        team.Id=data.Id;
        team.Name=data.Name;
        team.CreatedDate=data.CreatedDate;
        team.Leader=data.Leader;
        team.TotalMembers=data.TotalMembers;
        team.Score=data.Score;
        team.Status=data.Status;
        team.HackathonId=data.HackathonId;
        await context.Teams.AddAsync(team);
        var res = context.SaveChanges();
        if (res == 0) return new Response<string>(HttpStatusCode.InternalServerError, "Internal Server Error ");
        return new Response<string>("Created");
    }
    public async Task<Response<List<GetTeamDto>>> GetTeams()
    {
        var list = await context.Teams.Include(h=>h.Participants).ToListAsync();
        var res = list.Select(t => new GetTeamDto()
        {
            Id = t.Id,
            Name = t.Name,
            CreatedDate = t.CreatedDate,
            Leader = t.Leader,
            TotalMembers = t.TotalMembers,
            Score = t.Score,
            Status = t.Status,
            Participants = t.Participants.Select(p => new GetParticipantDto()
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
            }).ToList()
        }).ToList();
        
        return new Response<List<GetTeamDto>>(res.ToList());
        
    }

    public async Task<Response<Team>> GetByTeam(int id)
    {
        var res = await context.Teams.FirstOrDefaultAsync(x=>x.Id==id);
        if (res == null) return new Response<Team>(HttpStatusCode.NotFound,"Not Found");
        return new Response<Team>(res);
    }

    public async Task<Response<string>> UpdateTeam(UpdateTeamDto data)
    {
        var res = await context.Teams.FirstOrDefaultAsync(x=>x.Id==data.Id);
        if (res == null) return new Response<string>(HttpStatusCode.NotFound,"Not Found");
        res.Name=data.Name;
        res.CreatedDate=data.CreatedDate;
        res.Leader=data.Leader;
        res.TotalMembers=data.TotalMembers;
        res.Score=data.Score;
        res.Status=data.Status;
        res.HackathonId=data.HackathonId;
    var request = context.SaveChanges();
    if(request==0)return new Response<string>(HttpStatusCode.InternalServerError, "Internal Server Error ");
    return new Response<string>("Updated");
    } 
    public async Task<Response<string>> DeleteTeam(int id)
    {
        var res = await context.Teams.FirstOrDefaultAsync(x=>x.Id==id);
        if (res == null) return new Response<string>(HttpStatusCode.NotFound,"Not Found");
        context.Teams.Remove(res);
        var request = context.SaveChanges();
        if(request==0)return new Response<string>(HttpStatusCode.InternalServerError, "Internal Server Error ");
        return new Response<string>("Deleted");

    }
}