namespace MyCv.Domain.Entities.Admin
{
    public class Admin
    {
      
        public void AdminProperties(string userName, string password)
        {
            Id = Guid.NewGuid();
            UserName = userName;
            Password = password;

        }



        public static Admin AdminWrite(string userName, string password)
        {
            Admin a = new Admin();

            a.Id = Guid.NewGuid();
            a.UserName = userName;
            a.Password = password;

            return a;
        }

        public  Admin Update(string userName, string password)
        {

            UserName = userName;
            Password= password;
            return this;

        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
