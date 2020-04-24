namespace TopCase.OlivaTaxi.PushNotifications.Database.Models
{
    public interface IFcmToken
    {
        string Uid { get; }

        string Token { get; }
    }
}