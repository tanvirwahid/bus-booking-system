using BusBookingSystem.Views.Contracts;
using BusBookingSystem.Views.User;
using BusBookingSystem.Views.User.Readers;

namespace BusBookingSystem.Views
{
    public class Factory
    {
        public View GetView(int instruction)
        {
            var stringReader = new StringInputReader();

            switch (instruction)
            {
                case 1:
                    return new UserCreateView(stringReader);
                case 2:
                    return new UserList();
                default:
                    throw new InvalidOperationException("Invalid instruction.");
            }
        }
    }
}