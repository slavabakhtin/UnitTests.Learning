using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Eiip.Api.Common.Enums;
using Eiip.Api.Common.Extensions;
using Eiip.PushNotifications.Database;
using Eiip.PushNotifications.Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eiip.PushNotifications.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("pushnotifications")]
    [Produces("application/json")]
    public class RegistrationTokensController : ControllerBase
    {
        private readonly PushNotificationsDbContext _dbContext;

        public RegistrationTokensController(PushNotificationsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("ios")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> PostIosToken([Required] string token)
        {
            var fcmToken = new FcmToken()
            {
                Uid = User.Id(),
                Timestamp = DateTime.UtcNow,
                Token = token,
                Platform = MobilePlatform.Ios
            };

            await _dbContext.Tokens
                .Upsert(fcmToken)
                .On(x => new {x.Token})
                .RunAsync();

            return NoContent();
        }

        [HttpDelete("ios")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteIosToken([Required] string token)
        {
            var fcmToken = await _dbContext.Tokens
                .Where(x => x.Uid == User.Id() && x.Token == token && x.Platform == MobilePlatform.Ios)
                .FirstOrDefaultAsync();
            if (fcmToken == null)
            {
                return NoContent();
            }

            _dbContext.Tokens.Remove(fcmToken);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("android")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> PostAndroidToken([Required] string token)
        {
            var fcmToken = new FcmToken()
            {
                Uid = User.Id(),
                Timestamp = DateTime.UtcNow,
                Token = token,
                Platform = MobilePlatform.Android
            };

            await _dbContext.Tokens
                .Upsert(fcmToken)
                .On(x => new {x.Token})
                .RunAsync();

            return NoContent();
        }

        [HttpDelete("android")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteAndroidToken([Required] string token)
        {
            var fcmToken = await _dbContext.Tokens
                .Where(x => x.Uid == User.Id() && x.Token == token && x.Platform == MobilePlatform.Android)
                .FirstOrDefaultAsync();
            if (fcmToken == null)
            {
                return NoContent();
            }

            _dbContext.Tokens.Remove(fcmToken);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}