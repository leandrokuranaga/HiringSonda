using HiringSonda.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HiringSonda.Infra.Mapping
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(e => e.FullName).IsRequired();
            builder.Property(e => e.BirthDate).IsRequired();
            builder.Property(e => e.CPF).IsRequired();
            builder.Property(e => e.Email).IsRequired();

            builder.HasOne(y => y.addressUser)
                    .WithOne(z => z.user);
            //.HasForeignKey<AddressUser>(b => b.IDUser);

            builder.ToTable("User");
        }
    }
}
