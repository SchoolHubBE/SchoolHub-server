using Microsoft.AspNetCore.Mvc;

namespace SchoolHub_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class v1Controller : ControllerBase
    {
        private readonly ILogger<v1Controller> _logger;

        public v1Controller(ILogger<v1Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetV1")]
        public v1 Get()
        {
            var result = new List<v1>();
            result.Add(new v1());
            return result.FirstOrDefault();
        }
    }
}
