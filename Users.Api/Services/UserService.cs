using System.Collections.Generic;
using System.Linq;
using Users.Api.Models;
using Users.Api.Repositories;

namespace Users.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly ITimeToNextBirthdayFormatter timeToNextBirthdayFormatter;

        public UserService(IUserRepository userRepository, ITimeToNextBirthdayFormatter timeToNextBirthdayFormatter)
        {
            this.userRepository = userRepository;
            this.timeToNextBirthdayFormatter = timeToNextBirthdayFormatter;
        }

        public List<UserDto> GetAll() =>
            this.userRepository
            .GetAll()
            .Select(u => new UserDto
            {
                Id = u.Id, Name = u.Name, TimeToNextBirthday = timeToNextBirthdayFormatter.Format(u.BirthDate)
            })
            .ToList();
    }
}
