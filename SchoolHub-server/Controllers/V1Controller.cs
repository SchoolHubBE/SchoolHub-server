using Microsoft.AspNetCore.Mvc;

namespace SchoolHub_server.Controllers;

[ApiController]
[Route("v1")]
public class V1Controller : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var version = Environment.GetEnvironmentVariable("SCHOOLHUB_VERSION");
        if (version == null)
        {
            return BadRequest(new { status = "ERROR", message = "SCHOOLHUB_VERSION environment variable not set" });
        }

        return Ok(new { status = "OK", version });
    }
}