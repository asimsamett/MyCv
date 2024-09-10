using MediatR;
using MyCv.Application.Interfaces.ICacheRepository;
using MyCv.Domain.Entities.Admin;

namespace MyCv.Application.CQRS.AdminCQ.AdminUpdate
{
    public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand>
    {
        private readonly IReadCacheRepostory _readCacheRepostory;
        private readonly IWriteCacheRepostory _writeCacheRepostory;

        public UpdateAdminCommandHandler(IReadCacheRepostory readCacheRepostory, IWriteCacheRepostory writeCacheRepostory)
        {
            _readCacheRepostory = readCacheRepostory;
            _writeCacheRepostory = writeCacheRepostory;
        }



        public async Task Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {
            //var admin = await _readCacheRepostory.GetByIdAsync<Admin>(request.Id);
            //if (admin == null)
            //{
            //    throw new KeyNotFoundException("Geçerli Bir ID Değil!");
            //};
            //admin.AdminWrite
            // (
            //    request.UserName,
            //    request.Password
            // );
            //await _writeCacheRepostory.UpdateAsync(request.Id, admin);

            var admin = await _readCacheRepostory.GetByIdAsync<Admin>(request.Id);
            admin.AdminProperties
                (
                    request.UserName,
                    request.Password
                );
            await _writeCacheRepostory.UpdateAsync(request.Id, request);

        }
    }
}
