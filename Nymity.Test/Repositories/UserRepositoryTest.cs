using NUnit.Framework;
using Nymity.Core.Infrastructure;
using Nymity.Core.Repositories;
using System.Data.SqlClient;

namespace Nymity.Test.Repositories
{
    [TestFixture]
    public class UserRepositoryTest
    {
        private UserRepository repository;

        [SetUp]
        public void SetUp()
        {
            var factory = new ConnectionFactory(new SqlConnection(Fake.Connection()));
            repository = new UserRepository(factory);
        }

        [Test]
        public void Should_authenticated_user_by_email_and_password()
        {
            var user = repository.Authenticate("chan@mail.com", "123456");
            Assert.AreEqual(1, user.Id);
            Assert.AreEqual("Chan Valle", user.Name);
            Assert.AreEqual("chan@mail.com", user.Email);
            Assert.AreEqual("123456", user.Password);
        }

        [Test]
        public void Should_return_user_by_id()
        {
            var user = repository.Get(1);
            Assert.AreEqual(1, user.Id);
            Assert.AreEqual("Chan Valle", user.Name);
            Assert.AreEqual("chan@mail.com", user.Email);
            Assert.AreEqual("123456", user.Password);
        }

        [Test]
        public void Should_return_null()
        {
            var user = repository.Get(99999);
            Assert.IsNull(user);
        }
    }
}
