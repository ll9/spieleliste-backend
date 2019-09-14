using Microsoft.AspNetCore.Mvc;
using spieleliste_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spieleliste_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> List()
        {
            return null;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create()
        {
            return null;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove()
        {
            return null;
        }
    }
}
