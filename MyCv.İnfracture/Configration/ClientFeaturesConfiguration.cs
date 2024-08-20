using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCv.Domain.Entities;

namespace MyCv.İnfracture.Configration
{
    public class ClientFeaturesConfiguration : IEntityTypeConfiguration<ClientFeatures>
    {
        //Fuent Api  ClientFeatures Entity için Configuration işlemlerini burda yapıyoruz. 


        public void Configure(EntityTypeBuilder<ClientFeatures> builder)
        {
            // ClientFeatures PK
            builder.HasKey(x => x.Id);

            //Referance Configure
            builder.Property(x => x.Referance);
            
            //Position Configure
            builder.Property(x => x.Position);
        }
    }
}
