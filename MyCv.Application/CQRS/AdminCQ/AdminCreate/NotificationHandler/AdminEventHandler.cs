using MassTransit;
using static MyCv.Application.CQRS.AdminCQ.AdminCreate.NotificationHandler.AdminCreateHandler;

namespace MyCv.Application.CQRS.AdminCQ.AdminCreate.NotificationHandler
{
    public class AdminEventHandler:IConsumer<AdminNotificationMessage>
    {
        public Task Consume(ConsumeContext<AdminNotificationMessage> context)
        {
            var message = context.Message.Text;
            Console.WriteLine(message);

            return Task.CompletedTask;
        }
    }
}
