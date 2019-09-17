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
    public class UserListEntriesController: ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public UserListEntriesController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpPost]
        public async Task<IActionResult> Create(int userId, ListEntry listEntry)
        {
            var user = await _uow.Users.Get(userId);

            if (user == null)
                return NotFound("User not found");

            var list = await _uow.ListenEintraege.Get(listEntry.Id);

            if (list == null)
                return NotFound("Listentry Not found");

            var userEntry = new UserEntry(userId, listEntry.Id);
            await _uow.UserEntries.Add(userEntry);
            await _uow.Complete();

            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int userId, int id)
        {
            var user = await _uow.Users.Get(userId);

            if (user == null)
                return NotFound("User not found");

            var userEntry = await _uow.UserEntries.Get(id);

            if (userEntry == null)
                return NotFound("Listentry Not found");

            await _uow.UserEntries.Remove(userEntry);
            await _uow.Complete();

            return Ok();
        }
    }
}
