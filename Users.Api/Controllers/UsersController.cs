using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Users.Api.Models;
using Users.Api.Services;

namespace Users.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> logger;
        private readonly IUserService userService;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            this.userService = userService;
            this.logger = logger;
        }

        [HttpGet]
        [Route("/")]
        public IEnumerable<UserDto> Get()
        {
            DateTime now = DateTime.Now;

            this.logger.LogInformation("Handling get request at {Time}", now);

            return this.userService.GetAll();
        }
    }
}
