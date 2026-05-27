using BusBookingSystem.Entities;

namespace BusBookingSystem.Services.Contracts
{
    public interface IScheduleService
    {
        Task<List<Schedule>> GetAllAsync();
        Task<Schedule> Create(
            int coachNumber,
            string departureCity,
            string arrivalCity,
            int ticketPrice,
            DateTime departureTime
        );
        Task<Schedule> GetByIdAsync(Guid id);
    }
}