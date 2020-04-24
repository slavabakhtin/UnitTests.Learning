using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TopCase.OlivaTaxi.PushNotifications.Database;
using TopCase.OlivaTaxi.PushNotifications.Database.Models;

namespace Eiip.PushNotifications.Service.Fcm.Driver
{
    public class DriverFcmTokenProvider : FcmTokenProvider
    {
        public DriverFcmTokenProvider(PushNotificationsDbContext dbContext)
            :base(dbContext)
        {
        }

        public override async Task<IReadOnlyList<IFcmToken>> GetRegistrationTokens(string uid)
        {
            return await DbContext.DriverTokens
                .Where(x => x.Uid == uid)
                .ToListAsync();
        }
    }
}