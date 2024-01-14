using HiringSonda.Domain.AdressAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HiringSonda.Infra.Mapping
{
    public class AddressTypeConfiguration : IEntityTypeConfiguration<AddressUserDomain>
    {
        public void Configure(EntityTypeBuilder<AddressUserDomain> builder)
        {         
            builder.HasKey(x => x.Id);

            builder.Property(e => e.CEP).HasColumnType("varchar(30)").IsRequired();
            builder.Property(e => e.Street).HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.Complement).HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.Neighborhood).HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.City).HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.State).HasColumnType("varchar(100)").IsRequired();

            builder.ToTable("AddressUser");
        }
    }
}

