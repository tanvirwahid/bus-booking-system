using System.Globalization;

namespace BusBookingSystem.Views.Readers
{
    public class DateTimeReader
    {
        public DateTime ReadRequired(string prompt)
        {
            while (true)
            {
                string format = "yyyy-MM-dd HH:mm";
                Console.Write($"{prompt} ({format}): ");

                var input = Console.ReadLine();

                if (
                    DateTime.TryParseExact(
                       input,
                       format,
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None,
                       out var value)
                    )
                {
                    return value;
                }

                Console.WriteLine("Invalid date time format. Try Again");
            }
        }
    }
}