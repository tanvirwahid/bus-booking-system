using BusBookingSystem.Container;
using BusBookingSystem.Views.Contracts;
using BusBookingSystem.Views.Readers;

namespace BusBookingSystem.Views.SeatBooking
{
    public class SeatBookingConfirmationHandler : View
    {
        private readonly StringInputReader _stringReader;
        private readonly GuidReader _guidReader;

        public SeatBookingConfirmationHandler(
            StringInputReader stringReader,
            GuidReader guidReader
        )
        {
            _stringReader = stringReader;
            _guidReader = guidReader;
        }

        public async Task Render()
        {
            var email = _stringReader.ReadRequired("Enter user email: ");
            var invoiceId = _guidReader.ReadRequired("Enter invoice id: ");

            var bookingController = AppContainer.Instance.GetBookingController();
            var ticket = await bookingController.ConfirmBookingAsync(email, invoiceId);

            Console.WriteLine("Seat booking confirmed.");
            Console.WriteLine("Ticket: ");
            Console.WriteLine(ticket);
        }
    }
}