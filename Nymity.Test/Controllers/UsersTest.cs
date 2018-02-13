using HttpRestApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Nymity.Core.Repositories;

namespace Nymity.Test.Controllers
{
    [TestFixture]
    public class UsersTest
    {
        private UsersController controller;

        [SetUp]
        public void SetUp()
        {
            Mock<IUserRepository> mockDependency = new Mock<IUserRepository>();
            mockDependency.Setup(x => x.Get(1)).Returns(Fake.User);
            mockDependency.Setup(x => x.Get()).Returns(Fake.Users);
            controller = new UsersController(mockDependency.Object);
            //usersController = new UsersController(new UserRepository(new ));
        }

        [Test]
        public void Should_return_status_code_ok_and_list_of_users()
        {
            var result = controller.Get();
            Assert.IsInstanceOf(typeof(OkObjectResult), result);
        }

        [Test]
        public void Should_return_status_code_not_found()
        {
            var result = controller.Get(9999);
            Assert.IsInstanceOf(typeof(NotFoundResult), result);
        }

        [Test]
        public void Should_return_status_code_ok_and_user_by_id()
        {
            var result = controller.Get(1);
            Assert.IsInstanceOf(typeof(OkObjectResult), result);
        }
    }
}
