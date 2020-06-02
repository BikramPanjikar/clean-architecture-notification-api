using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using MediatR;
using Notification.Application.Interfaces;

namespace Notification.Application.Timer
{
    public class TimerCommand : IRequest
    {
    }

    public class TimerCommandHandler : IRequestHandler<TimerCommand>
    {
        private readonly INotificationDBContaxt _context;

        public TimerCommandHandler(INotificationDBContaxt context)
        {
            _context = context;

        }

        public async Task<Unit> Handle(TimerCommand request, CancellationToken cancellationToken)
        {
            var timer = new Timer(_context);

            await timer.StartTimer(cancellationToken);

            return Unit.Value;
        }

    }
}


