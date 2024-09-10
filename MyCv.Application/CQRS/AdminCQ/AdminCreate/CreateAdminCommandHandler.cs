using MediatR;
using MyCv.Application.CQRS.AdminCQ.AdminCreate.NotificationHandler;
using MyCv.Application.Interfaces.ICacheRepository;


using MyCv.Domain.Entities.Admin;

namespace MyCv.Application.CQRS.AdminCQ.AdminCreate
{
    public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand>
    {
        private readonly IWriteCacheRepostory _writeCacheRepostory;
        private readonly IPublisher _publisher;

        public CreateAdminCommandHandler(IWriteCacheRepostory writeCacheRepostory, IPublisher publisher)
        {
            _writeCacheRepostory = writeCacheRepostory;
            _publisher = publisher;
        }

        public async Task Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {


            var admin = Admin.AdminWrite(
                userName: request.UserName,
                password: request.Password

                );
            await _writeCacheRepostory.CreateAsync<Admin>(admin, admin.Id);
            await _publisher.Publish(new AdminCreateNotification(admin),cancellationToken);


        }
    }
}
