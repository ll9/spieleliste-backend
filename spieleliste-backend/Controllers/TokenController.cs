using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using spieleliste_backend.Helper;
using spieleliste_backend.Services;
using System.Threading.Tasks;

namespace spieleliste_backend.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IIGDBTokenService _tokenService;
        private static Maybe<IgdbResponse> _cachedToken;

        public TokenController(IIGDBTokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet("refresh")]
        public async Task<ActionResult<string>> Refresh()
        {
            if (_cachedToken.HasValue && !_cachedToken.Value.IsExpired()) return Ok(_cachedToken.Value.AccessToken);

            var result = await _tokenService.GetNewAccessToken();

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            _cachedToken = result.Value;
            return Ok(result.Value.AccessToken);
        }
    }
}