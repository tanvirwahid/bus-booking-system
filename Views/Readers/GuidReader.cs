namespace BusBookingSystem.Views.Readers
{
    public class GuidReader
    {
        public Guid ReadRequired(string prompt)
        {
            Console.Write(prompt);

            while (true)
            {
                var input = Console.ReadLine();

                if (Guid.TryParse(input, out var value))
                {
                    return value;
                }

                Console.WriteLine("Invalid Guid. Please try again.");
            }
        }
    }
}