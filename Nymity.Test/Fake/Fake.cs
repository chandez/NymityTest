using Nymity.Core.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Nymity.Test
{
    public static class Fake
    {
        public static User User() => new User { Id = 1, Name = "Chan Valle", Email = "Chan@mail.com", Password = "123456" };

        public static IEnumerable<User> Users() => new Collection<User> {
            new User { Id = 1, Name = "User 1", Email = "user1@mail.com", Password = "123456" },
            new User { Id = 1, Name = "User 2", Email = "user2@mail.com", Password = "789456" },
            new User { Id = 1, Name = "User 3", Email = "user3@mail.com", Password = "456123" },
            new User { Id = 1, Name = "User 4", Email = "user4@mail.com", Password = "987456" }
        };

        public static string Connection() => "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Projects\\Nymity\\Database\\Northwind.mdf;Integrated Security=True;Connect Timeout=30";
    }
}
