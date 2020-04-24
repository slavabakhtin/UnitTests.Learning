namespace TopCase.OlivaTaxi.Api.Common
{
    public class Claims
    {
        public const string Roles = "roles";
        public static string ParkId => nameof(ParkId).ToLower();
        public static string Phone_number => nameof(Phone_number).ToLower();
        public static string Email => nameof(Email).ToLower();
        public static string Name => nameof(Name).ToLower();
        public static string Picture => nameof(Picture).ToLower();
    }
}