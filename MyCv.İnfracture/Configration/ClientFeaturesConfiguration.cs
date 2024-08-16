using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCv.Domain.Entities;

namespace MyCv.İnfracture.Configration
{
    public class ClientFeaturesConfiguration : IEntityTypeConfiguration<ClientFeatures>
    {
        public void Configure(EntityTypeBuilder<ClientFeatures> builder)
        {
            //Referance Configure
            builder.Property(x => x.Referance);

            //Position Configure
            builder.Property(x => x.Position);
        }
    }
}
