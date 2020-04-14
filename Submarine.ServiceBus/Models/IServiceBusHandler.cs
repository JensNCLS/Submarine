using System.Threading.Tasks;

namespace Submarine.ServiceBus.Models
{
    public interface IServiceBusHandler
    {
        Task SendMessagesAsync(string message);
    }
}
