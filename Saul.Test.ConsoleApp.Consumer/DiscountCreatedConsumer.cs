using MassTransit;
using Saul.Test.Domain.Events;
using System.Text.Json;

namespace Saul.Test.ConsoleApp.Consumer
{
    public class DiscountCreatedConsumer : IConsumer<DiscountCreatedEvent>
    {
        public async Task Consume(ConsumeContext<DiscountCreatedEvent> context)
        {
            var jsonMessage = JsonSerializer.Serialize(context.Message);
            await Console.Out.WriteLineAsync(jsonMessage);
        }
    }
}
