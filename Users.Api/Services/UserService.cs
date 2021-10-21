using System.Collections.Generic;
using System.Linq;
using Users.Api.Models;
using Users.Api.Repositories;

namespace Users.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public List<UserDto> GetAll() =>
            this.userRepository
            .GetAll()
            .Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
            })
            .ToList();
    }
}
