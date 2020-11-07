using Microsoft.AspNetCore.Mvc;
using spieleliste_backend.Services;
using System.Threading.Tasks;

namespace spieleliste_backend.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IIGDBTokenService _tokenService;

        public TokenController(IIGDBTokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet("refresh")]
        public async Task<ActionResult<string>> Refresh()
        {
            var result = await _tokenService.GetNewAccessToken();

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }
    }
}