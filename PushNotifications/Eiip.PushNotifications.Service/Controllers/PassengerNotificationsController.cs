using System.Threading.Tasks;
using Eiip.PushNotifications.Service.Fcm;
using Eiip.PushNotifications.Service.Fcm.Passenger;
using Eiip.PushNotifications.Service.Fcm.Passenger.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eiip.PushNotifications.Service.Controllers
{
    [ApiController]
    [Route("pushnotifications/[controller]")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class PassengerNotificationsController : ControllerBase
    {
        private readonly PushNotificationSender _pushNotificationSender;

        public PassengerNotificationsController(PushNotificationSender pushNotificationSender,
            PassengerFcmTokenProvider tokenProvider)
        {
            _pushNotificationSender = pushNotificationSender;
            _pushNotificationSender.WithTokenProvider(tokenProvider);
        }

        [HttpPost("driverarrived")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DriverArrived(string passengerId, [FromBody] DriverArrivedMessageDetails request)
        {
            await _pushNotificationSender.Send(request, passengerId);
            return NoContent();
        }

        [HttpPost("driverfound")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DriverFound(string passengerId, [FromBody] DriverFoundMessageDetails request)
        {
            await _pushNotificationSender.Send(request, passengerId);
            return NoContent();
        }

        [HttpPost("freewaitingfinished")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> FreeWaitingFinished(string passengerId, [FromBody] FreeWaitingFinishedMessageDetails request)
        {
            await _pushNotificationSender.Send(request, passengerId);
            return NoContent();
        }

        [HttpPost("futuretripstartssoon")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> FutureTripStartsSoon(string passengerId, [FromBody] FutureTripStartsSoonPassengerMessageDetails request)
        {
            await _pushNotificationSender.Send(request, passengerId);
            return NoContent();
        }

        [HttpPost("termsofservicechanged")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> TermsOfServiceChanged(string passengerId, [FromBody] TermsOfServiceChangedPassengerMessageDetails request)
        {
            await _pushNotificationSender.Send(request, passengerId);
            return NoContent();
        }

        [HttpPost("repeatsearch")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> RepeatSearch(string passengerId, [FromBody] RepeatSearchMessageDetails request)
        {
            await _pushNotificationSender.Send(request, passengerId);
            return NoContent();
        }

        [HttpPost("trippaused")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> TripPaused(string passengerId, [FromBody] TripPausedMessageDetails request)
        {
            await _pushNotificationSender.Send(request, passengerId);
            return NoContent();
        }

        [HttpPost("tripstarted")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> TripStarted(string passengerId, [FromBody] TripStartedMessageDetails request)
        {
            await _pushNotificationSender.Send(request, passengerId);
            return NoContent();
        }

        [HttpPost("futuretripstarted")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> FutureTripStarted(string passengerId, [FromBody] FutureTripStartedMessageDetails request)
        {
            await _pushNotificationSender.Send(request, passengerId);
            return NoContent();
        }

        [HttpPost("waitcanceled")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> WaitCanceled(string passengerId, [FromBody] WaitCancelMessageDetails request)
        {
            await _pushNotificationSender.Send(request, passengerId);
            return NoContent();
        }

        [HttpPost("ridecanceled")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> RideCanceled(string passengerId, [FromBody] RideCancelMessageDetails request)
        {
            await _pushNotificationSender.Send(request, passengerId);
            return NoContent();
        }

        [HttpPost("futuredriverfound")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> FutureDriverFound(string passengerId, [FromBody] FutureDriverFoundMessageDetails request)
        {
            await _pushNotificationSender.Send(request, passengerId);
            return NoContent();
        }

        [HttpPost("tripfinished")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> TripFinished(string passengerId, [FromBody] TripFinishedMessageDetails request)
        {
            await _pushNotificationSender.Send(request, passengerId);
            return NoContent();
        }

        [HttpPost("passengerfuturetripstartssoon")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> PassengerFutureTripStartsSoon(string passengerId, [FromBody] FutureTripStartsSoonPassengerMessageDetails request)
        {
            await _pushNotificationSender.Send(request, passengerId);
            return NoContent();
        }
    }
}