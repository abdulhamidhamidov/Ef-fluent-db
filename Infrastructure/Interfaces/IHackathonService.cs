using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Responses;

namespace Infrastructure.Interfaces;

public interface IHackathonService
{
    public Task<Response<string>> CreateHackathon(AddHackathonDto data);
    public Task<Response<List<GetHackathonDto>>> GetHackathons();
    public Task<Response<Hackathon>> GetByHackathon(int id);
    public Task<Response<string>> UpdateHackathon(UpdateHackathonDto data);
    public Task<Response<string>> DeleteHackathon(int id);
}