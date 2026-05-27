namespace BusBookingSystem.Entities
{
    public class Seat
    {
        public Guid Id { get; private set; }
        public Guid ScheduleId { get; private set; }
        public Guid? BookedBy { get; private set; }
        private SeatStatus _status = SeatStatus.Available;
        public string SeatNumber { get; private set; }
        private DateTime? _waitingTill;
        public DateTime? BookedAt { get; private set; }

        public SeatStatus Status
        {
            private set => _status = value;
            get
            {
                ExpireWaitingIfNeeded();
                return _status;
            }
        }

        public Seat(Guid scheduleId, string seatNumber)
        {
            Id = Guid.NewGuid();
            ScheduleId = scheduleId;
            SeatNumber = seatNumber;
        }

        public void Book(Guid userId)
        {
            if (Status == SeatStatus.Booked)
            {
                throw new ArgumentException("Seat is already booked.");
            }

            if (Status == SeatStatus.Waiting && userId == BookedBy)
            {
                throw new ArgumentException("Pleas confirm booking by making payment.");
            }

            if (Status == SeatStatus.Waiting)
            {
                throw new ArgumentException("This seat cannot be booked right now. Choose another seat or come back later.");
            }

            MarAsWaiting(userId);
        }

        public void ConfirmBooking(Guid userId)
        {
            if (Status != SeatStatus.Waiting || userId != BookedBy)
            {
                throw new ArgumentException("This seat cannot be confirmed.");
            }

            MarkedAsBooked();
        }

        public void CancelBooking(Guid userId)
        {
            if (Status != SeatStatus.Booked || userId != BookedBy)
            {
                throw new ArgumentException("This seat cannot be cancelled.");
            }

            MarkAsAvailable();
        }

        private void ExpireWaitingIfNeeded()
        {
            if (_status == SeatStatus.Waiting &&
                _waitingTill.HasValue &&
                DateTime.UtcNow > _waitingTill.Value)
            {
                _status = SeatStatus.Available;
                _waitingTill = null;
                BookedBy = null;
            }
        }

        private void MarkAsAvailable()
        {
            Status = SeatStatus.Available;
            BookedBy = null;
        }

        private void MarAsWaiting(Guid userId)
        {
            Status = SeatStatus.Waiting;
            _waitingTill = DateTime.UtcNow.AddMinutes(5);
            BookedBy = userId;
        }

        private void MarkedAsBooked()
        {
            Status = SeatStatus.Booked;
            BookedAt = DateTime.UtcNow;
            _waitingTill = null;
        }
    }
}