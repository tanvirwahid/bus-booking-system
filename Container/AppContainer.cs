using BusBookingSystem.Controllers;
using BusBookingSystem.Repositories;
using BusBookingSystem.Services;
using BusBookingSystem.Services.Contracts;
using BusBookingSystem.Services.Contracts.Repositories;

namespace BusBookingSystem.Container
{
    public class AppContainer
    {
        private static readonly Lazy<AppContainer> _instance = new(() => new AppContainer());

        public static AppContainer Instance => _instance.Value;

        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly UserController _userController;
        private readonly IBusRepository _busRepository;
        private readonly IBusService _busService;
        private readonly BusController _busController;


        private AppContainer()
        {
            _userRepository = new InMemoryUserRepository();
            _userService = new UserService(_userRepository);
            _userController = new UserController(_userService);
            _busRepository = new InMemoryBusRepository();
            _busService = new BusService(_busRepository);
            _busController = new BusController(_busService);
        }

        public BusController GetBusController()
        {
            return _busController;
        }

        public UserController GetUserController()
        {
            return _userController;
        }
    }
}