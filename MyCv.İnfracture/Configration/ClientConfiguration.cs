using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCv.Domain.Entities;

namespace MyCv.İnfracture.Configration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {

        //Fuent Api Configuration işlemlerini burda yapıyoruz. 

        public void Configure(EntityTypeBuilder<Client> builder)
        {
            //Id Configure
            builder.Property(x => x.Id)
                .IsRequired();
            builder.HasKey(x => x.Id);
            
            //Name Configure
            builder.Property(z => z.Name)
                .IsRequired();

            //Surname Configure
            builder.Property(z=>z.Surname)
                .IsRequired();

            //PhoneNumber Configure
            builder.Property(z=>z.PhoneNumber)
                .HasMaxLength(10);
            //Address Configure
            builder.Property(z => z.Address)
                .HasMaxLength(10);

        }
    }
}
