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
        ITimeZoneService _timeZoneService;

        public TimeZomeController(ITimeZoneService timeZoneService)
        {
            _timeZoneService = timeZoneService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var res = await Task.FromResult(_timeZoneService
                .getAll()
                .ConvertAll(x => TimeZoneMapper.ToShortDto(x))
                );
            return Ok(res);
        }
    }
}
