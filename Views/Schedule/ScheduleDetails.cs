using BusBookingSystem.Container;
using BusBookingSystem.Entities;
using BusBookingSystem.Views.Contracts;
using BusBookingSystem.Views.Readers;

namespace BusBookingSystem.Views.Schedule
{
    public class ScheduleDetails : View
    {
        private readonly GuidReader _guidReader;

        public ScheduleDetails(GuidReader guidReader)
        {
            _guidReader = guidReader;
        }

        public async Task Render()
        {
            Guid id = _guidReader.ReadRequired("Enter Schedule Id: ");
            var scheduleController = AppContainer.Instance.GetScheduleController();
            var schedule = await scheduleController.GetById(id);

            var sortedSeats = schedule.Seats
                .OrderBy(x => x.SeatNumber[0])
                .ThenBy(x => x.SeatNumber[1])
                .ToList();

            PrintSeats(sortedSeats, schedule.Bus.Type);
        }

        private void PrintSeats(List<Seat> seats, BusType busType)
        {
            var devidingSeatSuffix = busType == BusType.Business ? 'A' : 'B';
            var lastSeatInRowSuffix = busType == BusType.Business ? 'C' : 'D';

            Console.WriteLine("Seat Layout: [ ] = Available, X = Booked, W = Waiting For Confirmation");

            foreach (var seat in seats)
            {
                if (seat.SeatNumber[1] != 'A')
                {
                    Console.Write(" ");
                }

                Console.Write("[");
                Console.Write(GetStatusSymbol(seat.Status) + ":" + seat.SeatNumber + "]");

                if (seat.SeatNumber[1] == devidingSeatSuffix)
                {
                    Console.Write("  ");
                }

                if (seat.SeatNumber[1] == lastSeatInRowSuffix)
                {
                    Console.WriteLine();
                }
            }
        }

        private string GetStatusSymbol(SeatStatus status)
        {
            return status switch
            {
                SeatStatus.Available => " ",
                SeatStatus.Booked => "X",
                SeatStatus.Waiting => "W",
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
