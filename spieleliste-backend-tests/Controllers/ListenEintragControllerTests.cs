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
    public class ListenEintragControllerTests
    {
        private ListEntriesController sut;
        private Mock<IListenEintragRepository> repo;

        [SetUp]
        public void Setup()
        {
            var uow = new Mock<IUnitOfWork>();
            repo = new Mock<IListenEintragRepository>();

            uow.Setup(uow => uow.ListenEintraege).Returns(repo.Object);
            sut = new ListEntriesController(uow.Object);
        }

        [Test]
        public async Task GetList_WhenCalled_ReturnsOkObjectResult()
        {
            var res = await sut.GetList();

            Assert.AreEqual(typeof(OkObjectResult), res.Result.GetType());
        }

        [Test]
        public async Task RemoveFromList_EntryDoesNotExist_ReturnsNotFound()
        {
            repo.Setup(r => r.Get(1)).Returns(Task.FromResult<ListEntry>(null));
            var res = await sut.RemoveFromList(1);

            Assert.AreEqual(typeof(NotFoundResult), res.GetType());
        }

        [Test]
        public async Task RemoveFromList_EntryExists_ReturnsNotFound()
        {
            repo.Setup(r => r.Get(1)).Returns(Task.FromResult(new ListEntry(1)));
            repo.Setup(r => r.Remove(new ListEntry(1))).Returns(Task.CompletedTask);


            var res = await sut.RemoveFromList(1);

            Assert.AreEqual(typeof(NoContentResult), res.GetType());
        }
    }
}
