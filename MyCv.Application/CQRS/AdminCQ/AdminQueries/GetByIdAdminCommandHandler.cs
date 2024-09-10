using MediatR;
using MyCv.Application.Interfaces.ICacheRepository;
using MyCv.Domain.Entities.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCv.Application.CQRS.AdminCQ.AdminQueries
{
    public class GetByIdAdminCommandHandler : IRequestHandler<GetAdminByIdQuery, GetAdminByIdResult>
    {
        private readonly IReadCacheRepostory _readCacheRepostory;

        public GetByIdAdminCommandHandler(IReadCacheRepostory readCacheRepostory)
        {
            _readCacheRepostory = readCacheRepostory;
        }

        public async Task<GetAdminByIdResult> Handle(GetAdminByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _readCacheRepostory.GetByIdAsync<Admin>(request.Id);
            return new GetAdminByIdResult
            {
                Id = values.Id,
                UserName = values.UserName,
                Password = values.Password
            };
        }
    }
}
