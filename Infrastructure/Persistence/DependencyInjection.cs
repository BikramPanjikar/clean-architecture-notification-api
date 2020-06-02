using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notification.Application.Interfaces;

namespace Notification.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NotificationDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("NotificationDatabase")));

            services.AddScoped<INotificationDBContaxt>(provider => provider.GetService<NotificationDBContext>());

            return services;
        }
    }
}

