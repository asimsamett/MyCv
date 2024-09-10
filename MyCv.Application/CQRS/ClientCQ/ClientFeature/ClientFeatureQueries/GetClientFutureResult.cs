using MyCv.Domain.Entities.Enums;

namespace MyCv.Application.CQRS.ClientCQ.ClientFeature.ClientFeatureQueries
{

    public class GetClientFutureResult
    {
        //public GetClientFutureResult(Positions position, Education education, string referance)
        //{
        //    Position = position;
        //    Education = education;
        //    Referance = referance;
        //}

        public Positions Position { get; set; }
        public Education Education { get; set; }
        public string Referance { get; set; }
    }
}
