namespace MyCv.Domain.Entities
{
    public class Client:BaseEntitiy
    {
        /// <summary>
        /// 
        /// </summary>
        
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="address"></param>
        /// <param name="email"></param>
        /// 
        public void ClientProperties(string name, string surname, string phoneNumber, string address, string email)
        {
            
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Address = address;
            Email = email;
        }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Address { get; private set; }
        public string Email { get; private set; }
    }

}
