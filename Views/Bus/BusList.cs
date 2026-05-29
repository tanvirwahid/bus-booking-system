using BusBookingSystem.Container;
using BusBookingSystem.Views.Contracts;

namespace BusBookingSystem.Views.Bus
{
    public class BusList : View
    {
        public async Task Render()
        {
            var busController = AppContainer.Instance.GetBusController();
            var buses = await busController.GetAllAsync();

            Console.WriteLine("Bus List:");

            foreach (var bus in buses)
            {
                Console.WriteLine(bus);
            }
        }
    }
}