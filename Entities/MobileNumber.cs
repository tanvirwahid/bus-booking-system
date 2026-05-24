using System.Text.RegularExpressions;

namespace BusBookingSystem.Entities
{
    sealed public class MobileNumber
    {
        public string Value { get; private set; }

        public MobileNumber(string mobileNumber)
        {
            Value = getMobileNumber(mobileNumber);
        }

        public bool Equals(MobileNumber mobileNumber) => Value == mobileNumber.Value;

        private string getMobileNumber(string mobileNumber)
        {
            mobileNumber = mobileNumber.Trim();

            var regex = new Regex(@"^(?:\+8801|8801|01)[3-9]\d{8}$");

            if (!regex.IsMatch(mobileNumber))
            {
                throw new ArgumentException("Invalid Bangladesh mobile number.");
            }

            return NormalizeMobileNumber(mobileNumber);
        }

        private string NormalizeMobileNumber(string mobileNumber)
        {
            if (mobileNumber.StartsWith("+880"))
            {
                return "0" + mobileNumber.Substring(4);
            }

            if (mobileNumber.StartsWith("880"))
            {
                return "0" + mobileNumber.Substring(3);
            }

            return mobileNumber;
        }
    }
}