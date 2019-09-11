using Microsoft.AspNetCore.Mvc;
using spieleliste_backend.Data;
using spieleliste_backend.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Threading.Tasks;

namespace spieleliste_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListenEintraegeController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public ListenEintraegeController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpPost]
        public async Task<IActionResult> AddToList([FromBody] ListenEintrag entry)
        {
            await _uow.ListenEintraege.Add(entry);

            try
            {
                await _uow.Complete();
            }
            catch (SqlException exception)
            {
                if (exception.Number == 2601 || exception.Number == 2627)
                {
                    return StatusCode((int)HttpStatusCode.Conflict, "Item already on list");
                }
                else
                {
                    return BadRequest(exception.Message);
                }
            }

            return Ok(entry);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListenEintrag>>> GetList()
        {
            var entries = await _uow.ListenEintraege.List();

            return Ok(entries);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFromList(int id)
        {
            var entry = await _uow.ListenEintraege.Get(id);

            if (entry == null)
            {
                return NotFound();
            }

            await _uow.ListenEintraege.Remove(entry);
            await _uow.Complete();

            return NoContent();
        }
    }
}