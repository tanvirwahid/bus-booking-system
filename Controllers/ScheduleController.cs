using BusBookingSystem.Entities;
using BusBookingSystem.Services.Contracts;

namespace BusBookingSystem.Controllers
{
    public class ScheduleController
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        public async Task<List<Schedule>> GetAll()
        {
            return await _scheduleService.GetAllAsync();
        }

        public async Task<Schedule> Create(
            int coachNumber,
            string departureCity,
            string arrivalCity,
            int ticketPrice,
            DateTime departureTime
        )
        {
            return await _scheduleService.Create(
                coachNumber,
                departureCity,
                arrivalCity,
                ticketPrice,
                departureTime
            );
        }

        public async Task<Schedule> GetById(Guid id)
        {
            return await _scheduleService.GetByIdAsync(id);
        }
    }
}