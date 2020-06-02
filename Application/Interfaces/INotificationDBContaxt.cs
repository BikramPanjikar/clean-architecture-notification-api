using Microsoft.EntityFrameworkCore;
using Notification.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Notification.Application.Interfaces
{
    public interface INotificationDBContaxt
    {
        DbSet<Notification.Domain.Entities.User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

