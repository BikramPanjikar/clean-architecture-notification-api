using Microsoft.EntityFrameworkCore;

namespace Notification.Infrastructure.Persistence
{
    public class NotificationDBContextFactory : DesignTimeDbContextFactoryBase<NotificationDBContext>
    {
        protected override NotificationDBContext CreateNewInstance(DbContextOptions<NotificationDBContext> options)
        {
            return new NotificationDBContext(options);
        }
    }
}

