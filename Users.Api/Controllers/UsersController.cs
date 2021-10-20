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
        public static readonly string Something = "Value";

        public UsersController(ILogger<UsersController> logger) => this.logger = logger;

        [HttpGet]
        [Route("/")]
        public IEnumerable<string> Get()
        {
            var users = new List<string>();
            var test = "string";
            if (1 == 1)
            {
                users.Add(Something);
            }
            else
            {
            }

            var variable2 = "test";
            users.Add(variable2);
            users.Add(test);
            users.Add(Something);
            users.Add(string.Concat(variable2, test));
            Console.WriteLine("asdadasdasdasdasdasasdadasdasdasdasdasasdadasdasdasdasdasasdadasdasdasdasdasasdadasdasdasdasdasasdadasdasdasdasdasasdadasdasdasdasdasasdadasdasdasdasdasasdadasdasdasdasdasasdadasdasdasdasdasasdadasdasdasdasdasasdadasdasdasdasdasasdadasdasdasdasdasasdadasdasdasdasdas");
            this.logger.LogTrace("UsersController::Get was called");

            return users;
        }
    }
}
