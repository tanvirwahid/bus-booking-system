
using BusBookingSystem.Entities;

namespace BusBookingSystem.Services.Contracts.Repositories
{
    public interface IBusRepository
    {
        Task<List<Bus>> GetAllAsync();
        Task<Bus> AddAsync(Bus bus);
        Task<Bus?> GetByCoachNumberAsync(CoachNumber coachNumber);
    }
}