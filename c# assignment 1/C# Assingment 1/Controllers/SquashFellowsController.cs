using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace MyApiProject.Controllers
{
    [ApiController]
    [Route("api/q8")]
    public class SquashFellowsController : ControllerBase
    {
        private const decimal SmallToyPrice = 25.50m; // Price of Small SquashFellow
        private const decimal LargeToyPrice = 40.50m; // Price of Large SquashFellow (corrected to $40.50)
        private const decimal HSTRate = 0.13m; // HST Rate

        /// <summary>
        /// Returns a checkout summary for an order of SquashFellows plushies.
        /// </summary>
        /// <param name="small">The number of small plushies ordered.</param>
        /// <param name="large">The number of large plushies ordered.</param>
        /// <returns>A summary of the order including costs, tax, and total.</returns>
        /// <example>POST api/q8/squashfellows with body: Small=1&Large=1</example>
        [HttpPost("squashfellows")]
        public ActionResult<string> GetOrderSummary([FromForm] int small, [FromForm] int large)
        {
            // Validate inputs
            if (small < 0 || large < 0)
            {
                return BadRequest("The number of small and large toys must be non-negative.");
            }

            // Calculate costs
            decimal smallTotal = small * SmallToyPrice;
            decimal largeTotal = large * LargeToyPrice;
            decimal subtotal = smallTotal + largeTotal;
            decimal tax = subtotal * HSTRate;
            decimal total = subtotal + tax;

            // Format output
            string summary = $"{small} Small @ ${SmallToyPrice.ToString("F2", CultureInfo.InvariantCulture)} = ${smallTotal.ToString("F2", CultureInfo.InvariantCulture)}; " +
                             $"{large} Large @ ${LargeToyPrice.ToString("F2", CultureInfo.InvariantCulture)} = ${largeTotal.ToString("F2", CultureInfo.InvariantCulture)}; " +
                             $"Subtotal = ${subtotal.ToString("F2", CultureInfo.InvariantCulture)}; " +
                             $"Tax = ${tax.ToString("F2", CultureInfo.InvariantCulture)} HST; " +
                             $"Total = ${total.ToString("F2", CultureInfo.InvariantCulture)}";

            return Ok(summary);
        }
    }
}
