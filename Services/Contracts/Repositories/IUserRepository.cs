using BusBookingSystem.Entities;

namespace BusBookingSystem.Services.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id);
        Task<List<User>> GetAllAsync();
        Task<User?> GetByEmail(Email email);
        Task<User?> GetByMobileNumber(MobileNumber mobileNumber);
        Task<User> AddAsync(User user);
    }
}