using BusBookingSystem.Container;
using BusBookingSystem.Views.Contracts;

namespace BusBookingSystem.Views.User
{
    public class UserList : View
    {
        public async Task Render()
        {
            var userController = AppContainer.Instance.GetUserController();

            var users = await userController.GetAllASync();

            Console.WriteLine("User List:");

            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }
    }
}