using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Responses;

namespace Infrastructure.Interfaces;

public interface ITeamService
{
    public Task<Response<string>> CreateTeam(AddTeamDto data);
    public Task<Response<List<GetTeamDto>>> GetTeams();
    public Task<Response<Team>> GetByTeam(int id);
    public Task<Response<string>> UpdateTeam(UpdateTeamDto data);
    public Task<Response<string>> DeleteTeam(int id);
}