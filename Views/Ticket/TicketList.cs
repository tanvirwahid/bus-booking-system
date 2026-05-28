using BusBookingSystem.Container;
using BusBookingSystem.Views.Contracts;
using BusBookingSystem.Views.Readers;

namespace BusBookingSystem.Views.Ticket
{
    public class TicketList : View
    {
        private readonly GuidReader _guidReader;

        public TicketList(GuidReader guidReader)
        {
            _guidReader = guidReader;
        }

        public async Task Render()
        {
            var userId = _guidReader.ReadRequired("Enter user id: ");
            var ticketController = AppContainer.Instance.GetTicketController();

            var tickets = await ticketController.GetByUserIdAsync(userId);

            Console.WriteLine("Ticket list: ");

            foreach (var ticket in tickets)
            {
                Console.WriteLine(ticket);
            }
        }
    }
}