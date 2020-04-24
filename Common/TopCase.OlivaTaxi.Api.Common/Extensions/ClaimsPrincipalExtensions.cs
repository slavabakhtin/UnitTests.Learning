using System.Linq;
using System.Security.Claims;
using TopCase.OlivaTaxi.Api.Common.Exceptions;

namespace TopCase.OlivaTaxi.Api.Common.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static int ParkId(this ClaimsPrincipal user)
        {
            var claimValue = user.FindFirstValue(Claims.ParkId);
            if (int.TryParse(claimValue, out int parkId))
            {
                return parkId;
            }

            throw new OlivaTaxiException($"Can't read park id for user {user.Id()}. {Claims.ParkId} value is {claimValue}.");
        }

        public static string Email(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.Email);
        }

        public static string Phone(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(Claims.Phone_number);
        }

        public static string Name(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(Claims.Name);
        }

        public static string Photo(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(Claims.Picture);
        }

        public static string[] Roles(this ClaimsPrincipal user)
        {
            return user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(x => x.Value).ToArray();
        }
    }
}