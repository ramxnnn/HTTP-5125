using Microsoft.AspNetCore.Mvc;

namespace MyApiProject.Controllers
{
    [ApiController]
    [Route("api/q7")]
    public class TimeMachineController : ControllerBase
    {
        /// <summary>
        /// Returns a string representation of the current date adjusted by the specified number of days.
        /// </summary>
        /// <param name="days">The number of days to adjust the current date.</param>
        /// <returns>A string representation of the adjusted date formatted as yyyy-MM-dd.</returns>
        /// <example>GET api/q7/timemachine?days=1</example>
        [HttpGet("timemachine")]
        public ActionResult<string> GetAdjustedDate(int days)
        {
            // Get today's date
            var adjustedDate = DateTime.Today.AddDays(days);
            // Return the date formatted as yyyy-MM-dd
            return Ok(adjustedDate.ToString("yyyy-MM-dd"));
        }
    }
}
