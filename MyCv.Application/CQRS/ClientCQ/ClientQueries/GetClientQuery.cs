using MediatR;
using MyCv.Domain.Entities.Client;

namespace MyCv.Application.CQRS.ClientCQ.ClientQueries
{
    public class GetClientQuery : IRequest<List<GetClientResult>>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public ClientFeatures ClientFeature { get; set; }


    }
}
