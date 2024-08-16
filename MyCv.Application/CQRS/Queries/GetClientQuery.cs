using MediatR;
using MyCv.Application.CQRS.DTO;

namespace MyCv.Application.CQRS.Queries
{
    public class GetClientQuery:IRequest<List<GetClientResult>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        //public GetClientQuery(Guid id, string name, string surname, string phoneNumber, string address, string email)
        //{
        //    Id = id;
        //    Name = name;
        //    Surname = surname;
        //    PhoneNumber = phoneNumber;
        //    Address = address;
        //    Email = email;
        //}
    }
}
