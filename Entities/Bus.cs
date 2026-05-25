namespace BusBookingSystem.Entities
{
    public class Bus
    {
        public Guid Id { get; private set; }

        public CoachNumber CoachNumber { get; private set; }

        public BusType Type { get; private set; }
        public SeatingCapacity Seats { get; private set; }

        public Bus(CoachNumber coachNumber, BusType type)
        {
            Id = Guid.NewGuid();
            CoachNumber = coachNumber;
            Type = type;
            Seats = new SeatingCapacity(GetSeatCount(type));
        }

        private static int GetSeatCount(BusType type)
        {
            return type switch
            {
                BusType.Economy => 36,
                BusType.Business => 27,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public override string ToString()
        {
            return $"{Id} | Coach Number = {CoachNumber.Value} | {Type.ToString()} |  Seats = {Seats.Value}";
        }
    }
}