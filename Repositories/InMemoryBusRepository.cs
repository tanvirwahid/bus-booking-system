using BusBookingSystem.Entities;
using BusBookingSystem.Services.Contracts.Repositories;

namespace BusBookingSystem.Repositories
{
    public class InMemoryBusRepository : IBusRepository
    {
        private List<Bus> _buses = new List<Bus>();

        public Task<List<Bus>> GetAllAsync()
        {
            return Task.FromResult(_buses.ToList());
        }

        public Task<Bus> AddAsync(Bus bus)
        {
            var exists = _buses.Any(b => b.CoachNumber.Equals(bus.CoachNumber));

            if (exists)
            {
                throw new InvalidOperationException("Bus with same coach number already exists.");
            }

            _buses.Add(bus);
            return Task.FromResult(bus);
        }

        public Task<Bus?> GetByCoachNumberAsync(CoachNumber coachNumber)
        {
            var bus = _buses.FirstOrDefault(b => b.CoachNumber.Equals(coachNumber));

            return Task.FromResult(bus);
        }
    }

}
