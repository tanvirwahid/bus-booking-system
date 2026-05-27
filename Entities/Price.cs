namespace BusBookingSystem.Entities
{
    public sealed class Price
    {
        public int Value { get; private set; }

        public Price(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price must be greater than zero.");
            }

            Value = value;
        }

        public bool Equals(Price price) => Value == price.Value;

    }
}