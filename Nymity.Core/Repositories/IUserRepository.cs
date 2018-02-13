using Nymity.Core.Entities;
using System.Collections.Generic;

namespace Nymity.Core.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> Get();
        User Get(int id);
        User Authenticate(string login, string password);
    }
}
