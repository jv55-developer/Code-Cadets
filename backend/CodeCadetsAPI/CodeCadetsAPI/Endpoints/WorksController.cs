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
        [Authorize(Roles = "admin")]
        public IActionResult All()
        {
            dynamic workHistory = (from w in _context.Works 
                                   join l in _context.Logs on w.WorkId equals l.WorkID 
                                   select new { EmployeeTask = w.Activity, Description = w.Description, HoursLogged = l.HoursWorked }).DefaultIfEmpty();

            if (workHistory != null)
            {
                List<WorkHistory> workHistoryList = workHistory.ToList();
                return Ok(workHistoryList);
                
            }
            else
            {
                return BadRequest("No data");
            }
        }

        private bool WorkExists(int id)
        {
            return _context.Works.Any(e => e.WorkId == id);
        }
    }

    internal class  WorkHistory 
    {
        public string EmployeeTask { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int HoursLogged { get; set; }
    }
}
