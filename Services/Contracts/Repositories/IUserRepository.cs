using BusBookingSystem.Entities;

namespace BusBookingSystem.Services.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id);
        Task<List<User>> GetAllAsync();
        Task<User?> GetByEmailAsync(Email email);
        Task<User?> GetByMobileNumberAsync(MobileNumber mobileNumber);
        Task<User> AddAsync(User user);
    }
}