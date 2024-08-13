using Core.Interfaces;
using RabbitMQ.Client;
using System.Text;

namespace Infrastructure.Messaging
{
    public class RabbitMQService : IMessageQueueService
    {
        private readonly IConnection _connection;
        public RabbitMQService()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
        }
        public void SendMessage(string queueName, string message)
        {
            using (var channel = _connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: queueName,
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}
