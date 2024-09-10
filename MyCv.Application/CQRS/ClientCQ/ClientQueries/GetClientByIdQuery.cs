using MediatR;

namespace MyCv.Application.CQRS.ClientCQ.ClientQueries
{
    public class GetClientByIdQuery : IRequest<GetClientByIdResult>
    {
        public Guid Id { get; set; }

        public GetClientByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
