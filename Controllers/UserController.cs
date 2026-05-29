using BusBookingSystem.Entities;
using BusBookingSystem.Services.Contracts;

namespace BusBookingSystem.Controllers
{
    public class UserController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<User> CreateUserAsync(string fullName, string mobileNumber, string email)
        {
            return await _userService.CreateAsync(fullName, mobileNumber, email);
        }

        public async Task<List<User>> GetAllASync()
        {
            return await _userService.GetUsersAsync();
        }

    }
}