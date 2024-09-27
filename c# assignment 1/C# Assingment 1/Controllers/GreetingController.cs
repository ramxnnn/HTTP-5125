using Microsoft.AspNetCore.Mvc;

namespace MyApiProject.Controllers
{
    [ApiController]
    [Route("api/q2")]
    public class GreetingController : ControllerBase
    {
        /// <summary>
        /// Returns a greeting to the specified name.
        /// </summary>
        /// <param name="name">The name to greet.</param>
        /// <returns>A greeting message as a string.</returns>
        /// <example>GET api/q2/greeting?name=Gary</example>
        [HttpGet("greeting")]
        public ActionResult<string> GetGreeting([FromQuery] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Name cannot be empty.");
            }
            return $"Hi {name}!";
        }
    }
}
