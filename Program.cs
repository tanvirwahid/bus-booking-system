using BusBookingSystem.Views;
using BusBookingSystem.Views.Readers;

class Program
{
    static async Task Main(string[] args)
    {
        var intReader = new IntInputReader();

        while (true)
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine("1: Create User");
                Console.WriteLine("2: Display Users");
                Console.WriteLine("0: Exit");

                var instruction = intReader.ReadRequired("Enter your instruction: ");

                if (instruction == 0)
                {
                    break;
                }

                var factory = new Factory();
                Console.WriteLine("");
                var view = factory.GetView(instruction);

                await view.Render();
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine("");
                Console.WriteLine(ex.Message);
                Console.WriteLine("");
            }

        }
    }
}