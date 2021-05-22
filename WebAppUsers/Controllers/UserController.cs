using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Models;
using DataLibrary.BL;
using WebAppUsers.ModelsDto;
using WebAppUsers.Helpers;
using Microsoft.Extensions.Logging;

namespace WebAppUsers.Controllers
{

    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userSrvice;

        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userSrvice, ILogger<UserController> logger)
        {
            _userSrvice = userSrvice;
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into UserController");
        }

        [HttpGet("{id}")]
        public async Task<UserShortDto> GetUser(long id)
        {
            _logger.LogInformation($"Users Get {id}");
            var res = await Task.FromResult(UeserMapper.ToShortDto(_userSrvice.getUser(id)));
            return res;
        }

        [HttpGet("")]
        public async Task<List<UserShortDto>> GetAllUsers()
        {
            _logger.LogInformation("Users GetAll");
            var res = await Task.FromResult(_userSrvice
                .getAllUsers()
                .ConvertAll(x => UeserMapper.ToShortDto(x))
                );
            return res;
        }

        // POST: UserController/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserAddDto userDto)
        {
            _logger.LogInformation($"Users Create");
            if (!ModelState.IsValid)
            {
                _logger.LogWarning($"Users Created BadRequest");
                return new BadRequestResult();
            }
            User user = UeserMapper.UserFromAddDto(userDto);
            long userid = await Task.FromResult(_userSrvice.addUser(user));
            var res = new UserRes { UserId = userid.ToString() };
            _logger.LogInformation($"Users Created: {userid}");
            return Ok(res);
        }
    }
}
