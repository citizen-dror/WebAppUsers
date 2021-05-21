using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppUsers.DAL;
using WebAppUsers.Services;

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
        public async Task<User> GetUser(long id)
        {
            UserService service = new UserService(_context);
            var res = await Task.FromResult(service.getUser(id));
            return res;
        }


        [HttpGet("all")]
        public async Task<List<User>> GetAllUsers()
        {
            UserService service = new UserService(_context);
            var res = await Task.FromResult(service.getAllUsers());
            return res;
        }

        // POST: UserController/Create
        [HttpPost]
        public async Task<UserRes> Create([FromBody] User user)
        {
            UserService service = new UserService(_context);
            long userid = await Task.FromResult(service.addUser(user));
            var res = new UserRes { UserId = userid.ToString() };
            return res;
        }
    }
}
