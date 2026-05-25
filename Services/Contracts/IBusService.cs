using BusBookingSystem.Entities;

namespace BusBookingSystem.Services.Contracts
{
    public interface IBusService
    {
        Task<List<Bus>> GetAllBuses();
        Task<Bus> Create(int coachNumber, int type);
    }
}