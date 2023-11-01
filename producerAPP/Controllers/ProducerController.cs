using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using producerAPP.Models;
using producerAPP.Services;
using System.Text.Json;

namespace producerAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : Controller
    {
        private readonly ProducerService _producerService;
        public ProducerController(ProducerService producerService)
        {
            _producerService = producerService;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInventory([FromBody] InventoryUpdateRequest request)
        {
            var message = JsonSerializer.Serialize(request);


            //using (var producer = new ProducerBuilder<Null, string>(_configuration).Build())
            //{
            //    await producer.ProduceAsync("TestTopic", new Message<Null, string> { Value = message });
            //    producer.Flush(TimeSpan.FromSeconds(10));
            //    return Ok(true);
            //}

            await _producerService.ProduceAsync("TestTopic", message);

            return Ok("Inventory Updated Successfully...");
        }

    }
}
