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
using System.Threading.Tasks.Dataflow;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;

namespace CodeCadetsAPI.Endpoints
{
    [ApiController]
    [Route("[controller]")]
    public class WorksController : ControllerBase
    {
        private readonly DashboardDataContext _context;

        public WorksController(DashboardDataContext context)
        {
            _context = context;
        }
        [HttpGet("all")]
        [Produces("application/json")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public IActionResult All()
        {
            dynamic workHistory = (from w in _context.Works
                                   join u in _context.Users on w.UserId equals u.UserId
                                   select new { Name = u.Name, HoursWorked = $"{w.HoursWorked} Hours" }).DefaultIfEmpty();

            if (workHistory != null)
            {
                List<WorkHistory> list = new List<WorkHistory>();
                foreach (var work in workHistory)
                {
                    WorkHistory history = new WorkHistory
                    {
                        Name = work.Name,
                        HoursWorked = work.HoursWorked,
                    };
                    list.Add(history);
                }
                return Ok(list);
            }
            else
            {
                return BadRequest("No data");
            }
        }
        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Add([FromBody] string activityName, [FromBody] int hoursWorked, [FromQuery] int id)
        {
            var work = (from w in _context.Works 
                        join u in _context.Users on w.UserId equals u.UserId
                        where u.UserId == id
                        select new { Id = u.UserId, Name = u.Name, Hours = w.HoursWorked, Activity = w.Activity }
                        ).FirstOrDefault();
            if (work != null)
            {
                var workDone = new Work
                {
                    Activity = activityName,
                    HoursWorked = hoursWorked,
                    UserId = work.Id
                };
                _context.Works.Add(workDone);
                try
                {
                    _context.SaveChanges();
                    return Ok("Work Hostory added");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.GetBaseException());
                    return BadRequest("Could not save work history");
                }
            }
            else
            {
                return BadRequest("Could not find user");
            }
            
        }

        [HttpGet("single")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Single([FromQuery] int id)
        {
            var workHistory = (from w in _context.Works
                                   join u in _context.Users on w.UserId equals u.UserId
                                   where u.UserId == id
                                   select new { Name = u.Name, HoursWorked = $"{w.HoursWorked} Hours" }).FirstOrDefault();
            if (workHistory != null)
            {
                return Ok(workHistory);
            }
            else
            {
                return BadRequest("User not authorized");
            }
        }

        private bool WorkExists(int id)
        {
            return _context.Works.Any(e => e.WorkId == id);
        }
    }

    internal class  WorkHistory 
    {
        public string Name { get; set; } = string.Empty;
        //public string Activity { get; set; } = string.Empty;
        public int HoursWorked { get; set; }
    }
}
