namespace Core.Interfaces
{
    public interface IMessageQueueService
    {
        void SendMessage(string queueName, string message);
    }
}
