using MyCv.Domain.Entities.Enums;


namespace MyCv.Domain.Entities.Client
{

    public class ClientFeatures : BaseEntitiy
    {
        /// <summary>
        /// ClientFeatures
        /// </summary>
        /// <param name="position"></param>
        /// <param name="education"></param>
        /// <param name="referance"></param>
        public ClientFeatures(Positions position, Education education, string referance)
        {
            Position = position;
            Education = education;
            Referance = referance;
        }



        /// <summary>
        /// ClientId
        /// </summary>
        public Guid ClientId { get; set; }
        /// <summary>
        /// Position
        /// </summary>
        public Positions Position { get; set; }
        /// <summary>
        /// Education
        /// </summary>
        public Education Education { get; set; }
        /// <summary>
        /// Referance
        /// </summary>
        public string Referance { get; set; }
        /// <summary>
        /// Client
        /// </summary>
        public Client Client { get; set; }


    }
}
