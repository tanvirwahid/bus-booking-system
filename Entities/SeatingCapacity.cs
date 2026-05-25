namespace BusBookingSystem.Entities
{
    public sealed class SeatingCapacity
    {
        public int Value { get; private set; }

        public SeatingCapacity(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Seating capacity must be greater than zero.");
            }

            Value = value;
        }
    }
}