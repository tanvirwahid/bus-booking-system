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

        public async Task<Invoice> BookSeatAsync(string email, Guid scheduleId, string seatNumber)
        {
            return await _bookingService.BookSeatAsync(email, scheduleId, seatNumber);
        }

        public async Task<Ticket> ConfirmBookingAsync(string userEmail, Guid invoiceId)
        {
            return await _bookingService.ConfirmBookingAsync(userEmail, invoiceId);
        }
    }
}