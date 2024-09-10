using MediatR;
using MyCv.Application.Interfaces.ICacheRepository;

namespace MyCv.Application.CQRS.AdminCQ.AdminDelete
{
    public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand>
    {
        private readonly IWriteCacheRepostory _writeCacheRepostory;

        public DeleteAdminCommandHandler(IWriteCacheRepostory writeCacheRepostory)
        {
            _writeCacheRepostory = writeCacheRepostory;
        }

        public async Task Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
        {
            await _writeCacheRepostory.RemoveAsync(request.Id);

        }
    }
}
