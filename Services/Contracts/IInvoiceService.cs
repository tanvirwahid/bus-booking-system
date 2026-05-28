using BusBookingSystem.Entities;

namespace BusBookingSystem.Services.Contracts
{
    public interface IInvoiceService
    {
        Task<List<Invoice>> GetInvoiceByUserAsync(Guid userId);
    }
}