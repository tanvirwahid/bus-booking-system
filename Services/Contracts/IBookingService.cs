using BusBookingSystem.Entities;

namespace BusBookingSystem.Services
{
    public interface IBookingService
    {
        Task<Invoice> BookSeatAsync(string email, Guid scheduleId, string seatNumber);
        Task<Ticket> ConfirmBookingAsync(string email, Guid invoiceId);
    }
}