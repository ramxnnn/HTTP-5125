// Different J2 Problem
using Microsoft.AspNetCore.Mvc;

namespace assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FergusonballController : ControllerBase
    {
        /// <summary>
        /// Determines how many players on the team have a star rating greater than 40 and if the team is a gold team.
        /// </summary>
        /// <param name="N">The total number of players on the team.</param>
        /// <param name="scoresAndFouls">An array of alternating integers representing the players' scores and fouls.</param>
        /// <returns>The number of players with a star rating greater than 40, followed by a plus sign if the team is a gold team.</returns>
        /// <example>
        /// GET /api/Fergusonball?N=3&scoresAndFouls=12,4,10,3,9,1
        /// returns "3+"
        /// </example>
        [HttpGet]
        public IActionResult GetFergusonballRatings([FromQuery] int N, [FromQuery] int[] scoresAndFouls)
        {
            // Constants for points awarded per score and penalties per foul
            const int pointsPerScore = 5;
            const int penaltyPerFoul = 3;
            const int minStarRating = 40;

            int playersAbove40 = 0;  // Count of players with star ratings above 40
            bool isGoldTeam = true;  // Track if all players have star ratings above 40

            // Loop through the scores and fouls of each player
            for (int i = 0; i < N; i++)
            {
                int score = scoresAndFouls[i * 2];  // Points scored
                int fouls = scoresAndFouls[i * 2 + 1];  // Fouls committed

                // Calculate the star rating for the player
                int starRating = (score * pointsPerScore) - (fouls * penaltyPerFoul);

                // Check if the star rating is greater than 40
                if (starRating > minStarRating)
                {
                    playersAbove40++;
                }
                else
                {
                    isGoldTeam = false;  // If one player doesn't meet the gold team criteria, team is not gold
                }
            }

            // Build the result string
            string result = playersAbove40.ToString();
            if (isGoldTeam && playersAbove40 == N)
            {
                result += "+";  // Add the plus sign if the team is a gold team
            }

            // Return the result
            return Ok(result);
        }
    }
}
