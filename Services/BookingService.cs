using BusBookingSystem.Entities;
using BusBookingSystem.Services.Contracts.Repositories;

namespace BusBookingSystem.Services
{
    public class BookingService : IBookingService
    {
        private readonly IUserRepository _userRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ITicketRepository _ticketRepository;

        public BookingService(
            IUserRepository userRepository,
            IScheduleRepository scheduleRepository,
            IInvoiceRepository invoiceRepository,
            ITicketRepository ticketRepository
        )
        {
            _userRepository = userRepository;
            _scheduleRepository = scheduleRepository;
            _invoiceRepository = invoiceRepository;
            _ticketRepository = ticketRepository;
        }

        public async Task<Invoice> BookSeatAsync(string email, Guid scheduleId, string seatNumber)
        {
            var user = await _userRepository.GetByEmail(new Email(email));

            if (user == null)
            {
                throw new InvalidOperationException("User with email " + email + " does not exist.");
            }

            var schedule = await _scheduleRepository.GetByIdAsync(scheduleId);

            if (schedule == null)
            {
                throw new InvalidOperationException("Schedule with id " + scheduleId + " does not exist.");
            }

            var seat = schedule.FindSeat(seatNumber);

            if (seat == null)
            {
                throw new InvalidOperationException("Seat with number " + seatNumber + " does not exist.");
            }

            seat.Book(user.Id);

            return await _invoiceRepository.AddAsync(new Invoice(user, schedule, seat));
        }

        public async Task<Ticket> ConfirmBookingAsync(string email, Guid invoiceId)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(invoiceId);
            if (invoice is null)
                throw new InvalidOperationException("Invalid invoice");

            var user = await _userRepository.GetByEmail(new Email(email));

            if (user is null)
            {
                throw new InvalidOperationException("User not found");
            }

            var ticket = new Ticket(invoice.Schedule, invoice.Seat, invoice.User);
            invoice.Pay(ticket.Id, user.Id);

            return await _ticketRepository.AddAsync(ticket);
        }
    }
}