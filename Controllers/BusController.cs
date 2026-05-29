using BusBookingSystem.Entities;
using BusBookingSystem.Services.Contracts;

namespace BusBookingSystem.Controllers
{
    public class BusController
    {
        private readonly IBusService _busService;

        public BusController(IBusService busService)
        {
            _busService = busService;
        }

        public async Task<List<Bus>> GetAllAsync()
        {
            return await _busService.GetAllBusesAsync();
        }

        public async Task<Bus> CreateAsync(int coachNumber, int type)
        {
            return await _busService.CreateAsync(coachNumber, type);
        }
    }
}
