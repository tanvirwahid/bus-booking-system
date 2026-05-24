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

        public async Task<User> CreateUser(string fullName, string mobileNumber, string email)
        {
            return await _userService.Create(fullName, mobileNumber, email);
        }

        public async Task<List<User>> GetAll()
        {
            return await _userService.getUsers();
        }

    }
}