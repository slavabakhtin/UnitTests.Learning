﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TopCase.OlivaTaxi.PushNotifications.Database;

namespace Eiip.PushNotifications.Api.Controllers
{
    [Route("payments/[controller]")]
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
