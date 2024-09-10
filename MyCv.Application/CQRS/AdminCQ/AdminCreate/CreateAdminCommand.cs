using MediatR;

namespace MyCv.Application.CQRS.AdminCQ.AdminCreate
{
    public class CreateAdminCommand : IRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
