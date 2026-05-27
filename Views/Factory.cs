using BusBookingSystem.Views.Bus;
using BusBookingSystem.Views.Contracts;
using BusBookingSystem.Views.Readers;
using BusBookingSystem.Views.Schedule;
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
            var dateTimeReader = new DateTimeReader();
            var guidReader = new GuidReader();

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
                case 5:
                    return new ScheduleCreateView(intReader, stringReader, dateTimeReader);
                case 6:
                    return new ScheduleList();
                case 7:
                    return new ScheduleDetails(guidReader);
                default:
                    throw new InvalidOperationException("Invalid instruction.");
            }
        }
    }
}