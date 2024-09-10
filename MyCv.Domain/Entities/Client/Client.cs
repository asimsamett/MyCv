namespace MyCv.Domain.Entities.Client
{
    public class Client : BaseEntitiy
    {


        /// <summary>
        /// ClientProperties
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="address"></param>
        /// <param name="email"></param>
        /// <param name="ClientFeatures"></param>
        public void ClientProperties(string name, string surname, string phoneNumber, string address, string email, ClientFeatures ClientFeatures)
        {
            Id = Guid.NewGuid();
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Address = address;
            Email = email;
            ClientFeature = ClientFeatures;
        }



        /// <summary>
        /// ClientFeatureId
        /// </summary>
        public Guid ClientFeatureId { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string? Name { get; private set; }
        /// <summary>
        /// Surname
        /// </summary>
        public string? Surname { get; private set; }
        /// <summary>
        /// PhoneNumber
        /// </summary>
        public string? PhoneNumber { get; private set; }
        /// <summary>
        /// Address
        /// </summary>
        public string? Address { get; private set; }
        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; private set; }
        /// <summary>
        /// ClientFeature
        /// </summary>
        public ClientFeatures? ClientFeature { get; set; }

    }

}
