using MediatR;
using MyCv.Application.CQRS.DTO;
using MyCv.Application.CQRS.Queries;
using MyCv.Application.Interfaces;
using MyCv.Domain.Entities;

namespace MyCv.Application.CQRS.Handler
{
    public class GetClientQueryHandler : IRequestHandler<GetClientQuery, List<GetClientResult>>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IClientElasticSearch _elasticClient;

        public GetClientQueryHandler(IClientRepository clientRepository, IClientElasticSearch elasticClient)
        {
            _clientRepository = clientRepository;
            _elasticClient = elasticClient;
        }

        public async Task<List<GetClientResult>> Handle(GetClientQuery request, CancellationToken cancellationToken)
        {
            var clients = await _clientRepository.GetAllAsync();
            
            var results = clients.Select(client => new GetClientResult
            {
               Id = client.Id,
               Name = client.Name,
               Surname = client.Surname,
               Email= client.Email,
               Address= client.Address,
               PhoneNumber= client.PhoneNumber
            }).ToList();

            return results;
        }
    }
}
