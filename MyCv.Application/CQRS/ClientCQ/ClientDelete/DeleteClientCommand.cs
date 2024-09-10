using MediatR;
using MyCv.Domain.Entities;

namespace MyCv.Application.CQRS.ClientCQ.ClientDelete
{
    public class DeleteClientCommand : IRequest
    {
        /// <summary>
        /// DeleteClientCommand
        /// </summary>
        /// <param name="id"></param>
        public DeleteClientCommand(Guid id)
        {
            Id = id;
        }


        public Guid Id { get; set; }

    }
}
