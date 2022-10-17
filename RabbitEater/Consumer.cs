using System.Text;
using RabbitMQ.Client;

namespace RabbitEater;

public class Consumer : DefaultBasicConsumer

{

    private readonly IModel _channel;

    private readonly string? _filePath;
    private readonly string? _exchangeName;
    private readonly string? _routingKey;
    public Consumer(IModel channel, string filePath, string? exchangeName, string? routingKey)

    {
        _channel = channel;
        _filePath = filePath;
        _exchangeName = exchangeName;
        _routingKey = routingKey;
    }

    public override void HandleBasicDeliver(string consumerTag, ulong deliveryTag, bool redelivered, string exchange, string routingKey, IBasicProperties properties, ReadOnlyMemory<byte> readOnlyMemory)

    {
        
        if(_exchangeName != null && _exchangeName != exchange)
        {
            return;
        }
        
        if(_routingKey != null && _routingKey != exchange)
        {
            return;
        }
        var message = new StringBuilder(6);
     
         message.AppendLine($"Consuming Message");

         message.AppendLine(string.Concat("Message received from the exchange ", exchange));

         message.AppendLine(string.Concat("Consumer tag: ", consumerTag));

         message.AppendLine(string.Concat("Delivery tag: ", deliveryTag));

         message.AppendLine(string.Concat("Routing tag: ", routingKey));

         message.AppendLine(string.Concat("Message: ", Encoding.UTF8.GetString(readOnlyMemory.ToArray())));

         if(_filePath != null)
         {
             File.WriteAllText(_filePath, message.ToString());
         }
         else
         {
             Console.WriteLine(message.ToString());
         }
         
        _channel.BasicAck(deliveryTag, false);

    }

}