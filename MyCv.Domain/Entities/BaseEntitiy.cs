namespace MyCv.Domain.Entities
{
    public class BaseEntitiy
    {
        public Guid Id { get; set; }

        public void BaseEntitiyProperty(Guid ıd)
        {
            Id = ıd;
        }
    }
}
