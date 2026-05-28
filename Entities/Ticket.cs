namespace BusBookingSystem.Entities
{
    public class Ticket
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid ScheduleId { get; private set; }
        public Guid SeatId { get; private set; }
        public Schedule Schedule { get; private set; }
        public Seat Seat { get; private set; }

        public Ticket(Schedule schedule, Seat seat, User user)
        {
            if (schedule is null)
                throw new ArgumentNullException("Invalid Schedule");

            if (seat is null)
                throw new ArgumentException("Invalid seat");

            if (user is null)
                throw new ArgumentException("Invalid user");

            Id = Guid.NewGuid();
            UserId = user.Id;
            ScheduleId = schedule.Id;
            Schedule = schedule;
            SeatId = seat.Id;
            Seat = seat;
        }

        public override string ToString()
        {
            return "Id: " + Id
            + " | Coach No: " + Schedule.Bus.CoachNumber
            + " | Journey: " + Schedule.DepartureTime.ToString()
            + " | Seat: " + Seat.SeatNumber;
        }

    }
}