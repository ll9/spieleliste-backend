using Microsoft.AspNetCore.Mvc;
using spieleliste_backend.Data;
using spieleliste_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spieleliste_backend.Controllers
{
    [Route("api/users/{userId}/listentries")]
    [ApiController]
    public class UserListEntriesController
    {
        private readonly IUnitOfWork _uow;

        public UserListEntriesController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpPost]
        public Task<IActionResult> Create(UserEntry userEntry)
        {
            throw new NotImplementedException();
        }


        [HttpDelete("{id}")]
        public Task<IActionResult> Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
