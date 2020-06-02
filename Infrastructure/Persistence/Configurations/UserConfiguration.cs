using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notification.Domain.Entities;

namespace Notification.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.UserId).HasColumnName("UserId");
            builder.Property(e => e.UserId)
                .UseIdentityColumn(1, 1)
                .IsRequired();

            builder.Property(e => e.UserName).HasColumnName("UserName");

            builder.Property(e => e.Email).HasColumnName("Email");

            builder.Property(e => e.Retries).HasColumnName("Retries");

            builder.Property(e => e.IsVerified).HasColumnName("IsVerified");

        }
    }
}

