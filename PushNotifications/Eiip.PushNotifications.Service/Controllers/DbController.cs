using System.Threading.Tasks;
using Eiip.PushNotifications.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eiip.PushNotifications.Service.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("pushnotifications")]
    [Produces("application/json")]
    public class DbController : ControllerBase
    {
        private readonly PushNotificationsDbContext _dbContext;

        public DbController(PushNotificationsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("migrate")]
        [ProducesResponseType( StatusCodes.Status200OK)]
        public async Task<ActionResult> Migrate()
        {
            await _dbContext.Database.MigrateAsync();
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
