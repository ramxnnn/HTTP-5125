using Microsoft.AspNetCore.Mvc;

namespace assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecretInstructionController : ControllerBase
    {
        [HttpGet("DecodeInstructions")]
        public IActionResult DecodeInstructions([FromQuery] string instruction1, [FromQuery] string instruction2, [FromQuery] string instruction3, [FromQuery] string instruction4)
        {
            // Assuming the 99999 terminates the instructions, you can have more parameters for additional instructions
            string[] instructions = { instruction1, instruction2, instruction3, instruction4 };

            List<string> decodedInstructions = new List<string>();
            string previousDirection = string.Empty; // Keep track of the last direction

            foreach (string instruction in instructions)
            {
                if (instruction == "99999")
                {
                    // Stop processing if the end signal is encountered
                    break;
                }

                if (instruction.Length != 5)
                {
                    return BadRequest("Each instruction must be exactly 5 digits.");
                }

                // Extract the first two digits (for direction) and the last three digits (for steps)
                int firstTwoDigits = int.Parse(instruction.Substring(0, 2));
                int lastThreeDigits = int.Parse(instruction.Substring(2, 3));

                int x = firstTwoDigits / 10; // First digit
                int y = firstTwoDigits % 10; // Second digit
                int sum = x + y;

                string direction;

                if (sum == 0)
                {
                    // Use the previous direction if sum is zero
                    direction = previousDirection;
                }
                else if (sum % 2 == 0)
                {
                    // Even sum, turn right
                    direction = "right";
                }
                else
                {
                    // Odd sum, turn left
                    direction = "left";
                }

                // Store the current direction for future use (in case the next sum is zero)
                previousDirection = direction;

                // Create the decoded instruction (direction + steps)
                decodedInstructions.Add($"{direction} {lastThreeDigits}");
            }

            // Return the decoded instructions
            return Ok(decodedInstructions);
        }
    }
}
