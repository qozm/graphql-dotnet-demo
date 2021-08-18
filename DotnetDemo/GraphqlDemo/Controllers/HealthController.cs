using Microsoft.AspNetCore.Mvc;

namespace GraphqlDemo.Controllers
{
    [ApiController]
    [Route("/")]
    public class HealthController : Controller
    {
        [HttpGet("health")]
        public IActionResult Health()
        {
            return Ok();
        }
    }
}