using Microsoft.AspNetCore.Mvc;

namespace MyApiProject.Controllers
{
    [ApiController]
    [Route("api/q3")]
    public class CubeController : ControllerBase
    {
        /// <summary>
        /// Returns the cube of the integer {base}.
        /// </summary>
        /// <param name="baseValue">The integer value to be cubed.</param>
        /// <returns>The absolute cube of the input integer.</returns>
        /// <example>GET api/q3/cube/4</example>
        [HttpGet("cube/{baseValue:int}")]
        public ActionResult<int> GetCube(int baseValue)
        {
            // Calculate the absolute cube
            int cube = Math.Abs(baseValue) * Math.Abs(baseValue) * Math.Abs(baseValue);
            return Ok(cube);
        }
    }
}
