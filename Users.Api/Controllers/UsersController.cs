using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Users.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> logger;

        public UsersController(ILogger<UsersController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        [Route("/")]
        public IEnumerable<string> Get() => Array.Empty<string>();
    }
}
