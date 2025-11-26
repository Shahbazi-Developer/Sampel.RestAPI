using Microsoft.AspNetCore.Mvc;
using Sampel.RestAPI.Endpoints.API.Authentication;

namespace Sampel.RestAPI.Endpoints.Authentication;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly JwtTokenGenerator _jwt;

    public AuthController(JwtTokenGenerator jwt)
    {
        _jwt = jwt;
    }

    [HttpGet("token")]
    public IActionResult GenerateToken()
    {
        // مقادیر ساختگی – توکن معتبر تولید می‌کند
        string token = _jwt.Generate("system-user", "system");

        return Ok(new
        {
            token,
            createdAt = DateTime.UtcNow
        });
    }
}
