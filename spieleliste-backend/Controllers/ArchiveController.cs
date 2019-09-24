using Microsoft.AspNetCore.Mvc;
using spieleliste_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spieleliste_backend.Controllers
{
    [Route("api/archive")]
    [ApiController]
    public class ArchiveController: ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchiveEntry>>> List()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
