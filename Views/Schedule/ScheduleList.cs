using BusBookingSystem.Container;
using BusBookingSystem.Views.Contracts;

namespace BusBookingSystem.Views.Schedule
{
    public class ScheduleList : View
    {
        public async Task Render()
        {
            var scheduleController = AppContainer.Instance.GetScheduleController();
            var schedules = await scheduleController.GetAll();

            Console.WriteLine("");
            Console.WriteLine("Schedules:");

            foreach (var schedule in schedules)
            {
                Console.WriteLine(schedule);
            }
        }
    }
}