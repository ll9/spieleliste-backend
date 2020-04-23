using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using spieleliste_backend.Controllers;
using spieleliste_backend.Data;
using spieleliste_backend.Models;
using spieleliste_backend.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace spielelistebackendtests.Controllers
{
    public class UsersControllerTests
    {
        private UsersController sut;
        private Mock<IUserRepository> repo;

        [SetUp]
        public void Setup()
        {
            repo = new Mock<IUserRepository>();
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(u => u.Users).Returns(repo.Object);
            sut = new UsersController(uow.Object);
        }

        [Test]
        public async Task List_WhenCalledReturnsOkObjectResult()
        {
            var res = await sut.List();

            Assert.AreEqual(typeof(OkObjectResult), res.Result.GetType());
        }

        [Test]
        public async Task Create_WhenCalled_ReturnsCreatedAtObjectResult()
        {
            var user = new User("name");
            var res = await sut.Create(user);

            Assert.AreEqual(typeof(CreatedAtActionResult), res.Result.GetType());
        }

        [Test]
        public async Task Create_MaxUserLimitReached_ReturnsConflictResult()
        {
            var users = Enumerable.Range(0, UsersController.MaxUsers).Select(i => new User("user" + i));
            repo.Setup(r => r.List()).Returns(Task.FromResult(users));

            var res = await sut.Create(new User("_"));

            Assert.AreEqual(typeof(ConflictObjectResult), res.Result.GetType());
        }

        [Test]
        public async Task Remove_UserFound_ReturnsNoContent()
        {
            var user = new User("_") { Id = 1 };

            repo.Setup(r => r.Get(user.Id)).Returns(Task.FromResult(user));

            var res = await sut.Remove(user.Id);
            Assert.AreEqual(typeof(NoContentResult), res.GetType());
        }

        [Test]
        public async Task Remove_UserNotFound_ReturnsNotFoundResult()
        {
            repo.Setup(r => r.Get(1)).Returns(Task.FromResult<User>(null));

            var res = await sut.Remove(1);
            Assert.AreEqual(typeof(NotFoundObjectResult), res.GetType());
        }
    }
}