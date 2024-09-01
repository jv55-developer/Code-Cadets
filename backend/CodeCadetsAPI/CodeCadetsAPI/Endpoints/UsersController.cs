using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeCadetsAPI.Data;
using CodeCadetsAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeCadetsAPI.Endpoints
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DashboardDataContext _context;

        private JWTSetup _jwtSetup;

        public UsersController(DashboardDataContext context, JWTSetup jWTSetup)
        {
            _context = context;
            _jwtSetup = jWTSetup;
        }

        // GET: Users
        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        public IActionResult All()
        {
            return Ok(_context.Users.ToList());
        }
        [HttpPost("signup")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult SignUp([FromBody] Register reg)
        {
            if ((string.IsNullOrEmpty(reg.Email)) || (string.IsNullOrEmpty(reg.Password)) || (string.IsNullOrEmpty(reg.ConfirmPassword)))
            {
                return BadRequest("One or more values missing");
            }

            if (!reg.Password.Equals(reg.ConfirmPassword))
            {
                return BadRequest("Passwords do not match");
            }

            if (UserExists(reg.Email))
            {
                return BadRequest("Email already exists");
            }

            var user = new User
            {
                Email = reg.Email,
                Password = Secrecy.Hash(reg.Password),
                PhoneNumber = reg.PhoneNumber,
                Role = "Staff",
                CreatedDate = DateTime.Now,
                Name = reg.Name
            };
            _context.Users.Add(user);
            try
            {
                _context.SaveChanges();
                return Ok("Send user to login page");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return BadRequest("Could not register user");
            }
        }

        private bool UserExists(string email)
        {
            return _context.Users.Any(e => e.Email == email);
        }
        [HttpPost("login")]
        [Consumes("application/json")]
        public ActionResult Login([FromBody] Person person)
        {
            string hashPassword = Secrecy.Hash(person.Password);
            if ((!string.IsNullOrEmpty(hashPassword)) || (!string.IsNullOrEmpty(person.Email)))
            {
                dynamic token;
                var user = (from u in _context.Users
                            where u.Email == person.Email
                            && u.Password == person.Password
                            select u).FirstOrDefault();

                if (user != null)
                {
                    _context.Users.Add(user);
                    token = _jwtSetup.CreateToken(user);
                    return Ok(token);
                }
                else
                {
                    return BadRequest("Invalid email or password");
                }
            }
            else
            {
                return BadRequest("No email or password provided");
            }
        }
        [HttpPost("admin/signup")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize(Roles = "Admin")]
        public IActionResult SignUpAdmin([FromBody] Register reg)
        {
            if ((string.IsNullOrEmpty(reg.Email)) || (string.IsNullOrEmpty(reg.Password)) || (string.IsNullOrEmpty(reg.ConfirmPassword)))
            {
                return BadRequest("One or more values missing");
            }

            if (!reg.Password.Equals(reg.ConfirmPassword))
            {
                return BadRequest("Passwords do not match");
            }

            if (UserExists(reg.Email))
            {
                return BadRequest("Email already exists");
            }

            var user = new User
            {
                Email = reg.Email,
                Password = Secrecy.Hash(reg.Password),
                PhoneNumber = reg.PhoneNumber,
                Role = "Admin",
                CreatedDate = DateTime.Now,
                Name = reg.Name
            };
            _context.Users.Add(user);
            try
            {
                _context.SaveChanges();
                return Ok("Send user to login page");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return BadRequest("Could not register user");
            }
        }
        [HttpPut("update")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize]
        public IActionResult Update([FromBody] string email, [FromBody] string newEmail, [FromBody] string phoneNumber)
        {
            if (UserExists(email))
            {
                var user = new User
                {
                    Email = newEmail,
                    PhoneNumber = phoneNumber
                };
                _context.Users.Update(user);
                try
                {
                    _context.SaveChanges();
                    return Ok(_jwtSetup.CreateToken(user));
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                    return BadRequest("Could not update changes");
                }
            }
            else
            {
                return BadRequest("User not logged in");
            }
        }
    }

    public class Register
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;


    }
}

public class Person
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

}

