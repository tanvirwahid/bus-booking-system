using BusBookingSystem.Container;
using BusBookingSystem.Views.Contracts;
using BusBookingSystem.Views.Readers;

namespace BusBookingSystem.Views.Invoice
{
    public class InvoiceList : View
    {
        private readonly GuidReader _guidReader;

        public InvoiceList(GuidReader guidReader)
        {
            _guidReader = guidReader;
        }

        public async Task Render()
        {
            var userId = _guidReader.ReadRequired("Enter user id: ");
            var invoiceController = AppContainer.Instance.GetInvoiceController();

            var invoiceList = await invoiceController.GetByUserIdAsync(userId);

            Console.WriteLine("Invoice list: ");

            foreach (var invoice in invoiceList)
            {
                Console.WriteLine(invoice);
            }
        }
    }
}