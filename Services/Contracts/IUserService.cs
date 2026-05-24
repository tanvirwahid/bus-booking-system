using BusBookingSystem.Entities;

namespace BusBookingSystem.Services.Contracts
{
    public interface IUserService
    {
        Task<User> Create(string fullName, string mobileNumber, string email);
        Task<List<User>> getUsers();
    }
}