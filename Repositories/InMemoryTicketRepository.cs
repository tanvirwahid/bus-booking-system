using BusBookingSystem.Entities;
using BusBookingSystem.Services.Contracts.Repositories;

namespace BusBookingSystem.Repositories
{
    public class InMemoryTicketRepository : ITicketRepository
    {
        private List<Ticket> _tickets = new List<Ticket>();

        public Task<Ticket> AddAsync(Ticket ticket)
        {
            var exists = _tickets.Any(
                t => t.ScheduleId == ticket.ScheduleId
                && t.SeatId == ticket.SeatId
            );

            if (exists)
            {
                throw new InvalidOperationException("Duplicate ticket");
            }

            _tickets.Add(ticket);
            return Task.FromResult(ticket);
        }

        public Task<List<Ticket>> GetByUserIdAsync(Guid userId)
        {
            var tickets = _tickets.Where(t => t.UserId == userId);
            return Task.FromResult(tickets.ToList());
        }
    }
}