using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notification.Application.Verification.Commands;
using System.Threading.Tasks;

namespace Notification.API.Controllers
{
    public class VerificationController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// Update a verification flag for email by UserId
        /// </summary>
        /// <remarks>
        /// Sample request: 
        /// {
        ///     "UserId": 1
        /// }
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [AllowAnonymous]
        public async Task<IActionResult> Update(UpdateVerificationCommand command)
        {
            var response = await Mediator.Send(command);

            return Ok(response);
        }
    }
}
