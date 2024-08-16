using MediatR;

namespace MyCv.Application.CQRS.Command
{
    public class CreateClientCommand:IRequest
    {
        public Guid ClientId { get; set; }
        public string Name { get;  set; }
        public string Surname { get;  set; }
        public string PhoneNumber { get;  set; }
        public string Address { get;  set; }
        public string Email { get;  set; }

        
    }
}
