using MediatR;
using MyCv.Domain.Entities.Enums;


namespace MyCv.Application.CQRS.Command
{
    public class CreateClientCommand:IRequest
    {
       

        public string Name { get;  set; }
        public string Surname { get;  set; }
        public string PhoneNumber { get;  set; }
        public string Address { get;  set; }
        public string Email { get;  set; }
        public ClientFeaturesDto ClientFeature { get; set; }
        
    }


    public class ClientFeaturesDto
    {
        public ClientFeaturesDto(Positions position, Education education, string referance)
        {
            Position = position;
            Education = education;
            Referance = referance;
        }

        public Positions Position { get;  set; }
       
        public Education Education { get;  set; }
        
        public string Referance { get;  set; }
    }
}
