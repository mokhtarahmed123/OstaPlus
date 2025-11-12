using Microsoft.AspNetCore.Mvc;

namespace OSTA.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Welcome to the OSTA API!");
        }
    }
}
