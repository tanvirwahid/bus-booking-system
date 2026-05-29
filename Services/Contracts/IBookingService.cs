using BusBookingSystem.Entities;

namespace BusBookingSystem.Services
{
    public interface IBookingService
    {
        Task<Invoice> BookSeatAsync(string email, Guid scheduleId, string seatNumbers);
        Task<Ticket> ConfirmBookingAsync(string email, Guid invoiceId);
    }
}