namespace BusBookingSystem.Entities
{
    public class Ticket
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid ScheduleId { get; private set; }
        public Schedule Schedule { get; private set; }
        public IReadOnlyCollection<Seat> Seats { get; private set; }

        public Ticket(Schedule schedule, IEnumerable<Seat> seats, User user)
        {
            if (schedule is null)
                throw new ArgumentNullException("Invalid Schedule");

            if (user is null)
                throw new ArgumentException("Invalid user");

            Id = Guid.NewGuid();
            UserId = user.Id;
            ScheduleId = schedule.Id;
            Schedule = schedule;
            Seats = seats.ToList();
        }

        public override string ToString()
        {
            var value = "Id: " + Id
            + " | Coach No: " + Schedule.Bus.CoachNumber.Value
            + " | Journey: " + Schedule.DepartureTime.ToString() + " | Seats: ";

            foreach (var seat in Seats)
            {
                value += " " + seat.SeatNumber;
            }

            return value;
        }

    }
}