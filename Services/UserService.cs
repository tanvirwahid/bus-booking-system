using BusBookingSystem.Entities;
using BusBookingSystem.Services.Contracts;
using BusBookingSystem.Services.Contracts.Repositories;

namespace BusBookingSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> CreateAsync(string fullName, string mobileNumber, string email)
        {
            var mobile = new MobileNumber(mobileNumber);
            var emailAddress = new Email(email);

            var userWithEmail = await _userRepository.GetByEmailAsync(emailAddress);
            var userWithMobile = await _userRepository.GetByMobileNumberAsync(mobile);

            if (userWithEmail != null || userWithMobile != null)
            {
                throw new InvalidOperationException("User with same email or mobile number already exists.");
            }

            var user = new User(fullName, new MobileNumber(mobileNumber), new Email(email));

            return await _userRepository.AddAsync(user);
        }

    }
}