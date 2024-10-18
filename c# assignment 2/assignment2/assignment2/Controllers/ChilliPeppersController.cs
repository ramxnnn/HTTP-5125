using Microsoft.AspNetCore.Mvc;


namespace assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChilliPeppersController : ControllerBase
    {
        private readonly Dictionary<string, int> pepperSHUValues = new Dictionary<string, int>
        {
            { "Poblano", 1500 },
            { "Mirasol", 6000 },
            { "Serrano", 15500 },
            { "Cayenne", 40000 },
            { "Thai", 75000 },
            { "Habanero", 125000 }
        };

        /// <summary>
        /// Calculates the total spiciness of the chili based on the selected ingredients.
        /// </summary>
        /// <param name="ingredients">A comma-separated list of pepper names.</param>
        /// <returns>The total spiciness of the chili in Scolville Heat Units (SHU).</returns>
        /// <example>
        /// GET /api/ChilliPeppers?Ingredients=Poblano,Cayenne,Thai,Poblano
        /// Returns: 118000
        /// </example>
        [HttpGet]
        public IActionResult CalculateSpiciness([FromQuery] string ingredients)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(ingredients))
            {
                return BadRequest("The ingredients list cannot be empty.");
            }

            // Split the ingredients and calculate the total spiciness
            var ingredientList = ingredients.Split(',');
            int totalSpiciness = 0;

            foreach (var ingredient in ingredientList)
            {
                // Trim whitespace and check if the pepper is valid
                string trimmedIngredient = ingredient.Trim();
                if (pepperSHUValues.TryGetValue(trimmedIngredient, out int shuValue))
                {
                    totalSpiciness += shuValue;
                }
                else
                {
                    return BadRequest($"Invalid pepper name: {trimmedIngredient}");
                }
            }

            return Ok(totalSpiciness);
        }
    }
}
