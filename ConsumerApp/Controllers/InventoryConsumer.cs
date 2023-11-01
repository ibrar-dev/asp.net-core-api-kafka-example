using Microsoft.AspNetCore.Mvc;

namespace ConsumerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryConsumer : Controller
    {
        private readonly ILogger _logger;

        public InventoryConsumer(ILogger logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult ProcessInventoryUpdate([FromBody] InventoryConsumer request)
        {
            return Ok("Inventory update processed successfully.");
        }

    }
}
