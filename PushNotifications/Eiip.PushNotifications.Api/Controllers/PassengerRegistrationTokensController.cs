using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TopCase.OlivaTaxi.Api.Common.Extensions;
using TopCase.OlivaTaxi.Common.Enums;
using TopCase.OlivaTaxi.PushNotifications.Database;
using TopCase.OlivaTaxi.PushNotifications.Database.Models;

namespace Eiip.PushNotifications.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("pushnotifications/[controller]")]
    [Produces("application/json")]
    public class PassengerRegistrationTokensController : ControllerBase
    {
        private readonly PushNotificationsDbContext _dbContext;

        public PassengerRegistrationTokensController(PushNotificationsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("ios")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> PostIosToken([Required] string token)
        {
            var fcmToken = new PassengerToken()
            {
                Uid = User.Id(),
                Timestamp = DateTime.UtcNow,
                Token = token,
                Platform = MobilePlatform.Ios
            };

            await _dbContext.PassengerTokens
                .Upsert(fcmToken)
                .On(x => new {x.Token})
                .RunAsync();

            return NoContent();
        }

        [HttpDelete("ios")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteIosToken([Required] string token)
        {
            var fcmToken = await _dbContext.PassengerTokens
                .Where(x => x.Uid == User.Id() && x.Token == token && x.Platform == MobilePlatform.Android)
                .FirstOrDefaultAsync();
            if (fcmToken == null)
            {
                return NoContent();
            }

            _dbContext.PassengerTokens.Remove(fcmToken);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("android")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> PostAndroidToken([Required] string token)
        {
            var fcmToken = new PassengerToken()
            {
                Uid = User.Id(),
                Timestamp = DateTime.UtcNow,
                Token = token,
                Platform = MobilePlatform.Android
            };

            await _dbContext.PassengerTokens
                .Upsert(fcmToken)
                .On(x => new {x.Token})
                .RunAsync();

            return NoContent();
        }

        [HttpDelete("android")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteAndroidToken([Required] string token)
        {
            var fcmToken = await _dbContext.PassengerTokens
                .Where(x => x.Uid == User.Id() && x.Token == token && x.Platform == MobilePlatform.Android)
                .FirstOrDefaultAsync();
            if (fcmToken == null)
            {
                return NoContent();
            }

            _dbContext.PassengerTokens.Remove(fcmToken);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}