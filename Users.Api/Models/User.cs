using System;

namespace Users.Api.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateOnly BirthDate { get; set; }
    }
}
