using System;
using System.Collections.Generic;
using System.Linq;
using Users.Api.Models;

namespace Users.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> users = new();

        public User GetById(int id) => this.users.FirstOrDefault(u => u.Id == id);

        public List<User> Filter(Func<User, bool> predicate) => this.users.Where(predicate).ToList();

        public User Add(User user)
        {
            this.users.Add(user);
            return user;
        }

        public void Delete(int id) => this.users.RemoveAll(u => u.Id == id);

        public List<User> GetAll() => this.users;
    }
}
