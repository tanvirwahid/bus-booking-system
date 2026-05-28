using BusBookingSystem.Views;
using BusBookingSystem.Views.Readers;

class Program
{
    static async Task Main(string[] args)
    {
        var intReader = new IntInputReader();
        var factory = new Factory();

        while (true)
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine("1: Create User");
                Console.WriteLine("2: Display Users");
                Console.WriteLine("3: Create Bus");
                Console.WriteLine("4: Display Buses");
                Console.WriteLine("5: Create Schedule");
                Console.WriteLine("6: Display Schedules");
                Console.WriteLine("7: View Schedule Details");
                Console.WriteLine("8: Book A Seat");
                Console.WriteLine("9: View User Invoices");
                Console.WriteLine("10: Pay And Confirm Seat");
                Console.WriteLine("11: View User Tickets");
                Console.WriteLine("0: Exit");

                var instruction = intReader.ReadRequired("Enter your instruction: ");

                if (instruction == 0)
                {
                    break;
                }

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