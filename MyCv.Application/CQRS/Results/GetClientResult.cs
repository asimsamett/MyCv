using MyCv.Application.CQRS.Results;
using MyCv.Domain.Entities;

namespace MyCv.Application.CQRS.DTO
{
    public class GetClientResult
    {
        
        
        /// <summary>
        /// Gets or sets the unique identifier for the client.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the client.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the surname (last name) of the client.
        /// </summary>
        public string? Surname { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the client.
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the address of the client.
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Gets or sets the email address of the client.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the features associated with the client, such as position, education, and reference.
        /// </summary>
        public GetClientFutureResult? ClientFeature { get; set; }
    }

}
