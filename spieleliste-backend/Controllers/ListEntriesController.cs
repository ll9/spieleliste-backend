﻿using Microsoft.AspNetCore.Mvc;
using spieleliste_backend.Data;
using spieleliste_backend.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace spieleliste_backend.Controllers
{
    [Route("api/listentries")]
    [ApiController]
    public class ListEntriesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public ListEntriesController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListEntry>>> GetList()
        {
            var entries = await _uow.ListenEintraege.List();

            return Ok(entries);
        }

        [HttpPost]
        public async Task<IActionResult> AddToList([FromBody] ListEntry entry)
        {
            await _uow.ListenEintraege.Add(entry);

            try
            {
                await _uow.Complete();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

            return Ok(entry);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFromList(int id)
        {
            var entry = await _uow.ListenEintraege.Get(id);

            if (entry == null)
                return NotFound();

            await _uow.ListenEintraege.Remove(entry);
            await _uow.Complete();

            return NoContent();
        }
    }
}