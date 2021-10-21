using System;
using System.Collections.Generic;
using Users.Api.Models;

namespace Users.Api.Repositories
{
    public interface IUserRepository
    {
        User Add(User user);

        void Delete(int id);

        List<User> Filter(Func<User, bool> predicate);

        List<User> GetAll();

        User GetById(int id);
    }
}
