using Microsoft.EntityFrameworkCore;
using Notification.Application.Interfaces;
using Notification.Domain.Entities;

namespace Notification.Infrastructure.Persistence
{
    public class NotificationDBContext : DbContext, INotificationDBContaxt
    {
        public NotificationDBContext(DbContextOptions<NotificationDBContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NotificationDBContext).Assembly);
        }
    }
}
