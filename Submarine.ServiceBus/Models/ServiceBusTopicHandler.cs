using Microsoft.Azure.ServiceBus;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Text;

namespace Submarine.ServiceBus.Models
{
    class ServiceBusTopicHandler : IServiceBusHandler
    {
        ITopicClient topicClient;
        ISubscriptionClient subscriptionClient;

        public ServiceBusTopicHandler(string connectionString, string topic, string subsciptionName)
        {
            topicClient = new TopicClient(connectionString, topic);
            subscriptionClient = new SubscriptionClient(connectionString, topic, subsciptionName);

            // Register subscription message handler and receive messages in a loop
            RegisterOnMessageHandlerAndReceiveMessages();
        }

        public async Task SendMessagesAsync(string message)
        {
            try
            {
                // Create a new message to send to the topic.
                var encodedMessage = new Message(Encoding.UTF8.GetBytes(message));
                // Send the message to the topic.
                await topicClient.SendAsync(encodedMessage);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }
        }

        void RegisterOnMessageHandlerAndReceiveMessages()
        {
            // Configure the messgae ahndler options in terms of exception handling, number of concurrent messages to deliver, etc.
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                // Maximum number of concurrent calls to tghe callvack ProcessMessagesAsync(), Set to 1 for simplicity.
                // Set it according to how many messages the application wants to process in parallel.
                MaxConcurrentCalls = 1,

                // Incidactes wheter the messages pump should automatically complete the messages after returning from user callback.
                // False below indicates the complete opreation is handled by the user callback as in ProcessMessagesAsync().
                AutoComplete = false
            };

            // Receive the function that process messages.
            subscriptionClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        }

        async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            // Process the message.
            Console.WriteLine($"Received message from topic: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");

            // Complete the message so that it is not received again.
            // This can be done only if the subscriptionClient is created in ReceiveMode.Peeklock mode (which is the default).
            await subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);

            // Note: Use the cancellationToken passed as necessary to determine if the subscriptionClient has already been closed.
            // If subscriptionClient has already been closed, you can choose to not call CompleteAsyync() or AbandonAsync() etc.
            // to avoid unnecesssary exceptions.
        }

        // Use this handler to examine the exceptions received on the message pump.
        Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            Console.WriteLine($"Message handler encoutered an eception {exceptionReceivedEventArgs.Exception}.");
            var context = exceptionReceivedEventArgs.ExceptionReceivedContext;
            Console.WriteLine("Exception context for troubleshooting:");
            Console.WriteLine($"- Endpoint: {context.Endpoint}");
            Console.WriteLine($"- Entity Path: {context.EntityPath}");
            Console.WriteLine($"- Execution Action: {context.Action}");
            return Task.CompletedTask;
        
        }
    }
}
