namespace BusBookingSystem.Views.User.Readers
{
    public class StringInputReader
    {
        public string ReadRequired(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);

                var input = Console.ReadLine()?.Trim();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }

                Console.WriteLine("Input cannot be empty. Try again.\n");
            }
        }
    }
}