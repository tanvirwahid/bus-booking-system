using BusBookingSystem.Entities;
using BusBookingSystem.Services.Contracts;

namespace BusBookingSystem.Controllers
{
    public class TicketController
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public async Task<List<Ticket>> GetByUserIdAsync(Guid userId)
        {
            return await _ticketService.GetTicketsByUserIdAsync(userId);
        }
    }
}