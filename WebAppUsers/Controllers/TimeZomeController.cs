using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppUsers.DAL;
using WebAppUsers.Services;

namespace WebAppUsers.Controllers
{
    [ApiController]
    [Route("api/v1/timezone")]
    public class TimeZomeController : ControllerBase
    {
        private readonly supercomDbContext _context;

        public TimeZomeController(supercomDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        // public async Task<ActionResult<User>> GetUer(long id)
        public async Task<List<DAL.TimeZone>> GetAll()
        {
            TimeZoneService service = new TimeZoneService(_context);
            var res = await Task.FromResult(service.getAll());
            return res;
        }
    }
}
