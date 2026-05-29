namespace BusBookingSystem.Entities
{
    public class Schedule
    {
        public Guid Id { get; private set; }
        public Guid BusId { get; private set; }
        public Bus Bus { get; private set; }
        public string DepartureCity { get; private set; }
        public string ArrivalCity { get; private set; }
        public Price TicketPrice { get; private set; }
        public DateTime DepartureTime { get; private set; }
        private readonly List<Seat> _seats = new();
        public IReadOnlyCollection<Seat> Seats => _seats.AsReadOnly();

        public Schedule(Bus bus, string departureCity, string arrivalCity, Price ticketPrice, DateTime departureTime)
        {
            if (bus is null)
                throw new ArgumentNullException(nameof(bus));

            if (string.IsNullOrWhiteSpace(departureCity))
                throw new ArgumentException("Departure city is required.");

            if (string.IsNullOrWhiteSpace(arrivalCity))
                throw new ArgumentException("Arrival city is required.");

            if (departureCity.Equals(arrivalCity, StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("Cities cannot be same.");

            if (departureTime <= DateTime.UtcNow)
                throw new ArgumentException("Departure must be future.");

            Id = Guid.NewGuid();
            BusId = bus.Id;
            Bus = bus;
            DepartureCity = departureCity;
            ArrivalCity = arrivalCity;
            TicketPrice = ticketPrice;
            DepartureTime = departureTime;
            _seats.AddRange(SeatGenerator.Generate(bus.Type, bus.Seats.Value, Id));
        }

        public int AvailableSeats() => _seats.Count(x => x.Status == SeatStatus.Available);

        public List<Seat> BookedSeats(List<string> seatNumbers, Guid userId)
        {
            var seats = FindSeats(seatNumbers, SeatStatus.Available);

            if (seats.Count() != seatNumbers.Count())
            {
                throw new ArgumentException("Please select available seats.");
            }

            foreach (var seat in seats)
            {
                seat.Book(userId);
            }

            return seats;
        }

        public List<Seat> FindSeats(List<string> seatNumbers, SeatStatus status)
        {
            return _seats.Where(
                x => seatNumbers.Contains(x.SeatNumber)
                && x.Status == status
            ).ToList();
        }

        public override string ToString()
        {
            return "ID: " + Id +
            " | " + DepartureCity + " -> " + ArrivalCity +
            " | " +
            DepartureTime +
            " | "
            + TicketPrice.Value + " Taka | " +
            Bus.Type.ToString() +
            " | Coach Number: "
            + Bus.CoachNumber.Value;
        }
    }
}
