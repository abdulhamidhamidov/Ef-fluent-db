using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Responses;

namespace Infrastructure.Interfaces;

public interface IParticipantService
{
    public Task<Response<string>> CreateParticipant(AddParticipantDto data);
    public Task<Response<List<GetParticipantDto>>> GetParticipants();
    public Task<Response<Participant>> GetByParticipant(int id);
    public Task<Response<string>> UpdateParticipant(UpdateParticipantDto data);
    public Task<Response<string>> DeleteParticipant(int id);
}