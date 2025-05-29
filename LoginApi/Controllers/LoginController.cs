using Microsoft.AspNetCore.Mvc;
using LoginApi.Data;
using LoginApi.Models;
using System.Linq;

namespace LoginApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Logins.ToList());
        }

        [HttpPost("register")]
        public IActionResult Register(Login login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Logins.Add(login);
            _context.SaveChanges();
            return Ok(login);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login credentials)
        {
            var user = _context.Logins.FirstOrDefault(u =>
                u.Email == credentials.Email && u.Password == credentials.Password);

            if (user == null)
                return Unauthorized("Invalid credentials");

            if (user.IsLoggedIn)
                return BadRequest("User already logged in");

            user.IsLoggedIn = true;
            _context.SaveChanges();

            return Ok("Login successful");
        }

        [HttpPost("logout/{id}")]
        public IActionResult Logout(int id)
        {
            var user = _context.Logins.Find(id);
            if (user == null)
                return NotFound();

            if (!user.IsLoggedIn)
                return BadRequest("User is not logged in");

            user.IsLoggedIn = false;
            _context.SaveChanges();

            return Ok("Logout successful");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.Logins.Find(id);
            if (user == null)
                return NotFound();

            _context.Logins.Remove(user);
            _context.SaveChanges();
            return Ok("User deleted");
        }
    }
}
