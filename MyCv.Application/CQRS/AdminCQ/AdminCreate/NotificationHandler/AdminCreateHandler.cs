using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCv.Application.CQRS.AdminCQ.AdminCreate.NotificationHandler
{
    public class AdminCreateHandler : INotificationHandler<AdminCreateNotification>
    {
        
            private readonly ILogger<AdminCreateHandler> _logger;
            private readonly IPublishEndpoint _publishEndpoint;

            public AdminCreateHandler(ILogger<AdminCreateHandler> logger, IPublishEndpoint publishEndpoint)
            {
                _logger = logger;
                _publishEndpoint = publishEndpoint;
            }

            public async Task Handle(AdminCreateNotification notification, CancellationToken cancellationToken)
            {
                var message = $"{notification.admin.UserName} kullanıcısı oluşturuldu";

                await _publishEndpoint.Publish(new AdminNotificationMessage
                {
                    Text = $" Published : " + message
                }, cancellationToken);
            }

            public class AdminNotificationMessage()
            {
                public string Text { get; set; }

            }
        }
    }

