using BusBookingSystem.Entities;
using BusBookingSystem.Services;

namespace BusBookingSystem.Controllers
{
    public class BookingController
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task<Invoice> BookSeatAsync(string email, Guid scheduleId, string seatNumbers)
        {
            return await _bookingService.BookSeatAsync(email, scheduleId, seatNumbers);
        }

        public async Task<Ticket> ConfirmBookingAsync(string userEmail, Guid invoiceId)
        {
            return await _bookingService.ConfirmBookingAsync(userEmail, invoiceId);
        }
    }
}