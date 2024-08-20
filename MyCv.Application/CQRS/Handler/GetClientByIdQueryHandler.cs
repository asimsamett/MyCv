using MediatR;
using MyCv.Application.CQRS.Queries;
using MyCv.Application.CQRS.Results;
using MyCv.Application.Interfaces;
using MyCv.Domain.Entities;

namespace MyCv.Application.CQRS.Handler
{
    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, GetClientByIdResult>
    {
        private readonly IClientRepository _context;

        public GetClientByIdQueryHandler(IClientRepository context)
        {
            _context = context;
        }

        public async Task<GetClientByIdResult> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.GettByIdAsync(request.Id);
            return new GetClientByIdResult
            { 
                Id = values.Id,
                Name = values.Name,
                Surname = values.Surname,
                PhoneNumber = values.PhoneNumber,
                Address = values.Address,
                Email = values.Email,
                //ClientFeature = new ClientFeatures(

                //    values.ClientFeature.Position,
                //    values.ClientFeature.Education,
                //    values.ClientFeature.Referance
                //)
            };
        }
    }
}

