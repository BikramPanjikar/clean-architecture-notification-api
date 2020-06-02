using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Notification.Application.Interfaces;
using Entities = Notification.Domain.Entities;

namespace Notification.Application.Verification.Commands
{
    public class UpdateVerificationCommand : IRequest<string>
    {
        public int? UserId { get; set; }

        public class UpdateVerificationCommandHandler : IRequestHandler<UpdateVerificationCommand, string>
        {
            private readonly INotificationDBContaxt _context;

            public UpdateVerificationCommandHandler(INotificationDBContaxt context)
            {
                _context = context;
            }

            public async Task<string> Handle(UpdateVerificationCommand request, CancellationToken cancellationToken)
            {
                Entities.User entity = await _context.Users.FindAsync(request.UserId.Value);

                try
                {
                    entity.IsVerified = true;

                    await _context.SaveChangesAsync(cancellationToken);

                    return "Thanks!";
                }
                catch(Exception ex)
                {
                    // ToDo: Implement exception handling & return statur code 500. 
                    // ToDo: Log exception. 
                    return "InternalServerError";
                }
                
            }
        }
    }
}

