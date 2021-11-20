using HiringSonda.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HiringSonda.Infra.Mapping
{
    public class AddressTypeConfiguration : IEntityTypeConfiguration<AddressUser>
    {
        public void Configure(EntityTypeBuilder<AddressUser> builder)
        {         
            builder.HasKey(x => x.Id);

            builder.Property(e => e.CEP).IsRequired();
            builder.Property(e => e.Street).IsRequired();
            builder.Property(e => e.Complement).IsRequired();
            builder.Property(e => e.Neighborhood).IsRequired();
            builder.Property(e => e.City).IsRequired();
            builder.Property(e => e.State).IsRequired();

            builder.ToTable("AddressUser");
        }
    }
}

