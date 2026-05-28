using BusBookingSystem.Container;
using BusBookingSystem.Views.Contracts;
using BusBookingSystem.Views.Readers;

namespace BusBookingSystem.Views.Bus
{
    public class CreateBus : View
    {
        private readonly IntInputReader _intReader;

        public CreateBus(IntInputReader intReader)
        {
            _intReader = intReader;
        }

        public async Task Render()
        {
            var coachNumber = _intReader.ReadRequired("Enter coach number: ");
            var type = GetType();

            var busController = AppContainer.Instance.GetBusController();
            var bus = await busController.Create(coachNumber, type);

            Console.WriteLine("Bus created successfully:");
            Console.WriteLine(bus);
        }

        private int GetType()
        {
            while (true)
            {
                var type = _intReader.ReadRequired("Enter bus type (0 for business with 27 seats, 1 for economy with 36 seats): ");

                if (type == 0 || type == 1)
                {
                    return type;
                }

                Console.WriteLine("Invalid bus type. Try again.\n");
            }
        }
    }
}
