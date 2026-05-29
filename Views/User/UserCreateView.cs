using BusBookingSystem.Container;
using BusBookingSystem.Views.Contracts;
using BusBookingSystem.Views.Readers;
using System;

namespace BusBookingSystem.Views.User
{
    public class UserCreateView : View
    {
        private readonly StringInputReader _stringReader;

        public UserCreateView(StringInputReader stringReader)
        {
            _stringReader = stringReader;
        }


        public async Task Render()
        {
            Console.WriteLine("=== User Registration ===");
            Console.WriteLine("Please enter the following details:\n");

            var fullName = _stringReader.ReadRequired("Full Name: ");
            var mobile = _stringReader.ReadRequired("Mobile Number (BD format): ");
            var email = _stringReader.ReadRequired("Email: ");

            var userController = AppContainer.Instance.GetUserController();

            var user = await userController.CreateUserAsync(fullName, mobile, email);

            Console.WriteLine(user);
        }
    }
}