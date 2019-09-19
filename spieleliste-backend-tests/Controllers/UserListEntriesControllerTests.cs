using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using spieleliste_backend.Controllers;
using spieleliste_backend.Data;
using spieleliste_backend.Models;
using spieleliste_backend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spielelistebackendtests.Controllers
{
    public class UserListEntriesControllerTests
    {
        private UserListEntriesController sut;
        private Mock<IUserRepository> userRepo;
        private Mock<IUserEntryRepository> userEntryRepo;
        private Mock<IListenEintragRepository> listEntryRepository;

        [SetUp]
        public void Setup()
        {
            userRepo = new Mock<IUserRepository>();
            userEntryRepo = new Mock<IUserEntryRepository>();
            listEntryRepository = new Mock<IListenEintragRepository>();
            var uow = new Mock<IUnitOfWork>();

            uow.Setup(u => u.Users).Returns(userRepo.Object);
            uow.Setup(u => u.ListenEintraege).Returns(listEntryRepository.Object);
            uow.Setup(u => u.UserEntries).Returns(userEntryRepo.Object);
            sut = new UserListEntriesController(uow.Object);
        }

        [Test]
        public async Task Create_ValidState_ReturnsCreatedAtAction()
        {
            User user = new User("_") { Id = 1 };
            ListEntry listEntry = new ListEntry(100);
            userRepo.Setup(u => u.Get(user.Id)).Returns(Task.FromResult(user));
            listEntryRepository.Setup(u => u.Get(listEntry.IgdbId)).Returns(Task.FromResult(listEntry));

            var res = await sut.Create(user.Id, listEntry);

            Assert.AreEqual(typeof(OkResult), res.GetType());
        }

        [Test]
        public async Task Create_UserNotFound_NotFoundResult()
        {
            ListEntry listEntry = new ListEntry(100);
            userRepo.Setup(u => u.Get(1)).Returns(Task.FromResult<User>(null));
            listEntryRepository.Setup(u => u.Get(listEntry.IgdbId)).Returns(Task.FromResult(listEntry));

            var res = await sut.Create(1, listEntry);

            Assert.AreEqual(typeof(NotFoundObjectResult), res.GetType());
        }

        [Test]
        public async Task Create_ListEntryNotFound_NotFoundResult()
        {
            User user = new User("_") { Id = 1 };
            ListEntry listEntry = new ListEntry(100);
            userRepo.Setup(u => u.Get(user.Id)).Returns(Task.FromResult(user));
            listEntryRepository.Setup(u => u.Get(100)).Returns(Task.FromResult<ListEntry>(null));

            var res = await sut.Create(1, listEntry);

            Assert.AreEqual(typeof(NotFoundObjectResult), res.GetType());
        }

        [Test]
        public async Task Delete_WhenCalled_ReturnsResult()
        {
            userRepo.Setup(u => u.Get(It.IsAny<int>())).Returns(Task.FromResult(new User("_")));
            listEntryRepository.Setup(e => e.Get(It.IsAny<int>())).Returns(Task.FromResult(new ListEntry(It.IsAny<int>())));
            userEntryRepo.Setup(u => u.Get(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult(new UserEntry(It.IsAny<int>(), It.IsAny<int>())));

            var res = await sut.Remove(It.IsAny<int>(), It.IsAny<int>());

            Assert.AreEqual(typeof(NoContentResult), res.GetType());
        }

        [Test]
        public async Task Delete_NotFound_NotFoundResult()
        {
            userEntryRepo.Setup(u => u.Get(It.IsAny<int>(), It.IsAny<int>())).Returns(Task.FromResult<UserEntry>(null));

            var res = await sut.Remove(It.IsAny<int>(), It.IsAny<int>());

            Assert.AreEqual(typeof(NotFoundObjectResult), res.GetType());
        }
    }
}
