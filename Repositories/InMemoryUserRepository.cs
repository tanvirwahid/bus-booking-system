using BusBookingSystem.Entities;
using BusBookingSystem.Services.Contracts.Repositories;

namespace BusBookingSystem.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private List<User> _users = new List<User>();

        public Task<User?> GetByIdAsync(Guid id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);

            return Task.FromResult(user);
        }

        public Task<List<User>> GetAllAsync()
        {
            return Task.FromResult(_users.ToList());
        }

        public Task<User?> GetByEmailAsync(Email email)
        {
            var user = _users.FirstOrDefault(u => u.Email.Equals(email));

            return Task.FromResult(user);
        }

        public Task<User?> GetByMobileNumberAsync(MobileNumber mobileNumber)
        {
            var user = _users.FirstOrDefault(u => u.MobileNumber.Equals(mobileNumber));

            return Task.FromResult(user);
        }

        public Task<User> AddAsync(User user)
        {
            var exists = _users.Any(u =>
                u.Email == user.Email ||
                u.MobileNumber == user.MobileNumber
            );

            if (exists)
            {
                throw new InvalidOperationException("User with same email or mobile number already exists.");
            }

            _users.Add(user);
            return Task.FromResult(user);
        }
    }
}