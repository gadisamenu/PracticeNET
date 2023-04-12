using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeNET.Data;
using PracticeNET.DTO;
using PracticeNET.Models;
using System.Net;

namespace PracticeNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase

    {
      

        private static AppDbContext _context;
        public TeamsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var teams = await _context.Teams.ToListAsync();
            return Ok(teams);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)

        {   var team = await _context.Teams.FirstOrDefaultAsync(t=> t.Id == id);

            if (team == null)
            {
                return NotFound("team not found");
            }
            return Ok(team);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Team team) {
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", team);
        }


        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Patch(int id, [FromBody] TeamDTO newteam)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);
            if (team == null)
            {
                return NotFound("team not found");
            }

            team.Name = newteam.Name ?? team.Name;
            team.Country = newteam.Country ?? team.Country;
            team.TeamPrinciple = newteam.TeamPrinciple ?? team.TeamPrinciple;
           
            await _context.SaveChangesAsync();
            return Ok(team); 
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);

            if (team == null) return NotFound("team not found");
         
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return NoContent();
        }



    }
}