using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Entities = Notification.Domain.Entities;
using Notification.Application.Interfaces;

namespace Notification.Application.SeedSampleData
{
    public class SampleDataSeeder
    {
        private readonly INotificationDBContaxt _context;

        public SampleDataSeeder(INotificationDBContaxt context)
        {
            _context = context;
        }

        public async Task SeedAllAsync(CancellationToken cancellationToken)
        {
            await SeedUsersAsync(cancellationToken);
        }

        private async Task SeedUsersAsync(CancellationToken cancellationToken)
        {
            if (_context.Users.Any())
            {
                return;
            }

            var users = new[]
            {
                new Entities.User { UserName = "Bikram Panjikar", Email = "bpanjikar1985@gmail.com", Retries = 3, IsVerified = false}
            };

            _context.Users.AddRange(users);

            await _context.SaveChangesAsync(cancellationToken);
        }

    }
}
