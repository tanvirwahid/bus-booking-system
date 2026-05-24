using System.Net.Mail;

namespace BusBookingSystem.Entities
{
    sealed public class Email
    {
        public string Value { get; private set; }

        public bool Equals(Email email) => Value == email.Value;

        public Email(string email)
        {
            ValidateEmail(email);
            Value = email;
        }

        private void ValidateEmail(string email)
        {
            email = email.Trim().ToLowerInvariant();

            if (!IsValidEmail(email))
            {
                throw new ArgumentException("Invalid email address.");
            }

        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);

                return mailAddress.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}