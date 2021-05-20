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
    public class Person
    {
        public string Name { get; set; }
    }

    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly supercomDbContext _context;

        public UserController(supercomDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        // public async Task<ActionResult<User>> GetUer(long id)
        public ActionResult<User> GetUer(long id)
        {
            User res= null;
            try
            {
                UserService service = new UserService(_context);
                res = service.getUser(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return Content("-1");
            }
        }


        [HttpGet("all")]
        // public async Task<ActionResult<User>> GetUer(long id)
        public ActionResult<User> GetAllUsers()
        {
            List<User> res = null;
            try
            {
                UserService service = new UserService(_context);
                res = service.getAllUsers();
                return Ok(res);
            }
            catch
            {
                return Content("-1");
            }
        }

        // POST: UserController/Create
        [HttpPost]
        public ActionResult Create([FromBody] User user)
        {
            try
            {
                user.CreateDate = DateTime.Now;
                UserService service = new UserService(_context);
                long res = service.addUSer(user);
                return Ok(res);
            }
            catch 
            {
                return Content("-1");
            }
        }

    }
}
