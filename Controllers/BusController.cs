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

        public async Task<List<Bus>> GetAll()
        {
            return await _busService.GetAllBuses();
        }

        public async Task<Bus> Create(int coachNumber, int type)
        {
            return await _busService.Create(coachNumber, type);
        }
    }
}
