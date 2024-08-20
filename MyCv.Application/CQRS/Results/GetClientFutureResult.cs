using MyCv.Domain.Entities.Enums;

namespace MyCv.Application.CQRS.Results
{

    public class GetClientFutureResult 
    {
        public Positions Position { get;  set; }
        public Education Education { get;  set; }
        public string Referance { get;  set; }
    }
}
