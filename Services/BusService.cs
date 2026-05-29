using System.ComponentModel.DataAnnotations;
using BusBookingSystem.Entities;
using BusBookingSystem.Services.Contracts;
using BusBookingSystem.Services.Contracts.Repositories;

namespace BusBookingSystem.Services
{
    public class BusService : IBusService
    {
        private readonly IBusRepository _busRepository;

        public BusService(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        public async Task<List<Bus>> GetAllBusesAsync()
        {
            return await _busRepository.GetAllAsync();
        }

        public async Task<Bus> CreateAsync(int coachNumber, int type)
        {
            if (!Enum.IsDefined(typeof(BusType), type))
            {
                throw new InvalidOperationException("Invalid bus type value");
            }

            var bus = new Bus(new CoachNumber(coachNumber), (BusType)type);

            var exists = await _busRepository.GetByCoachNumberAsync(bus.CoachNumber);

            if (exists != null)
            {
                throw new InvalidOperationException("Bus with same coach number already exists.");
            }

            return await _busRepository.AddAsync(bus);
        }
    }
}