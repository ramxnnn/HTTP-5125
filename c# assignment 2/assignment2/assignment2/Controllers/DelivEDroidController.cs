using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DelivEDroidController : ControllerBase
    {
        /// <summary>
        /// Calculates the final score based on collisions and deliveries.
        /// </summary>
        /// <param name="collisions">The number of collisions with obstacles.</param>
        /// <param name="deliveries">The number of packages delivered.</param>
        /// <returns>The final score based on the delivery rules.</returns>
        /// <example>
        /// POST /api/DelivEDroid
        /// Collisions=2&Deliveries=5
        /// returns 730
        /// </example>
        [HttpPost]
        public IActionResult CalculateScore([FromForm] int collisions, [FromForm] int deliveries)
        {
            // Validate inputs
            if (collisions < 0 || deliveries < 0)
            {
                return BadRequest("Collisions and Deliveries must be non-negative.");
            }

            // Calculate the score
            int score = (deliveries * 50) - (collisions * 10);

            // Apply bonus if deliveries exceed collisions
            if (deliveries > collisions)
            {
                score += 500;
            }

            return Ok(score);
        }
    }
}
