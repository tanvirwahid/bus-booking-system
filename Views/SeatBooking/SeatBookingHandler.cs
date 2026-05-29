using BusBookingSystem.Container;
using BusBookingSystem.Views.Contracts;
using BusBookingSystem.Views.Readers;

namespace BusBookingSystem.Views.SeatBooking
{
    public class SeatBookingHandler : View
    {
        private readonly StringInputReader _stringReader;
        private readonly GuidReader _guidReader;

        public SeatBookingHandler(
            StringInputReader stringReader,
            GuidReader guidReader
        )
        {
            _stringReader = stringReader;
            _guidReader = guidReader;
        }

        public async Task Render()
        {
            Console.WriteLine("Book A Seat: ");
            var email = _stringReader.ReadRequired("Enter user email: ");
            var scheduleId = _guidReader.ReadRequired("Enter schedule id: ");
            var seatNumber = _stringReader.ReadRequired("Enter seat numbers separated by comma (1A, 1B, 1C etc): ");

            var bookingController = AppContainer.Instance.GetBookingController();
            var invoice = await bookingController.BookSeatAsync(email, scheduleId, seatNumber);

            Console.WriteLine("Seat Booking Confirm. Please Confirm Booking By Making Payment In 5 Minutes");
            Console.WriteLine("Invoice: ");
            Console.WriteLine(invoice);
        }
    }
}