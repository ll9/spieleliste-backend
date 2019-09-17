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
            if ((await _unitOfWork.Users.List()).Count() >= MaxUsers)
            {
                return Conflict($"Maximum amount of {MaxUsers} Users Reached");
            }


            await _unitOfWork.Users.Add(user);

            try
            {
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                // TODO: Handle duplicate name exception properly
                return BadRequest(e);
            }

            return CreatedAtAction(nameof(Get), new { Id = user.Id }, user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> List()
        {
            var users = await _unitOfWork.Users.List();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public Task<ActionResult<User>> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            var user = await _unitOfWork.Users.Get(id);

            if (user == null)
            {
                return NotFound($"User with id '{id}' not found");
            }

            await _unitOfWork.Users.Remove(user);
            await _unitOfWork.Complete();

            return NoContent();
        }
    }
}
