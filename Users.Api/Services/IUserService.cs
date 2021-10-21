using System.Collections.Generic;
using Users.Api.Models;

namespace Users.Api.Services
{
    public interface IUserService
    {
        List<UserDto> GetAll();
    }
}
