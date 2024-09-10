using MediatR;
using MyCv.Application.CQRS.ClientCQ.ClientCreate;
using MyCv.Application.CQRS.ClientCQ.ClientFeature.ClientFeatureQueries;
using MyCv.Application.Interfaces.IElasticSearchRepostory;
using MyCv.Application.Interfaces.IRepository;
using MyCv.Domain.Entities.Client;
using System.Net;

namespace MyCv.Application.CQRS.ClientCQ.ClientQueries
{
    public class GetClientQueryHandler : IRequestHandler<GetClientQuery, List<GetClientResult>>
    {
        private readonly IReadRepository _clientRepository;
        private readonly IReadElasticSearchRepostory _elasticSearchRepostory;


        public GetClientQueryHandler(IReadRepository clientRepository, IReadElasticSearchRepostory elasticSearchRepostory)
        {
            _clientRepository = clientRepository;
            _elasticSearchRepostory = elasticSearchRepostory;
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
                    ClientFeature = new GetClientFutureResult()
                    {
                        Referance = client.ClientFeature.Referance,
                        Position = client.ClientFeature.Position,
                        Education = client.ClientFeature.Education
                    }
                }
            ).ToList();
            //var products = await _clientRepository.GetAllAsync();
            //var productListDto = products.Select(x => new GetClientResult(
            //    x.Id,
            //    x.Name,
            //    x.Surname,
            //    x.Address,
            //    x.Email,
            //    x.PhoneNumber,
            //    new GetClientFutureResult
            //    (
            //        x.ClientFeature.Position,
            //        x.ClientFeature.Education,
            //        x.ClientFeature.Referance
            //        )
            //    )
            //).ToList();




            return results;
        }
    }
}
