using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infraestructure.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");
            builder.HasKey(key => key.Id);
            builder.HasIndex(p => p.Email)
                .IsUnique();
            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(60);
            builder.Property(u => u.Email)
               .IsRequired()
               .HasMaxLength(100);
            builder.Property(u => u.CreatedAt)
               .IsRequired();
            builder.Property(u => u.UpdatedAt);
        }
    }
}
