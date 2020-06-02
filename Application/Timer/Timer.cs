using System.Threading;
using System.Threading.Tasks;
using Notification.Application.Interfaces;
using System.Timers;
using System;

namespace Notification.Application.Timer
{
    public class Timer
    {
        private readonly INotificationDBContaxt _context;

        public Timer(INotificationDBContaxt context)
        {
            _context = context;
        }

        public async Task ReadAllAsync(CancellationToken cancellationToken)
        {
            await StartTimer(cancellationToken);
        }

        public async Task StartTimer(CancellationToken cancellationToken)
        {
            System.Timers.Timer t1 = new System.Timers.Timer();
            t1.Interval = (1000 * 60 * 20); // 20 minutes...
            t1.Elapsed += new ElapsedEventHandler(t1_Elapsed);
            t1.AutoReset = true;
            t1.Start();
        }

        private void t1_Elapsed(object sender, ElapsedEventArgs e)
        {
            DateTime scheduledRun = DateTime.Today.AddHours(0);  // runs today at 12am.
            System.IO.FileInfo lastTime = new System.IO.FileInfo(@"C:\lastRunTime.txt");
            DateTime lastRan = lastTime.LastWriteTime;

            if (DateTime.Now > scheduledRun)
            {
                TimeSpan sinceLastRun = DateTime.Now - lastRan;
                if (sinceLastRun.Hours > 23)
                {
                    // Read UserData from Database
                    foreach (var user in _context.Users)
                    {
                        if (!user.IsVerified)
                        {
                            _ = SendEmailAsync(user.Email);
                        }
                    }

                    // ToDo: Update the file modification date here.
                }
            }
        }

        private async Task SendEmailAsync(string email)
        {
            // Send email (SMTPClient) logic goes here...

            throw new NotImplementedException();
        }

    }
}

