using MediatR;
using MyCv.Domain.Entities;

namespace MyCv.Application.CQRS.Command
{
    public class DeleteClientCommand:IRequest
    {
        public Guid Id { get; set; }

        public DeleteClientCommand(Guid id)
        {
            Id = id;
        }
    }
}
