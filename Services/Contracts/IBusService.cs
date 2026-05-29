using BusBookingSystem.Entities;

namespace BusBookingSystem.Services.Contracts
{
    public interface IBusService
    {
        Task<List<Bus>> GetAllBusesAsync();
        Task<Bus> CreateAsync(int coachNumber, int type);
    }
}