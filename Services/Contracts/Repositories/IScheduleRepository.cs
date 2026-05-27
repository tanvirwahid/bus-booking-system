using BusBookingSystem.Entities;

namespace BusBookingSystem.Services.Contracts.Repositories
{
    public interface IScheduleRepository
    {
        Task<List<Schedule>> GetAllAsync();
        Task<Schedule> AddAsync(Schedule schedule);
        Task<Schedule?> GetByIdAsync(Guid id);
    }
}