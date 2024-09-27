using Microsoft.AspNetCore.Mvc;

namespace MyApiProject.Controllers
{
    [ApiController]
    [Route("api/q6")]
    public class HexagonController : ControllerBase
    {
        /// <summary>
        /// Calculates the area of a regular hexagon with a given side length.
        /// </summary>
        /// <param name="side">The length of one side of the hexagon.</param>
        /// <returns>The area of the hexagon as a double.</returns>
        /// <example>GET api/q6/hexagon?side=1</example>
        [HttpGet("hexagon")]
        public ActionResult<double> GetHexagonArea(double side)
        {
            // Area formula: (3 * sqrt(3) / 2) * side^2
            if (side <= 0)
            {
                return BadRequest("Side length must be greater than 0.");
            }

            double area = (3 * Math.Sqrt(3) / 2) * Math.Pow(side, 2);
            return area;
        }
    }
}
