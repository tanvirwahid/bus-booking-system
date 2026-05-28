using BusBookingSystem.Entities;

namespace BusBookingSystem.Services.Contracts
{
    public interface ITicketService
    {
        Task<List<Ticket>> GetTicketsByUserIdAsync(Guid userId);
    }
}