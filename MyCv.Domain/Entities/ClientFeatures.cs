using MyCv.Domain.Entities.Enums;


namespace MyCv.Domain.Entities
{

    public class ClientFeatures:BaseEntitiy
    {

        public Positions Position { get; private set; }
        public Education Education { get; private set; }
        public string Referance { get; private set; }
        

    }
}
