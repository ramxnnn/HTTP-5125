using Microsoft.AspNetCore.Mvc;

namespace MyApiProject.Controllers
{
    [ApiController]
    [Route("api/q4")]
    public class KnockKnockController : ControllerBase
    {
        /// <summary>
        /// Returns the start of a knock-knock joke.
        /// </summary>
        /// <returns>The start of the knock-knock joke as a string.</returns>
        /// <example>POST api/q4/knockknock</example>
        [HttpPost("knockknock")]
        public ActionResult<string> GetKnockKnockJoke()
        {
            return "Who's there?";
        }
    }
}
