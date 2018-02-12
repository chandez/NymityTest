using Dapper;
using Nymity.Core.Entities;
using Nymity.Core.Infrastructure;
using System.Collections.Generic;
using System.Data;

namespace Nymity.Core.Repositories
{
    public class UserRepository : IUserRepository
    {
        IConnectionFactory _connectionFactory;

        public UserRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IEnumerable<User> Get()
        {
            var query = @"SELECT [Id], [Name], [Email], [Password] FROM [dbo].[Users]";

            IEnumerable<User> users;

            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                users = SqlMapper.Query<User>(connection, query);
            }

            return users;
        }

        public User Get(int id)
        {
            var query = @"SELECT [Id], [Name], [Email], [Password] FROM [dbo].[Users] WHERE [Id] = @id";

            User user;

            using (IDbConnection connection = _connectionFactory.GetConnection)
            {
                user = SqlMapper.QueryFirstOrDefault<User>(connection, query, new { id });
            }

            return user;
        }
    }
}
