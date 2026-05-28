namespace BusBookingSystem.Entities
{
    public class Invoice
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid ScheduleId { get; private set; }
        public Guid? TicketId { get; private set; }
        public Guid SeatId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Schedule Schedule { get; private set; }
        public User User { get; private set; }
        public Seat Seat { get; private set; }
        public Price Amount { get; private set; }
        public PaymentStatus PaymentStatus;

        public Invoice(User user, Schedule schedule, Seat seat)
        {
            if (user is null)
                throw new ArgumentNullException("Invalid User");

            if (Schedule is null)
                throw new ArgumentNullException("Invalid Schedule");

            if (seat is null)
                throw new ArgumentNullException("Invalid Seat");

            Id = Guid.NewGuid();
            UserId = user.Id;
            ScheduleId = schedule.Id;
            Schedule = schedule;
            User = user;
            PaymentStatus = PaymentStatus.Unpaid;
            SeatId = seat.Id;
            Seat = seat;
            Amount = schedule.TicketPrice;
            CreatedAt = DateTime.UtcNow;
        }

        public void Pay(Guid ticketId, Guid userId)
        {
            if (PaymentStatus == PaymentStatus.Paid)
                throw new InvalidOperationException("This invoice is already paid.");

            if (userId != UserId)
                throw new InvalidOperationException("Invalid user");

            PaymentStatus = PaymentStatus.Paid;
            TicketId = ticketId;
        }

        public override string ToString()
        {
            var invoice = "Id: " + Id;
            var isPaid = PaymentStatus == PaymentStatus.Paid ? true : false;

            if (isPaid)
            {
                invoice += " | Ticket Id: " + TicketId;
            }

            invoice += " | Schedule Id: " + ScheduleId;
            invoice += " | Amount: " + Amount.Value + " Taka";
            invoice += " | Date: " + CreatedAt.ToString();
            invoice += " | Paid: " + (isPaid == true ? "Yes" : "No");

            return invoice;
        }
    }
}