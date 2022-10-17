// See https://aka.ms/new-console-template for more information

using CommandLine;
using RabbitEater;
using RabbitMQ.Client;


Parser.Default.ParseArguments<Options>(args)
    .WithParsed<Options>(o =>
    {
        ConnectionFactory connectionFactory = new ConnectionFactory

        {
            HostName = o.HostName,

            UserName = o.UserName,

            Password = o.Password,
            
            Port = o.Port,
            

        };

        var connection = connectionFactory.CreateConnection();

        var channel = connection.CreateModel();


// accept only one unack-ed message at a time

// uint prefetchSize, ushort prefetchCount, bool global


        channel.BasicQos(0, 1, false);

        var messageReceiver = new Consumer(channel, o.OutputPath, o.Exchange,o.RoutingKey);

        channel.BasicConsume(o.Queue, false, messageReceiver);

        Console.ReadLine();
    });