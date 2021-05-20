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
            User user = new User();
            user.UserId = id;
            user.FirstName = "bob";
            user.LastName = "marly";
            user.CreateDate = DateTime.Now;
            return user;
            //var user = await _context.TodoItems.FindAsync(id);

            //if (todoItem == null)
            //{
            //    return NotFound();
            //}

            //return todoItem;
        }

        // POST: UserController/Create
        [HttpPost]
        public ActionResult Create()
        {
            try
            {
                User user = new User();
                user.FirstName = "bob";
                user.LastName = "marly";
                user.WebSite = "google.com";
                user.CreateDate = DateTime.Now;

                UserService service = new UserService(_context);
                long res = service.addUSer(user);
                return Content(res.ToString());
            }
            catch 
            {
                return Content("-1");
            }
        }

    }
}
