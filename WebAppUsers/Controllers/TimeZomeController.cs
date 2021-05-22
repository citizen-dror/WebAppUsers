using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLibrary.Models;
using DataLibrary.BL;
using WebAppUsers.Helpers;

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
        // public async Task<List<DataLibrary.Models.TimeZoneDto>> GetAll()
        public async Task<IActionResult> GetAll()
        {
            TimeZoneService service = new TimeZoneService(_context);
            var res = await Task.FromResult(service
                .getAll()
                .ConvertAll(x => TimeZoneMapper.ToShortDto(x))
                );
            return Ok(res);
        }
    }
}
