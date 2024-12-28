using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class HackathonController(IHackathonService participantService): ControllerBase
{
    [HttpPost]
    public async Task<Response<string>> CreateHackathon(AddHackathonDto data)
    {
        return await participantService.CreateHackathon(data);
    }
    [HttpGet]
    public async Task<Response<List<GetHackathonDto>>> GetHackathons()
    {
        return await participantService.GetHackathons();
    }
    [HttpGet("/by-id")]
    public async Task<Response<Hackathon>> GetByHackathon(int id)
    {
        return await participantService.GetByHackathon(id);
    }
    [HttpPut]
    public async Task<Response<string>> UpdateHackathon(UpdateHackathonDto data)
    {
        return await participantService.UpdateHackathon(data);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteHackathon(int id)
    {
        return await participantService.DeleteHackathon(id);
    }
}