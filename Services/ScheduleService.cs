using BusBookingSystem.Entities;
using BusBookingSystem.Services.Contracts;
using BusBookingSystem.Services.Contracts.Repositories;

namespace BusBookingSystem.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IBusRepository _busRepository;
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IBusRepository busRepository, IScheduleRepository scheduleRepository)
        {
            _busRepository = busRepository;
            _scheduleRepository = scheduleRepository;
        }

        public async Task<List<Schedule>> GetAllAsync()
        {
            return await _scheduleRepository.GetAllAsync();
        }

        public async Task<Schedule> CreateAsync(
            int coachNumber,
            string departureCity,
            string arrivalCity,
            int ticketPrice,
            DateTime departureTime
        )
        {
            var bus = await _busRepository.GetByCoachNumberAsync(new CoachNumber(coachNumber));

            if (bus == null)
            {
                throw new InvalidOperationException(
                    "Bus with coach number " + coachNumber + " does not exist."
                );
            }

            var schedule = new Schedule(
                bus,
                departureCity,
                arrivalCity,
                new Price(ticketPrice),
                departureTime
            );

            return await _scheduleRepository.AddAsync(schedule);
        }

        public async Task<Schedule> GetByIdAsync(Guid id)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(id);

            if (schedule == null)
            {
                throw new InvalidOperationException("Schedule with id " + id + " does not exist.");
            }

            return schedule;
        }
    }
}