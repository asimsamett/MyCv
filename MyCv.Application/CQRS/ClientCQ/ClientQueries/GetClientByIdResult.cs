using MyCv.Application.CQRS.ClientCQ.ClientCreate;
using MyCv.Domain.Entities.Client;

namespace MyCv.Application.CQRS.ClientCQ.ClientQueries
{
    public class GetClientByIdResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public ClientFeaturesDto? ClientFeature { get; set; }
    }

    
}
