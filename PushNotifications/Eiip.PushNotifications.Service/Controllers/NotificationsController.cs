using System.Threading.Tasks;
using Eiip.PushNotifications.Service.Fcm;
using Eiip.PushNotifications.Service.Fcm.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eiip.PushNotifications.Service.Controllers
{
    [ApiController]
    [Route("pushnotifications")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class NotificationsController : ControllerBase
    {
        private readonly PushNotificationSender _pushNotificationSender;

        public NotificationsController(PushNotificationSender pushNotificationSender,
            FcmTokenProvider tokenProvider)
        {
            _pushNotificationSender = pushNotificationSender;
            _pushNotificationSender.WithTokenProvider(tokenProvider);
        }

        [HttpPost("carassigned")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> CarAssigned([FromQuery] string id, [FromBody] NewMessageDetails message)
        {
            await _pushNotificationSender.Send(message, id);
            return NoContent();
        }
    }
}