using BusBookingSystem.Views.Bus;
using BusBookingSystem.Views.Contracts;
using BusBookingSystem.Views.Readers;
using BusBookingSystem.Views.User;
using BusBookingSystem.Views.User.Readers;

namespace BusBookingSystem.Views
{
    public class Factory
    {
        public View GetView(int instruction)
        {
            var stringReader = new StringInputReader();
            var intReader = new IntInputReader();

            switch (instruction)
            {
                case 1:
                    return new UserCreateView(stringReader);
                case 2:
                    return new UserList();
                case 3:
                    return new CreateBus(intReader);
                case 4:
                    return new BusList();
                default:
                    throw new InvalidOperationException("Invalid instruction.");
            }
        }
    }
}