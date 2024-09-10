using MediatR;
using MyCv.Application.Interfaces.IRepository;
using MyCv.Domain.Entities;

namespace MyCv.Application.CQRS.ClientCQ.ClientQueries
{
    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, GetClientByIdResult>
    {
        private readonly IReadRepository _context;

        public GetClientByIdQueryHandler(IReadRepository context)
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
                ClientFeature = new ClientCreate.ClientFeaturesDto(

                    values.ClientFeature.Position,
                    values.ClientFeature.Education,
                    values.ClientFeature.Referance
                )
            };
        }
    }
}

