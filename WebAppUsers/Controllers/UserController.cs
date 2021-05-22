using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Models;
using DataLibrary.BL;
using WebAppUsers.ModelsDto;
using WebAppUsers.Helpers;

namespace WebAppUsers.Controllers
{
    public class UserRes
    {
        public string UserId { get; set; }
    }

    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userSrvice;

        public UserController(IUserService userSrvice)
        {
            _userSrvice = userSrvice;
        }

        [HttpGet("{id}")]
        public async Task<UserShortDto> GetUser(long id)
        {
            var res = await Task.FromResult(UeserMapper.ToShortDto(_userSrvice.getUser(id)));
            return res;
        }

        [HttpGet("")]
        public async Task<List<UserShortDto>> GetAllUsers()
        {
            var res = await Task.FromResult(_userSrvice
                .getAllUsers()
                .ConvertAll(x => UeserMapper.ToShortDto(x))
                );
            return res;
        }

        // POST: UserController/Create
        [HttpPost]
        public async Task<UserRes> Create([FromBody] UserAddDto userDto)
        {
            User user = UeserMapper.UserFromAddDto(userDto);
            long userid = await Task.FromResult(_userSrvice.addUser(user));
            var res = new UserRes { UserId = userid.ToString() };
            return res;
        }
    }
}
