using System.Collections.Generic;
using System.Threading.Tasks;
using Eiip.PushNotifications.Database;
using Eiip.PushNotifications.Database.Models;

namespace Eiip.PushNotifications.Service.Fcm
{
    public abstract class FcmTokenProvider
    {
        protected readonly PushNotificationsDbContext DbContext;

        protected FcmTokenProvider(PushNotificationsDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public abstract Task<IReadOnlyList<IFcmToken>> GetRegistrationTokens(string uid);

        public virtual async Task ProcessFailedTokens(IReadOnlyList<IFcmToken> tokens)
        {
            DbContext.RemoveRange(tokens);
            await DbContext.SaveChangesAsync();
        }
    }
}