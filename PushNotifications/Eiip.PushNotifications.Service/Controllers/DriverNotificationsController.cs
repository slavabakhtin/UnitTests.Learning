using System.Threading.Tasks;
using Eiip.PushNotifications.Service.Fcm;
using Eiip.PushNotifications.Service.Fcm.Driver;
using Eiip.PushNotifications.Service.Fcm.Driver.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eiip.PushNotifications.Service.Controllers
{
    [ApiController]
    [Route("pushnotifications/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class DriverNotificationsController : ControllerBase
    {
        private readonly PushNotificationSender _pushNotificationSender;

        public DriverNotificationsController(PushNotificationSender pushNotificationSender,
            DriverFcmTokenProvider tokenProvider)
        {
            _pushNotificationSender = pushNotificationSender;
            _pushNotificationSender.WithTokenProvider(tokenProvider);
        }

        [HttpPost("carassigned")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> CarAssigned([FromQuery] string driverId, [FromBody] CarAssignedMessageDetails message)
        {
            await _pushNotificationSender.Send(message, driverId);
            return NoContent();
        }

        [HttpPost("carremoved")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> CarRemoved([FromQuery] string driverId, [FromBody] CarRemovedMessageDetails message)
        {
            await _pushNotificationSender.Send(message, driverId);
            return NoContent();
        }

        [HttpPost("futuretripcancelled")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> FutureTripCancelled([FromQuery] string driverId, [FromBody] FutureTripCancelledByClientMessageDetails message)
        {
            await _pushNotificationSender.Send(message, driverId);
            return NoContent();
        }

        [HttpPost("futuretripreminder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> FutureTripReminder([FromQuery] string driverId, [FromBody] FutureTripCancelledByClientMessageDetails message)
        {
            await _pushNotificationSender.Send(message, driverId);
            return NoContent();
        }

        [HttpPost("driverfuturetripstartssoon")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DriverFutureTripStartsSoon([FromQuery] string driverId, [FromBody] FutureTripStartsSoonDriverMessageDetails message)
        {
            await _pushNotificationSender.Send(message, driverId);
            return NoContent();
        }

        [HttpPost("newhotorder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> NewHotOrder([FromQuery] string driverId, [FromBody] NewHotOrderMessageDetails message)
        {
            await _pushNotificationSender.Send(message, driverId);
            return NoContent();
        }

        [HttpPost("neworder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> NewOrder([FromQuery] string driverId, [FromBody] NewOrderMessageDetails message)
        {
            await _pushNotificationSender.Send(message, driverId);
            return NoContent();
        }

        [HttpPost("ridecancelledbyclient")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> RideCancelledByClient([FromQuery] string driverId, [FromBody] RideCancelledByClientMessageDetails message)
        {
            await _pushNotificationSender.Send(message, driverId);
            return NoContent();
        }

        [HttpPost("termsofservicechanged")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> TermsOfServiceChanged([FromQuery] string driverId, [FromBody] TermsOfServiceChangedDriverMessageDetails message)
        {
            await _pushNotificationSender.Send(message, driverId);
            return NoContent();
        }

        [HttpPost("waitcancelledbyclient")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> WaitCancelledByClient([FromQuery] string driverId, [FromBody] WaitCancelledByClientMessageDetails message)
        {
            await _pushNotificationSender.Send(message, driverId);
            return NoContent();
        }
    }
}