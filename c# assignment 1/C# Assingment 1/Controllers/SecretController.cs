using Microsoft.AspNetCore.Mvc;

namespace MyApiProject.Controllers
{
    [ApiController]
    [Route("api/q5")]
    public class SecretController : ControllerBase
    {
        /// <summary>
        /// Returns an acknowledgement of the secret integer provided in the request body.
        /// </summary>
        /// <param name="secret">The secret integer provided by the user.</param>
        /// <returns>A message acknowledging the secret integer.</returns>
        /// <example>POST api/q5/secret with body: { "secret": 5 }</example>
        [HttpPost("secret")]
        public ActionResult<string> AcknowledgeSecret([FromBody] SecretRequest request)
        {
            return $"Shh.. the secret is {request.Secret}";
        }
    }

    public class SecretRequest
    {
        public int Secret { get; set; }
    }
}
