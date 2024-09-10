using MediatR;
using MyCv.Application.CQRS.ClientCQ.ClientCreate;
using MyCv.Domain.Entities.Enums;

namespace MyCv.Application.CQRS.ClientCQ.ClientUpdate
{

    public class UpdateClientCommand : IRequest
    {
        public Guid ClientId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public ClientFeaturesDto UpdateClientFeatures { get; set; }
    }

}
