using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using spieleliste_backend.Controllers;
using spieleliste_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spielelistebackendtests.Controllers
{
    public class UsersControllerTests
    {
        private UsersController sut;

        [SetUp]
        public void Setup()
        {
            sut = new UsersController();
        }

        public async Task List_WhenCalledReturnsOkObjectResult()
        {
            var res = await sut.List();

            Assert.AreEqual(typeof(OkObjectResult), res.Result.GetType());
        }

        public async Task Create()
        {
            var user = new User { Name = "name" };
            var res = await sut.Create(user);

            Assert.AreEqual(typeof(CreatedAtActionResult), res.Result.GetType());
        }

        public async Task Remove()
        {
            //return null;
        }
    }
}
