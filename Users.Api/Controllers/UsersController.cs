using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Users.Api.Models;
using Users.Api.Services;

namespace Users.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Route("/")]
        public IEnumerable<UserDto> Get() => this.userService.GetAll();
    }
}
