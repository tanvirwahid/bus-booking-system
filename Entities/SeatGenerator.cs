namespace BusBookingSystem.Entities
{
    public class SeatGenerator
    {
        public static List<Seat> Generate(BusType busType, int totalSeat, Guid scheduleId)
        {
            var lastSeatSuffixInRow = busType == BusType.Business ? 'C' : 'D';
            var currentSuffix = 'A';

            var number = 1;
            List<Seat> seats = new List<Seat>();

            for (var i = 0; i < totalSeat; i++)
            {
                seats.Add(new Seat(scheduleId, number.ToString() + currentSuffix));
                currentSuffix++;

                if (currentSuffix > lastSeatSuffixInRow)
                {
                    currentSuffix = 'A';
                    number++;
                }
            }

            return seats;
        }
    }
}