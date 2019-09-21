using Microsoft.AspNetCore.Mvc;
using spieleliste_backend.Data;
using spieleliste_backend.Dtos;
using spieleliste_backend.Extensions;
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

        [HttpPut("{gameId}/index")]
        public async Task<IActionResult> Create(int userId, int gameId, [FromBody] int newIndex)
        {
            var userEntry = await _uow.UserEntries.Get(userId, gameId);

            if (userEntry == null)
                return NotFound("UserEntry not found");

            if (newIndex > userEntry.Index)
            {
                // Where entryIndex > oldIndex && entryIndex <= newIndex => index -= 1
                // index = newIndex
                var items = await _uow.UserEntries.List(e => e.Index > userEntry.Index && e.Index <= newIndex);
                items.ForEach(e => e.Index--);
                userEntry.Index = newIndex;

            }
            else if (newIndex < userEntry.Index)
            {
                // Where entryIndex < oldIndex && entryIndex >= newIndex => index += 1
                // index = newIndex
                var items = await _uow.UserEntries.List(e => e.Index < userEntry.Index && e.Index >= newIndex);
                items.ForEach(e => ++e.Index);
                userEntry.Index = newIndex;

            }

            await _uow.Complete();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int userId, [FromBody] UserEntryDto dto)
        {
            var user = await _uow.Users.Get(userId);

            if (user == null)
                return NotFound("User not found");

            var listEntry = await _uow.ListenEintraege.Get(dto.IgdbId);

            if (listEntry == null)
                return NotFound("Listentry Not found");

            var userEntry = new UserEntry(userId, dto.IgdbId, dto.Index);
            var items = await _uow.UserEntries.List(e => e.Index >= userEntry.Index);
            items.ForEach(e => ++e.Index);

            await _uow.UserEntries.Add(userEntry);
            await _uow.Complete();

            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int userId, int id)
        {
            var entry = await _uow.UserEntries.Get(userId, id);

            if (entry == null)
                return NotFound("UserEntry not found");

            var items = await _uow.UserEntries.List(e => e.Index > entry.Index);
            items.ForEach(e => --e.Index);

            await _uow.UserEntries.Remove(entry);
            await _uow.Complete();

            return NoContent();
        }
    }
}
