using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using spieleliste_backend.Data;
using spieleliste_backend.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace spieleliste_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListenEintragController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ListenEintragController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListenEintrag>>> GetList()
        {
            return await _context.ListenEintraege.ToListAsync();
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> AddToList(int id)
        {
            if (_context.ListenEintraege.Any(e => e.SpielId == id))
            {
                return StatusCode((int)HttpStatusCode.Conflict, "Item already on list");
            }

            var entry = new ListenEintrag(id);
            _context.ListenEintraege.Add(entry);
            await _context.SaveChangesAsync();

            return Ok(entry);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFromList(int id)
        {
            var entry = await _context.ListenEintraege.FindAsync(id);

            if (entry == null)
            {
                return NotFound();
            }

            _context.ListenEintraege.Remove(entry);
            _context.SaveChanges();

            return NoContent();
        }
    }
}