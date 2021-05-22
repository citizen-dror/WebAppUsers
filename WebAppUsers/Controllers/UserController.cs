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
        private readonly supercomDbContext _context;

        public UserController(supercomDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<UserShortDto> GetUser(long id)
        {
            UserService service = new UserService(_context);
            var res = await Task.FromResult(UeserMapper.ToShortDto(service.getUser(id)));
            return res;
        }

        [HttpGet("")]
        public async Task<List<UserShortDto>> GetAllUsers()
        {
            UserService service = new UserService(_context);
            var res = await Task.FromResult(service
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
            UserService service = new UserService(_context);
            long userid = await Task.FromResult(service.addUser(user));
            var res = new UserRes { UserId = userid.ToString() };
            return res;
        }
    }
}
