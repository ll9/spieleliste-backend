using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using spieleliste_backend.Data;
using spieleliste_backend.Dtos;
using spieleliste_backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spieleliste_backend.Controllers
{
    [Route("api/archive")]
    [ApiController]
    public class ArchiveController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;

        public ArchiveController(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpGet("year/{year}")]
        public async Task<ActionResult<IEnumerable<ArchiveEntry>>> List(int year = 2019)
        {
            var entities = await _context.ArchiveEntries.Where(e => e.Archived.Year == year).ToListAsync();

            return Ok(entities);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchiveEntry>>> List([FromQuery] ResourceParameters resourceParameters)
        {
            var entities = await _unitOfWork.ArchiveEntries.List(resourceParameters);
            Response.Headers.Add("X-Total-Count", entities.TotalCount.ToString());

            return Ok(entities);
        }

        [HttpPost]
        public async Task<ActionResult<ArchiveEntry>> Create([FromBody] int igdbId)
        {
            var entity = new ArchiveEntry(igdbId);
            entity.SetArchiveDate();

            await _unitOfWork.ArchiveEntries.Create(entity);
            await _unitOfWork.Complete();

            return Ok(entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Delete(int id, ArchiveInDto dto)
        {
            var entity = await _unitOfWork.ArchiveEntries.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            entity.Archived = dto.Archived;
            await _unitOfWork.Complete();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _unitOfWork.ArchiveEntries.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            await _unitOfWork.ArchiveEntries.Delete(entity);
            await _unitOfWork.Complete();

            return NoContent();
        }
    }
}