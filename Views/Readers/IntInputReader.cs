namespace BusBookingSystem.Views.Readers
{
    public class IntInputReader
    {
        public int ReadRequired(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);

                var input = Console.ReadLine();

                if (int.TryParse(input, out int value))
                {
                    return value;
                }

                Console.WriteLine("Invalid number. Please try again.\n");
            }
        }
    }
}