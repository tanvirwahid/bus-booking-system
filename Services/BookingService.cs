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

        public async Task<Invoice> BookSeatAsync(string email, Guid scheduleId, string seatNumbers)
        {
            var user = await _userRepository.GetByEmailAsync(new Email(email));

            if (user == null)
            {
                throw new InvalidOperationException("User with email " + email + " does not exist.");
            }

            var schedule = await _scheduleRepository.GetByIdAsync(scheduleId);

            if (schedule == null)
            {
                throw new InvalidOperationException("Schedule with id " + scheduleId + " does not exist.");
            }

            var seatNumberList = seatNumbers
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToList();

            var seats = schedule.BookedSeats(seatNumberList, user.Id);

            return await _invoiceRepository.AddAsync(new Invoice(user, schedule, seats));
        }

        public async Task<Ticket> ConfirmBookingAsync(string email, Guid invoiceId)
        {
            var invoice = await _invoiceRepository.GetByIdAsync(invoiceId);
            if (invoice is null)
                throw new InvalidOperationException("Invalid invoice");

            var user = await _userRepository.GetByEmailAsync(new Email(email));

            if (user is null)
            {
                throw new InvalidOperationException("User not found");
            }

            var ticket = new Ticket(invoice.Schedule, invoice.Seats, invoice.User);
            invoice.Pay(ticket.Id, user.Id);

            return await _ticketRepository.AddAsync(ticket);
        }
    }
}