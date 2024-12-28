using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class PraticipantController(IParticipantService participantService): ControllerBase
{
    [HttpPost]
    public async Task<Response<string>> CreateParticipant(AddParticipantDto data)
    {
        return await participantService.CreateParticipant(data);
    }
    [HttpGet]
    public async Task<Response<List<GetParticipantDto>>> GetParticipants()
    {
        return await participantService.GetParticipants();
    }
    [HttpGet("/by-id=participant")]
    public async Task<Response<Participant>> GetByParticipant(int id)
    {
        return await participantService.GetByParticipant(id);
    }
    [HttpPut]
    public async Task<Response<string>> UpdateParticipant(UpdateParticipantDto data)
    {
        return await participantService.UpdateParticipant(data);
    }
    [HttpDelete]
    public async Task<Response<string>> DeleteParticipant(int id)
    {
        return await participantService.DeleteParticipant(id);
    }
}