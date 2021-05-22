 using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLibrary.Models;
using DataLibrary.BL;
using WebAppUsers.Helpers;
using Microsoft.Extensions.Logging;

namespace WebAppUsers.Controllers
{
    [ApiController]
    [Route("api/v1/timezone")]
    public class TimeZomeController : ControllerBase
    {
        ITimeZoneService _timeZoneService;

        private readonly ILogger<TimeZomeController> _logger;

        public TimeZomeController(ITimeZoneService timeZoneService, ILogger<TimeZomeController> logger)
        {
            _timeZoneService = timeZoneService;
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into TimeZomeController");
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("TimeZome GetAll");
            var res = await Task.FromResult(_timeZoneService
                .getAll()
                .ConvertAll(x => TimeZoneMapper.ToShortDto(x))
                );
            return Ok(res);
        }
    }
}
