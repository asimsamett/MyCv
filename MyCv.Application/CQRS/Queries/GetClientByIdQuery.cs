using MediatR;
using MyCv.Application.CQRS.Results;

namespace MyCv.Application.CQRS.Queries
{
    public class GetClientByIdQuery:IRequest<GetClientByIdResult>
    {
        public Guid Id { get; set; }

        public GetClientByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
