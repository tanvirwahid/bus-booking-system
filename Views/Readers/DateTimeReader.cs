namespace BusBookingSystem.Views.Readers
{
    public class DateTimeReader
    {
        public DateTime ReadRequired(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);

                var input = Console.ReadLine();

                if (DateTime.TryParse(input, out var value))
                {
                    return value;
                }

                Console.WriteLine("Invalid date time format. Try Again");
            }
        }
    }
}