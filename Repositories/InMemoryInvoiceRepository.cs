using BusBookingSystem.Entities;
using BusBookingSystem.Services.Contracts.Repositories;

namespace BusBookingSystem.Repositories
{
    public class InMemoryInvoiceRepository : IInvoiceRepository
    {
        private List<Invoice> _invoices = new List<Invoice>();

        public Task<List<Invoice>> GetByUserIdAsync(Guid userId)
        {
            var invoices = _invoices.Where(x => x.UserId == userId);
            return Task.FromResult(invoices.ToList());
        }

        public Task<Invoice> AddAsync(Invoice invoice)
        {
            var exists = _invoices.Any(
                i => i.ScheduleId == invoice.ScheduleId
                    && i.SeatId == invoice.SeatId
            );

            if (exists)
            {
                throw new InvalidOperationException("Invoice with same schedule and seat already exists.");
            }

            _invoices.Add(invoice);
            return Task.FromResult(invoice);
        }

        public Task<Invoice?> GetByIdAsync(Guid id)
        {
            var invoice = _invoices.FirstOrDefault(i => i.Id == id);
            return Task.FromResult(invoice);
        }
    }
}