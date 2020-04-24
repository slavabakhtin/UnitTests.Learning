using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TopCase.OlivaTaxi.PushNotifications.Database;
using TopCase.OlivaTaxi.PushNotifications.Database.Models;

namespace Eiip.PushNotifications.Service.Fcm.Passenger
{
    public class PassengerFcmTokenProvider : FcmTokenProvider
    {
        public PassengerFcmTokenProvider(PushNotificationsDbContext dbContext)
            :base(dbContext)
        {
        }

        public override async Task<IReadOnlyList<IFcmToken>> GetRegistrationTokens(string uid)
        {
            return await DbContext.PassengerTokens
                .Where(x => x.Uid == uid)
                .ToListAsync();
        }
    }
}