using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nora.Users.Domain.Entities;

namespace Nora.Users.Infrastructure.Database.EntityFramework.Mapping;

public sealed class AddressMapping : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable(nameof(Address));

        builder.HasKey(k => k.Id);
        builder.Property(p => p.Street).HasColumnType("VARCHAR(250)");
        builder.Property(p => p.City).HasColumnType("VARCHAR(250)");
        builder.Property(p => p.State).HasColumnType("CHAR(2)");
        builder.Property(p => p.ZipCode).HasColumnType("VARCHAR(10)");
        builder.Property(p => p.Country).HasColumnType("VARCHAR(100)");
        builder.Property(p => p.CreatedAt).HasColumnType("TIMESTAMP");

        builder.HasOne(p => p.User)
            .WithOne()
            .HasForeignKey<User>(p => p.AddressId);
    }
}