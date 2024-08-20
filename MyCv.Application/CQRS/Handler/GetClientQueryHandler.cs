using MediatR;
using MyCv.Application.CQRS.DTO;
using MyCv.Application.CQRS.Queries;
using MyCv.Application.CQRS.Results;
using MyCv.Application.Interfaces;

namespace MyCv.Application.CQRS.Handler
{
    public class GetClientQueryHandler : IRequestHandler<GetClientQuery, List<GetClientResult>>
    {
        private readonly IClientRepository _clientRepository;
        

        public GetClientQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
           
        }

        public async Task<List<GetClientResult>> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetAllAsync();
            var results = client.Select(
                client => new GetClientResult
                {
                    Id = client.Id,
                    Name = client.Name,
                    Surname = client.Surname,
                    Email = client.Email,
                    Address = client.Address,
                    PhoneNumber = client.PhoneNumber,
                    //ClientFeature = new GetClientFutureResult()
                    //{
                    //    Referance = client.ClientFeature.Referance,
                    //    Position = client.ClientFeature.Position,
                    //    Education = client.ClientFeature.Education
                    //}
                }
            ).ToList();

            return results;
        }
    }
}
