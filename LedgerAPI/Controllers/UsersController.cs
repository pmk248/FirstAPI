using LedgerAPI.Data;
using LedgerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        ApplicationDBContext _context;
        public UsersController(ApplicationDBContext db)
        {
            _context = db;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.Users.ToList();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var selecteduser = _context.Users.Find(id);
            return selecteduser.ToString();
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
            var updateduser = _context.Users.Find(id);
            if (updateduser != null)
            {
                updateduser.FirstName = value.FirstName;
                updateduser.LastName = value.LastName; 
                _context.SaveChanges();
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deleteduser = _context.Users.Find(id);
            if (deleteduser != null)
            {
                _context.Remove(deleteduser);
                _context.SaveChanges();
            }
        }
    }
}
