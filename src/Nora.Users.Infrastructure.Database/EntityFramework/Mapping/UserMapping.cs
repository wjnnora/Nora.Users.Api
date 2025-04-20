using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nora.Users.Domain.Entities;

namespace Nora.Users.Infrastructure.Database.EntityFramework.Mapping;

public sealed class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));

        builder.HasKey(k => k.Id);
        builder.Property(p => p.FirstName).HasColumnType("VARCHAR(100)");
        builder.Property(p => p.LastName).HasColumnType("VARCHAR(100)");
        builder.Property(p => p.DateOfBirth).HasColumnType("TIMESTAMP");
        builder.Property(p => p.CreatedAt).HasColumnType("TIMESTAMP");

        builder.HasOne(p => p.Address);
    }
}