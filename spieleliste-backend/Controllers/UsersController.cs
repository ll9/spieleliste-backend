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
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public const byte MaxUsers = 4;
        private readonly IUnitOfWork _unitOfWork;
        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create(User user)
        {
            return null;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> List()
        {
            return null;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            return null;
        }
    }
}
