using MediatR;

namespace MyCv.Application.CQRS.AdminCQ.AdminDelete
{
    public class DeleteAdminCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteAdminCommand(Guid ıd)
        {
            Id = ıd;
        }
    }
}
