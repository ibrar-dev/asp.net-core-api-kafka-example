using Confluent.Kafka;

namespace producerAPP.Services
{
    public class ProducerService
    {
        private readonly IConfiguration _configuration;

        private readonly IProducer<Null, string> _producer;

        public ProducerService(IConfiguration configuration)
        {
            _configuration = configuration;

            var producerconfig = new ProducerConfig
            {
                BootstrapServers = "localhost:9094"
            };

            _producer = new ProducerBuilder<Null, string>(producerconfig).Build();
        }

        public async Task ProduceAsync(string topic, string message)
        {
            var kafkamessage = new Message<Null, string> { Value = message, };
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine(kafkamessage);
            await _producer.ProduceAsync(topic, kafkamessage);
        }
    }
}

