namespace MyCv.Domain.Entities
{
    public class BaseEntitiy
    {

        /// <summary>
        /// BaseEntitiyProperty
        /// </summary>
        /// <param name="id"></param>
        public void BaseEntitiyProperty(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
