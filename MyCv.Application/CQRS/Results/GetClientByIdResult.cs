using MyCv.Domain.Entities;

namespace MyCv.Application.CQRS.Results
{
    public class GetClientByIdResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public ClientFeatures? ClientFeature { get; set; }
    }
}
