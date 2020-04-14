using System;
using System.Threading.Tasks;

namespace Submarine.ServiceBus.Models
{
    class Program
    {
        static IServiceBusHandler _handler;

        static void Main(string[] args)
        {
            var connectionString = "Endpoint=sb://yukistest.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=vEpNyi3CYNhiLz7a6m7s10GMJnjZc2wsgPBFrLSDLcs=";
            var topic = "chat";
            var subscription = "MyFirstChat";
            var queueName = "myfirstqueue";

            for (var i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-ConnectionString":
                        Console.WriteLine($"ConnectionString: {args[i + 1]}");
                        connectionString = args[i + 1]; // Alternatively enter your connection string here.
                        break;
                    case "-Topic":
                        Console.WriteLine($"Topic: {args[i + 1]}");
                        topic = args[i + 1]; // Alternatively enter your queue name here.
                        break;
                    case "-Subscription":
                        Console.WriteLine($"Subscption: {args[i + 1]}");
                        subscription = args[i + 1]; // Alternatively enther your queue name here.
                        break;
                    case "-Queue":
                        Console.WriteLine($"Queue: {args[i + 1]}");
                        queueName = args[i + 1]; // Alternatively enter your queue name here.
                        break;
                }
            }

            _handler = new ServiceBusTopicHandler(connectionString, topic, subscription);
            //_handler = new ServiceBusQueueHandler(connectionString, queueName);

            while (true)
            {
                readInput();
            }
        }

        static void readInput()
        {
            var line = Console.ReadLine();
            var task = _handler.SendMessagesAsync(line);

            Task.WaitAll(task);
        }
    }
}
