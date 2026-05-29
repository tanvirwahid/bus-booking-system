using BusBookingSystem.Container;
using BusBookingSystem.Views.Contracts;
using BusBookingSystem.Views.Readers;

namespace BusBookingSystem.Views.Schedule
{


    public class ScheduleCreateView : View
    {
        private readonly IntInputReader _intReader;
        private readonly StringInputReader _stringReader;
        private readonly DateTimeReader _dateTimeReader;

        public ScheduleCreateView(
            IntInputReader intReader,
            StringInputReader stringReader,
            DateTimeReader dateTimeReader
        )
        {
            _intReader = intReader;
            _stringReader = stringReader;
            _dateTimeReader = dateTimeReader;
        }

        public async Task Render()
        {
            Console.WriteLine("Create Schedule");

            int coachNumber = _intReader.ReadRequired("Coach Number: ");
            string departureCity = _stringReader.ReadRequired("Departure City: ");
            string arrivalCity = _stringReader.ReadRequired("Arrival City: ");
            int ticketPrice = _intReader.ReadRequired("Ticket Price: ");
            DateTime departureTime = _dateTimeReader.ReadRequired("Departure Time: ");

            var scheduleController = AppContainer.Instance.GetScheduleController();

            var schedule = await scheduleController.CreateAsync(
                coachNumber,
                departureCity,
                arrivalCity,
                ticketPrice,
                departureTime
            );

            Console.WriteLine("Successfully Created Schedule");
            Console.WriteLine(schedule);
        }

    }
}