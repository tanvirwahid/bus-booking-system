
namespace BusBookingSystem.Entities
{
    public class User
    {
        public Guid Id { get; private set; }

        public string FullName { get; private set; }

        public MobileNumber MobileNumber { get; private set; }

        public Email Email { get; private set; }

        public User(string fullName, MobileNumber mobileNumber, Email email)
        {
            Id = Guid.NewGuid();

            FullName = fullName;
            MobileNumber = mobileNumber;
            Email = email;
        }

        public override string ToString()
        {
            return $"{Id} | {FullName} | {MobileNumber.Value} | {Email.Value}";
        }
    }
}