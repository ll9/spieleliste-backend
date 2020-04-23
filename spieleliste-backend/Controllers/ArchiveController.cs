using Microsoft.AspNetCore.Mvc;
using spieleliste_backend.Data;
using spieleliste_backend.Dtos;
using spieleliste_backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace spieleliste_backend.Controllers
{
    [Route("api/archive")]
    [ApiController]
    public class ArchiveController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArchiveController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchiveEntry>>> List([FromHeader] ResourceParameters resourceParameters)
        {
            var entities = await _unitOfWork.ArchiveEntries.List(resourceParameters);

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