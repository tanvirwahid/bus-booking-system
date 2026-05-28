using BusBookingSystem.Entities;

namespace BusBookingSystem.Services.Contracts.Repositories
{
    public interface IInvoiceRepository
    {
        Task<List<Invoice>> GetByUserIdAsync(Guid userId);
        Task<Invoice> AddAsync(Invoice schedule);
        Task<Invoice?> GetByIdAsync(Guid id);
    }
}