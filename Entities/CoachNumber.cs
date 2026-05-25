namespace BusBookingSystem.Entities
{
    public sealed class CoachNumber
    {
        public int Value { get; private set; }

        public CoachNumber(int value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Coach number must be greater than zero.");
            }

            Value = value;
        }

        public bool Equals(CoachNumber coachNumber) => Value == coachNumber.Value;

    }
}