namespace BusBookingSystem.Entities
{
    public class Invoice
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid ScheduleId { get; private set; }
        public Guid? TicketId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Schedule Schedule { get; private set; }
        public User User { get; private set; }
        public Price Amount { get; private set; }
        public PaymentStatus PaymentStatus;
        private List<Seat> _seats;
        public IReadOnlyCollection<Seat> Seats => _seats.AsReadOnly();

        public Invoice(User user, Schedule schedule, List<Seat> seats)
        {
            if (user is null)
                throw new ArgumentNullException("Invalid User");

            if (schedule is null)
                throw new ArgumentNullException("Invalid Schedule");


            Id = Guid.NewGuid();
            UserId = user.Id;
            ScheduleId = schedule.Id;
            Schedule = schedule;
            User = user;
            PaymentStatus = PaymentStatus.Unpaid;
            _seats = seats;
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

            ConfirmSeatBooking(userId);
        }

        private void ConfirmSeatBooking(Guid userId)
        {
            foreach (var seat in _seats)
            {
                seat.ConfirmBooking(userId);
            }
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