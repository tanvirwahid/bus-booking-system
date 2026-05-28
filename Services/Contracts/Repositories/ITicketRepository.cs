using BusBookingSystem.Entities;

namespace BusBookingSystem.Services.Contracts.Repositories
{
    public interface ITicketRepository
    {
        Task<Ticket> AddAsync(Ticket ticket);
        Task<List<Ticket>> GetByUserIdAsync(Guid userId);
    }
}