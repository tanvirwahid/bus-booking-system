using BusBookingSystem.Entities;
using BusBookingSystem.Services.Contracts;
using BusBookingSystem.Services.Contracts.Repositories;

namespace BusBookingSystem.Services
{
    public class TicketService : ITicketService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITicketRepository _ticketRepository;

        public TicketService(
            IUserRepository userRepository,
            ITicketRepository ticketRepository
        )
        {
            _userRepository = userRepository;
            _ticketRepository = ticketRepository;
        }

        public async Task<List<Ticket>> GetTicketsByUserIdAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user is null)
                throw new InvalidOperationException("Invalid user id");

            return await _ticketRepository.GetByUserIdAsync(userId);
        }
    }
}