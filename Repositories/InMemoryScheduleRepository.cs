using BusBookingSystem.Entities;
using BusBookingSystem.Services.Contracts.Repositories;

namespace BusBookingSystem.Repositories
{
    public class InMemoryScheduleRepository : IScheduleRepository
    {
        private List<Schedule> _schedules = new List<Schedule>();

        public Task<List<Schedule>> GetAllAsync()
        {
            return Task.FromResult(_schedules.ToList());
        }

        public Task<Schedule> AddAsync(Schedule schedule)
        {
            var exists = _schedules.Any(
                s => schedule.DepartureTime.Equals(s.DepartureTime)
                    && schedule.BusId == s.BusId
            );

            if (exists)
            {
                throw new InvalidOperationException("Schedule with same departure time already exists.");
            }

            _schedules.Add(schedule);
            return Task.FromResult(schedule);
        }

        public Task<Schedule?> GetByIdAsync(Guid id)
        {
            var schedule = _schedules.FirstOrDefault(s => s.Id == id);
            return Task.FromResult(schedule);
        }
    }
}
