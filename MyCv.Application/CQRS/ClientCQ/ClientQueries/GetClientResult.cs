using MyCv.Application.CQRS.ClientCQ.ClientFeature.ClientFeatureQueries;
using MyCv.Domain.Entities;

namespace MyCv.Application.CQRS.ClientCQ.ClientQueries
{
    public class GetClientResult
    {
        //public GetClientResult(Guid ıd, string? name, string? surname, string? phoneNumber, string? address, string? email, GetClientFutureResult? clientFeature)
        //{
        //    Id = ıd;
        //    Name = name;
        //    Surname = surname;
        //    PhoneNumber = phoneNumber;
        //    Address = address;
        //    Email = email;
        //    ClientFeature = clientFeature;
        //}

        public Guid Id { get; set; }

        
        public string? Name { get; set; }

        
        public string? Surname { get; set; }

        
        public string? PhoneNumber { get; set; }

        
        public string? Address { get; set; }

        
        public string? Email { get; set; }

        
        public GetClientFutureResult? ClientFeature { get; set; }
    }

}
