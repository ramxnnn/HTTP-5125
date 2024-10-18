// Different J1 Problem

using Microsoft.AspNetCore.Mvc;

namespace assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CupCakeController : ControllerBase
    {
        /// <summary>
        /// Calculates the number of leftover cupcakes after distributing them to 28 students.
        /// </summary>
        /// <param name="regularBoxes">The number of regular boxes, where each box holds 8 cupcakes.</param>
        /// <param name="smallBoxes">The number of small boxes, where each box holds 3 cupcakes.</param>
        /// <returns>The number of cupcakes left after distributing to 28 students.</returns>
        /// <example>
        /// GET /api/CupCake?regularBoxes=2&smallBoxes=5
        /// returns 3
        /// </example>
        [HttpGet]
        public IActionResult GetLeftoverCupcakes([FromQuery] int regularBoxes, [FromQuery] int smallBoxes)
        {
            // Constants for box sizes and number of students
            const int students = 28;
            const int cupcakesPerRegularBox = 8;
            const int cupcakesPerSmallBox = 3;

            // Calculate total cupcakes
            int totalCupcakes = (regularBoxes * cupcakesPerRegularBox) + (smallBoxes * cupcakesPerSmallBox);

            // Calculate leftover cupcakes after distributing to 28 students
            int leftoverCupcakes = totalCupcakes - students;

            // Ensure we don't have negative leftovers if the total cupcakes are less than the number of students
            if (leftoverCupcakes < 0)
            {
                leftoverCupcakes = 0;
            }

            return Ok(leftoverCupcakes);
        }
    }
}
