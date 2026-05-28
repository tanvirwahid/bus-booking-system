using BusBookingSystem.Entities;
using BusBookingSystem.Services.Contracts;

namespace BusBookingSystem.Controllers
{
    public class InvoiceController
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public async Task<List<Invoice>> GetByUserIdAsync(Guid userId)
        {
            return await _invoiceService.GetInvoiceByUserAsync(userId);
        }
    }
}