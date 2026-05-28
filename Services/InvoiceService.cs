using BusBookingSystem.Entities;
using BusBookingSystem.Services.Contracts;
using BusBookingSystem.Services.Contracts.Repositories;

namespace BusBookingSystem.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUserRepository _userRepository;
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(
            IInvoiceRepository invoiceRepository,
            IUserRepository userRepository
        )
        {
            _invoiceRepository = invoiceRepository;
            _userRepository = userRepository;
        }

        public async Task<List<Invoice>> GetInvoiceByUserAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user is null)
                throw new InvalidOperationException("Invalid user id");

            return await _invoiceRepository.GetByUserIdAsync(userId);
        }
    }
}