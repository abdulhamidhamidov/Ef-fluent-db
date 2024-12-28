using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;


[ApiController]
[Route("/api/[controller]")]
public class TeamController(ITeamService participantService): ControllerBase
{
    [HttpPost]
    public async Task<Response<string>> CreateTeam(AddTeamDto data)
    {
        return await participantService.CreateTeam(data);
    }
    [HttpGet]
    public async Task<Response<List<GetTeamDto>>> GetTeams()
    {
        return await participantService.GetTeams();
    }
    [HttpGet("/by-id-teamgit ")]
    public async Task<Response<Team>> GetByTeam(int id)
    {
        return await participantService.GetByTeam(id);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateTeam(UpdateTeamDto data)
    {
        return await participantService.UpdateTeam(data);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteTeam(int id)
    {
        return await participantService.DeleteTeam(id);
    }
}